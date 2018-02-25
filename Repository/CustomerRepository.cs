using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
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
            var connString = "Host=localhost;Username=postgres;Password=password1;Database=works-db";
            NpgsqlConnection conn = new NpgsqlConnection(connString);

            conn.Open();

            string command = "SELECT * FROM [Events]";
            using(NpgsqlDataAdapter da = new NpgsqlDataAdapter(command, conn)){
                    var ds = new DataSet();
                    da.Fill(ds);
            }

            return "haats";

        }
    }
}