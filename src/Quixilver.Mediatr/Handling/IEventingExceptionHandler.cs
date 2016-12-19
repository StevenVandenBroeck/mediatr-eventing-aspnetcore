using System;

namespace Quixilver.Eventing
{
    public interface IEventingExceptionHandler
    {
        void Handle(EventingException ex);
    }
}
