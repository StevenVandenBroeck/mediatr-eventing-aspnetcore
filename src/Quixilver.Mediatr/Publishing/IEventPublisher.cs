using System;
using System.Threading.Tasks;
using System.Threading;

namespace Quixilver.Eventing
{
    public interface IEventPublisher
    {
        void Publish(AppEvent appEvent);
        Task PublishAsync(AppEvent appEvent);
        Task PublishAsync(AppEvent appEvent, CancellationToken cancellationToken);
    }
}
