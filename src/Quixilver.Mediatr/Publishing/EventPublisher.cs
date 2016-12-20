using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Quixilver.Eventing.Publishing
{
    public class EventPublisher : IEventPublisher
    {
        public EventPublisher(IMediator mediator, EventingOptions options, IEventingExceptionHandler exceptionHandler)
        {
            _mediator = mediator;
            _options = options;
            _exceptionHandler = exceptionHandler;
        }

        private readonly IMediator _mediator;
        private readonly EventingOptions _options;
        private readonly IEventingExceptionHandler _exceptionHandler;

        public void Publish(AppEvent appEvent)
        {
            _mediator.Publish(appEvent);
        }

        public async Task PublishAsync(AppEvent appEvent)
        {
            await Task.Run(() => {
                try
                {
                    return _mediator.PublishAsync(appEvent);
                }
                catch ( Exception ex )
                {
                    var eventingEx = new EventingException(appEvent, ex);
                    _exceptionHandler.Handle(eventingEx);
                    return Task.FromException(ex);
                }
            });
        }

        public async Task PublishAsync(AppEvent appEvent, CancellationToken cancellationToken)
        {
            await Task.Run(() => {
                try
                {
                    return _mediator.PublishAsync(appEvent, cancellationToken);
                }
                catch ( Exception ex )
                {
                    var eventingEx = new EventingException(appEvent, ex);
                    _exceptionHandler.Handle(eventingEx);
                    return Task.FromException(ex);
                }
            });
        }
    }
}
