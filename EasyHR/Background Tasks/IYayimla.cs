using System.Threading;
using System.Threading.Tasks;

namespace EasyHR.Background_Tasks
{
    public interface IYayimla
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}