using System;
using reactApp.Events;

namespace reactApp.Domain {
    public class Customer : AggregateRoot
    {
        private bool activated;
        private Guid _id;
        private string name;

        public Customer (Guid id, string name) 
        {
            this._id = id;
            this.name = name;
        }

        public override Guid Id 
        {
            get {
                return _id;
            }
        }

        public override void Apply(Event @event)
        {
            throw new System.NotImplementedException();
        }
    }
}