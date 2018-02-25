using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using reactApp.Contracts;
using reactApp.Domain;
using reactApp.Events;

namespace reactApp.Repository
{
    public interface IEventStore
    {
        void Store(string streamId, Event @event);

        void SaveEvents(AggregateRoot root, int expectedVersion);
        void Store(string streamId, IEnumerable<Event> events);
    }

    public class EventStore: IEventStore {

        private readonly IServiceBus bus;
        public EventStore (IServiceBus bus) {
            this.bus = bus;
        }

        private struct EventDescriptor {
            public readonly Guid Id;
            public readonly string EventData;
            public readonly string EventType;
            public readonly int Version;

            public EventDescriptor (Guid id, Event eventData, int version) {
                this.Id = id;
                this.EventType = eventData.GetType().Name;
                this.EventData = JsonConvert.SerializeObject(eventData);
                this.Version = version;
            }
        }

        public void SaveEvents(AggregateRoot root, int expectedVersion)
        {
            var events = root.GetChanges();
            int version = expectedVersion == -1 ? 0: expectedVersion;
            foreach (var e in events)
            {
                version ++;
                EventDescriptor ed = new EventDescriptor(root.Id, e, version);
            }

            throw new System.NotImplementedException();
        }

        public void Store(string streamId, Event @event)
        {
            throw new System.NotImplementedException();
        }

        public void Store(string streamId, IEnumerable<Event> events)
        {
            throw new System.NotImplementedException();
        }
    }
}