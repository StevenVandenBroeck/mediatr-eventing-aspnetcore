using System;
using System.Diagnostics;

namespace Quixilver.Eventing.Handling
{
    public class DefaultEventingExceptionHandler : IEventingExceptionHandler
    {
        public void Handle(EventingException ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
