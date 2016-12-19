using System;
using System.Diagnostics;
using System.Threading;

namespace Quixilver.Eventing.UnitTests
{
    public class TestEventHandler1 : IEventHandler<TestEvent>
    {
        public string Message { get; set; }

        public void Handle(TestEvent notification)
        {
            var msg = $"Handled by {this.GetType().Name} : {notification.Message} (Thread {Thread.CurrentThread.ManagedThreadId})";
            Message = msg;
            Debug.WriteLine(msg);
        }
    }
}
