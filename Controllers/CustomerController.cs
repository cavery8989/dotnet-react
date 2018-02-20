using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using reactApp.Contracts;
using reactApp.Repository;

namespace reactApp.Controllers {
  

    [Route("api/[controller]")]
    public class CustomerController: Controller {
        private readonly IConfiguration config;
        private readonly ICustomerRepository customerRepository;
        public CustomerController (IConfiguration config, ICustomerRepository customerRepo) {
            this.config = config;
            this.customerRepository = customerRepo;
        }
        [HttpPost("[action]")]
        public IActionResult CreateCustomer () {
            string x = this.customerRepository.Test();
            return Ok("got to create customer " + x);
        } 

    }
}