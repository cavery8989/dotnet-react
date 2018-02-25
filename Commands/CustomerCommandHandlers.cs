using Microsoft.Extensions.DependencyInjection;
using reactApp.Contracts;
using reactApp.Domain;

namespace reactApp
{
    public class CustomerCommandHandlers
    {
        private readonly ServiceProvider serviceProvider;
        public CustomerCommandHandlers (ServiceProvider serviceProvider) 
        {
            this.serviceProvider = serviceProvider;
        }

        public void Handle(CreateCustomerCommand message) {
            Customer customer = new Customer(message.CustomerId, message.Name);
            
            var customerRepo = serviceProvider.GetService<ICustomerRepository>();
            customerRepo.Save(customer);
            
            
            // then save.
        }
    }
}