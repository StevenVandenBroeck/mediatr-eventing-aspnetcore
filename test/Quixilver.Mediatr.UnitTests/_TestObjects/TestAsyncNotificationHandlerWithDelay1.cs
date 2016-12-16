using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Quixilver.Eventing.UnitTests
{
    public class TestAsyncNotificationHandlerWithDelay1 : IAsyncNotificationHandler<TestAsyncNotification>
    {
        public string Message { get; set; }

        public Task Handle(TestAsyncNotification notification)
        {
            Thread.Sleep(5000);

            var msg = $"Handled by {this.GetType().Name} : {notification.Message} (Thread {Thread.CurrentThread.ManagedThreadId})";
            Message = msg;
            Debug.WriteLine(msg);

            return Task.CompletedTask;
        }
    }
}
