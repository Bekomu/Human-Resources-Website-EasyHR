using System.Threading;
using System.Threading.Tasks;

namespace EasyHR.Background_Tasks
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}