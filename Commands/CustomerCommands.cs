using System;
using reactApp.Contracts;

namespace reactApp
{
    public class Command: Message 
    {

    }

    public class CreateCustomerCommand: Command {
        public readonly Guid CustomerId;
        public readonly string Name;

        public CreateCustomerCommand (Guid customerId, string name) {
            this.CustomerId = customerId;
            this.Name = name;
        }
    }
}