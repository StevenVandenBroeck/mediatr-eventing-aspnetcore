using System;
using MediatR;

namespace Quixilver.Eventing
{
    public interface IAsyncEventHandler<TEvent> : IAsyncNotificationHandler<TEvent> where TEvent : AppEvent
    { }
}
