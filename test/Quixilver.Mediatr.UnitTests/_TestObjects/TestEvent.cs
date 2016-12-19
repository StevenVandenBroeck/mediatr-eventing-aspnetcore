using System;
using MediatR;

namespace Quixilver.Eventing.UnitTests
{
    public class TestEvent : AppEvent
    {
        public string Message { get; set; }
    }
}
