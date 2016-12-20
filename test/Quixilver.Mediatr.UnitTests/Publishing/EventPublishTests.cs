using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Quixilver.Eventing.UnitTests.Publishing
{
    public class EventPublishTests
    {
        [Fact]
        void HandlersAreCalled()
        {
            var handler1 = new TestEventHandler1();
            var handler2 = new TestEventHandler2();

            var services = new ServiceCollection();
            services.AddOptions();
            services.AddEventing(opt => {
                opt.RegisterEventHandler(handler1);
                opt.RegisterEventHandler(handler2);
            });
            
            Assert.Null(handler1.Message);
            Assert.Null(handler2.Message);

            var serviceProvider = services.BuildServiceProvider();
            var publisher = serviceProvider.GetService<IEventPublisher>();

            var appEvent = new TestEvent() { Message = "Hello from test" };
            publisher.Publish(appEvent);

            Assert.Contains(appEvent.Message, handler1.Message);
            Assert.Contains(appEvent.Message, handler2.Message);
        }
    }
}
