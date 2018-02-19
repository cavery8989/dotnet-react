using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace reactApp.Controllers {
  

    [Route("api/[controller]")]
    public class CustomerController: Controller {
        private readonly IConfiguration config;
        public CustomerController (IConfiguration config) {
            this.config = config;
        }
        [HttpPost("[action]")]
        public void CreateCustomer () {
            SqlConnection connection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        } 

    }
}