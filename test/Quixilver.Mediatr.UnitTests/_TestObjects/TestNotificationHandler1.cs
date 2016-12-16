using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Quixilver.Eventing.UnitTests
{
    public class TestNotificationHandler1 : INotificationHandler<TestNotification>
    {
        public string Message { get; set; }

        public void Handle(TestNotification notification)
        {
            var msg = $"Handled by {this.GetType().Name} : {notification.Message} (Thread {Thread.CurrentThread.ManagedThreadId})";
            Message = msg;
            Debug.WriteLine(msg);
        }
    }
}
