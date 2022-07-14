using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EasyHR.Background_Tasks
{
    public class BackgroundTasker : BackgroundService
    {
        private readonly IWorker _worker;
        private readonly IYayimla _yayimla;

        public BackgroundTasker(IWorker worker, IYayimla yayimla)
        {
            _worker = worker;
            _yayimla = yayimla;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
            await _yayimla.DoWork(stoppingToken);
        }
    }
}
