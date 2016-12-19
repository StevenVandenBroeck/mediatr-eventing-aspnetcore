using System;
using MediatR;

namespace Quixilver.Eventing
{
    public class AppEvent : INotification, IAsyncNotification, ICancellableAsyncNotification
    { }
}
