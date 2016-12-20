using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Quixilver.Eventing.UnitTests.Publishing
{
    public class EventPublishAsyncTests
    {
        [Fact]
        void HandlersAreCalled()
        {
            var handler1 = new TestAsyncEventHandler1();
            var handler2 = new TestAsyncEventHandler2();
            var handler3 = new TestAsyncEventHandlerWithDelay1();

            var services = new ServiceCollection();
            services.AddOptions();
            services.AddEventing(opt => {
                opt.RegisterAsyncEventHandler<TestEvent>(handler1);
                opt.RegisterAsyncEventHandler<TestEvent>(handler2);
                opt.RegisterAsyncEventHandler<TestEvent>(handler3);
            });

            Assert.Null(handler1.Message);
            Assert.Null(handler2.Message);
            Assert.Null(handler3.Message);

            var serviceProvider = services.BuildServiceProvider();
            var publisher = serviceProvider.GetService<IEventPublisher>();

            var testEvent = new TestEvent() { Message = $"Hello from {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            publisher.PublishAsync(testEvent);

            // give a little delay for the tasks to start
            Thread.Sleep(2000);

            Assert.Contains(testEvent.Message, handler1.Message);
            Assert.Contains(testEvent.Message, handler2.Message);
            Assert.Null(handler3.Message);      // task should not be finished yet
        }

        [Fact]
        void HandlersAreCalledWhileWaiting()
        {
            var handler1 = new TestAsyncEventHandler1();
            var handler2 = new TestAsyncEventHandler2();
            var handler3 = new TestAsyncEventHandlerWithDelay1();

            var services = new ServiceCollection();
            services.AddOptions();
            services.AddEventing(opt => {
                opt.RegisterAsyncEventHandler<TestEvent>(handler1);
                opt.RegisterAsyncEventHandler<TestEvent>(handler2);
                opt.RegisterAsyncEventHandler<TestEvent>(handler3);
            });

            Assert.Null(handler1.Message);
            Assert.Null(handler2.Message);
            Assert.Null(handler3.Message);

            var serviceProvider = services.BuildServiceProvider();
            var publisher = serviceProvider.GetService<IEventPublisher>();

            var testEvent = new TestEvent() { Message = $"Hello from {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            publisher.PublishAsync(testEvent);

            // Wait for the tasks to finish
            Thread.Sleep(6000);

            Assert.Contains(testEvent.Message, handler1.Message);
            Assert.Contains(testEvent.Message, handler2.Message);
            Assert.Contains(testEvent.Message, handler3.Message);
        }

        [Fact]
        void ReturnsImmediately()
        {
            var delayedHandler = new TestAsyncEventHandlerWithDelay1();

            var services = new ServiceCollection();
            services.AddOptions();
            services.AddEventing( opt => opt.RegisterAsyncEventHandler<TestEvent>(delayedHandler));

            Assert.Null(delayedHandler.Message);

            var serviceProvider = services.BuildServiceProvider();
            var publisher = serviceProvider.GetService<IEventPublisher>();

            var testEvent = new TestEvent() { Message = $"Hello from {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            publisher.PublishAsync(testEvent);

            Assert.Null(delayedHandler.Message);      // task should not be finished yet

            Thread.Sleep(6000);

            Assert.Contains(testEvent.Message, delayedHandler.Message);     // should be finished now
        }

        [Fact]
        async Task ResultIsAwaited()
        {
            var delayedHandler = new TestAsyncEventHandlerWithDelay1();

            var services = new ServiceCollection();
            services.AddOptions();
            services.AddEventing(opt => opt.RegisterAsyncEventHandler<TestEvent>(delayedHandler));


            Assert.Null(delayedHandler.Message);

            var serviceProvider = services.BuildServiceProvider();
            var publisher = serviceProvider.GetService<IEventPublisher>();

            var testEvent = new TestEvent() { Message = $"Hello from {this.GetType().Name} (Thread {Thread.CurrentThread.ManagedThreadId})" };
            await publisher.PublishAsync(testEvent);

            Assert.Contains(testEvent.Message, delayedHandler.Message);
        }
    }
}
