using EasyHR.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyHR.Background_Tasks
{
    public class Yayimla : IYayimla
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public Yayimla(IServiceScopeFactory scopeFactory)
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
                    var paketler = _db.Paketler.ToList();

                    foreach (var paket in paketler)
                    {
                        if (DateTime.Now >= paket.YayimlanmaTarihi && DateTime.Now <= paket.YayimdanAlmaTarihi)
                            paket.SatistaMi = true;
                        else
                            paket.SatistaMi = false;

                        await _db.SaveChangesAsync();
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }

            }
        }
    }
}
