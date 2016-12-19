using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quixilver.Eventing.Handling;

namespace Quixilver.Eventing
{
    public class EventingOptions
    {
        public EventingOptions(IServiceCollection services)
        {
            _services = services;
        }

        private readonly IServiceCollection _services;

        public Type ExceptionHandlerType { get; private set; } = typeof(DefaultEventingExceptionHandler);

        public void RegisterExceptionHandler<TExceptionHandler>() where TExceptionHandler : IEventingExceptionHandler
        {
            ExceptionHandlerType = typeof(TExceptionHandler);
            // ToDo (SVB) : direct registreren
        }

        public void RegisterAsyncEventHandler<TEvent, TEventHandler>() where TEvent : AppEvent where TEventHandler : IAsyncEventHandler<TEvent>
        {
            _services.AddScoped(typeof(IAsyncNotificationHandler<TEvent>), typeof(TEventHandler));
        }

        public void RegisterAsyncEventHandler<TEvent>(IAsyncEventHandler<TEvent> eventHandler) where TEvent : AppEvent
        {
            _services.AddSingleton(typeof(IAsyncNotificationHandler<TEvent>), eventHandler);
        }

        public void RegisterEventHandler<TEvent, TEventHandler>() where TEvent : AppEvent where TEventHandler : IEventHandler<TEvent>
        {
            _services.AddScoped(typeof(INotificationHandler<TEvent>), typeof(TEventHandler));
        }

        public void RegisterEventHandler<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : AppEvent
        {
            _services.AddSingleton(typeof(INotificationHandler<TEvent>), eventHandler);
        }
    }
}
