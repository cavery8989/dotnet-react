using Microsoft.Extensions.Configuration;

namespace reactApp.Repository {
    public abstract class Repository {
        public string connectionString {get; set;}

        public Repository (IConfiguration config) {
            this.connectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}