using Microsoft.Extensions.Configuration;

namespace reactApp.Repository {
    public abstract class Repository {
        protected string connectionString {get; set;}

        public Repository (IConfiguration config) {
            this.connectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}