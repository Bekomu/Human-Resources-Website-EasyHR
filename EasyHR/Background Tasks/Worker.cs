using EasyHR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyHR.Background_Tasks
{
    public class Worker : IWorker
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                while (!cancellationToken.IsCancellationRequested)
                {
                    var users = _db.Users.ToList();

                    foreach (var user in users)
                    {

                        var iseGirisTarihi = user.IseGirisTarihi;

                        if (DateTime.Now > user.IzinGuncellemeTarihi)
                        {
                            var calisilanYil = (int)(DateTime.Now.Subtract(user.IseGirisTarihi).TotalDays / 365);
                            if (calisilanYil >= 1 && calisilanYil < 5)
                                user.YillikIzinGunSayisi += 14;
                            else if (calisilanYil >= 5 && calisilanYil < 15)
                                user.YillikIzinGunSayisi += 20;
                            else if (calisilanYil >= 15)
                                user.YillikIzinGunSayisi += 26;

                            user.IzinGuncellemeTarihi = new DateTime(DateTime.Now.Year, iseGirisTarihi.Month, iseGirisTarihi.Day, iseGirisTarihi.Hour, iseGirisTarihi.Minute, iseGirisTarihi.Second).AddYears(1);

                            await _db.SaveChangesAsync();
                        }
                    }

                    await Task.Delay(TimeSpan.FromDays(1));
                }

            }
        }
    }
}
