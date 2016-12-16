using System;
using Quixilver.Eventing.Handling;

namespace Quixilver.Eventing
{
    public class EventingOptions
    {
        public Type ExceptionHandlerType { get; private set; } = typeof(DefaultEventingExceptionHandler);

        public void RegisterExceptionHandler<TExceptionHandler>() where TExceptionHandler : IEventingExceptionHandler
        {
            ExceptionHandlerType = typeof(TExceptionHandler);
        }
    }
}
