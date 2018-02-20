using System;
using reactApp.Contracts;

namespace reactApp.Events {
    public class Event: Message {
        public Guid Id {get; set;}
        public DateTime OccurredAt = DateTime.UtcNow;
    }
}