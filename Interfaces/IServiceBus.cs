using System;
using reactApp.Events;

namespace reactApp.Contracts {
    public interface IServiceBus {
        void RegisterHandler<T> (Action<T> handler) where T: Message; 
        void Send<T>(T command) where T: Command;
        void Publish<T> (T @event) where T: Event;
        
    }
}