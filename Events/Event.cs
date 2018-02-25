using System;
using reactApp.Contracts;

namespace reactApp.Events {
    public class Event: Message {
        public int version;
    }

    public class CustomerCreated : Event {
        public readonly Guid Id;
        public readonly string Name;
        public CustomerCreated (Guid id, string name) {
            Id = id;
            Name = name;
        }
    }
}