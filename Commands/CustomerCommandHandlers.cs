using reactApp.Domain;

namespace reactApp
{
    public class CustomerCommandHandlers
    {
        public CustomerCommandHandlers () 
        {

        }

        public void Handle(CreateCustomerCommand message) {
            Customer customer = new Customer(message.CustomerId, message.Name);
            // then save.
        }
    }
}