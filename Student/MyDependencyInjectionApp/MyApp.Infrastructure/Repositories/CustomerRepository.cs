using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        // Iterates thru collection _customers
        // c is the current entry
        // c.Id is the Id of the current entry
        // c.Id is compared to the id you are looking for
        // The lambda expression returns the first matching element then stops
        // If not found returns null

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }

        //public Customer? GetCustomerById(int id)
        //{
        //    Customer? foundCustomer = null;
        //
        //    foreach (Customer customer in _customers)
        //    {
        //        if (customer.Id == id)
        //        {
        //            foundCustomer = customer;
        //            break;
        //        }
        //    }
        //    return foundCustomer;
        //}

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}