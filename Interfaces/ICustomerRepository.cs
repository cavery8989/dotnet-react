using System.Collections.Generic;
using reactApp.Domain;

namespace reactApp.Contracts {
    public interface ICustomerRepository {
        IEnumerable<Customer> GetAll();
        Customer GetBy(string reference);
        Customer GetById(string id);

        string Test();


    }
}