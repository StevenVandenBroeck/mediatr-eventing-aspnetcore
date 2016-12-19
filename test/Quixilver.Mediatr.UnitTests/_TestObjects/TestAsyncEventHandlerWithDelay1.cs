using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Quixilver.Eventing.UnitTests
{
    public class TestAsyncEventHandlerWithDelay1 : IAsyncEventHandler<TestEvent>
    {
        public string Message { get; set; }

        public Task Handle(TestEvent appEvent)
        {
            Thread.Sleep(5000);

            var msg = $"Handled by {this.GetType().Name} : {appEvent.Message} (Thread {Thread.CurrentThread.ManagedThreadId})";
            Message = msg;
            Debug.WriteLine(msg);

            return Task.CompletedTask;
        }
    }
}
