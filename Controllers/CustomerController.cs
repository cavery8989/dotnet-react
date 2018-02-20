using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using reactApp.Contracts;
using reactApp.Repository;

namespace reactApp.Controllers {
  

    [Route("api/[controller]")]
    public class CustomerController: Controller {
        private readonly IConfiguration config;
        private readonly IServiceBus bus;
        public CustomerController (IConfiguration config, IServiceBus bus) {
            this.config = config;
            this.bus = bus;
        }
        [HttpPost("[action]")]
        public IActionResult CreateCustomer () {
            bus.Send(new CreateCustomerCommand(Guid.NewGuid(), "Sian"));
            return Ok("got to create customer ");
        } 

    }
}