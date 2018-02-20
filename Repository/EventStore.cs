using System.Collections.Generic;
using reactApp.Events;

namespace reactApp.Repository
{
    public interface IEventStore
    {
        void Store(string streamId, Event @event);
        void Store(string streamId, IEnumerable<Event> events);
    }
}