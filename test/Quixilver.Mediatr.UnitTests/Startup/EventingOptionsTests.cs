using System;
using Quixilver.Eventing.Handling;
using Xunit;

namespace Quixilver.Eventing.UnitTests.Startup
{
    public class EventingOptionsTests
    {
        [Fact]
        void ExceptionHandlerTypeIsInitialized()
        {
            var options = new EventingOptions();
            Assert.Equal(typeof(DefaultEventingExceptionHandler), options.ExceptionHandlerType);
        }

        [Fact]
        void ExceptionHandlerTypeIsRegistered()
        {
            var options = new EventingOptions();
            options.RegisterExceptionHandler<TestExceptionHandler>();
            Assert.Equal(typeof(TestExceptionHandler), options.ExceptionHandlerType);
        }
    }
}
