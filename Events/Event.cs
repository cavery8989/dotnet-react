using System;

namespace reactApp.Events {
    public class Event {
        public Guid Id {get; set;}
        public DateTime OccurredAt = DateTime.UtcNow;
    }
}