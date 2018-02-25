using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using reactApp.Contracts;
using reactApp.Domain;

namespace reactApp.Repository {
    public class CustomerRepository : Repository, ICustomerRepository
    {
        private readonly IEventStore storage;
        public CustomerRepository(IConfiguration config, IEventStore storage) : base(config){
            this.storage = storage;
        }
        
        public void Save (Customer customer) {
            this.storage.SaveEvents(customer, -1);
        } 

        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetBy(string reference)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public string Test() {

            SqlConnection conn = new SqlConnection(this.connectionString);

            conn.Open();

            string command = "SELECT * FROM [Events]";
            using(SqlCommand cmd = new SqlCommand(command, conn)){
                using(SqlDataReader reader = cmd.ExecuteReader()){
                    if(reader != null) {
                        while(reader.Read()) {
                            reader.GetValue(1);
                        }
                    }
                }
            }

            return "haats";

        }
    }
}