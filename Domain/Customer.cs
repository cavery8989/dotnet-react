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
            ApplyChange(new CustomerCreated(id, name));
        }

        private void ApplyChange (Event @event) {
            ApplyChange(@event, true);
        }

        private void ApplyChange (Event @event, bool isNew) {
            Apply(@event);
            AppendChange(@event);
        }

        public override Guid Id 
        {
            get {
                return _id;
            }
        }

        public override void Apply(Event @event)
        {
            if(@event is CustomerCreated){
                Apply(@event as CustomerCreated);
            }
        }

        private void Apply(CustomerCreated @event) {
            this._id = @event.Id;
            this.name = @event.Name;
        }
    }
}