using System;
using System.Diagnostics;

namespace Quixilver.Eventing.UnitTests
{
    public class TestExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
