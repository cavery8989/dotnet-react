using System;

namespace reactApp.Domain {
    public abstract class AggregateRoot {

        private readonly Guid Id;
        private readonly int version;
        public abstract void Apply ();


    }
}