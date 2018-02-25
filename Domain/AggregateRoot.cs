using System;
using System.Collections.Generic;
using reactApp.Events;

namespace reactApp.Domain {
    public abstract class AggregateRoot {

        private readonly List<Event> changes = new List<Event>();
        public abstract Guid Id {get;}
        public int Version {get; internal set;}

        public abstract void Apply (Event @event);

        protected void AppendChange(Event @event) {
            this.changes.Add(@event);
        }

        public IEnumerable<Event> GetChanges () {
            return this.changes.Count > 0 ? this.changes : null;
        }

    }
}