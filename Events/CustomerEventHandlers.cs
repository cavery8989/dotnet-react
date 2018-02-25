using System;
using Microsoft.Extensions.DependencyInjection;

namespace reactApp.Events {
    public class CustomerEventHandlers {
        private readonly ServiceProvider serviceProvider;
        public CustomerEventHandlers (ServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }

        public void Handle(CustomerCreated @event) {
            Console.WriteLine(@event);
        }
    }
}