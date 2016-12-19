using System;
using MediatR;

namespace Quixilver.Eventing
{
    public interface IEventHandler<TEvent> : INotificationHandler<TEvent> where TEvent : AppEvent
    { }
}
