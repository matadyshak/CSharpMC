using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        //public Customer GetCustomerById(int id)
        //{
        //    return _customers.FirstOrDefault(c => c.Id == id);
        //}

        public Customer? GetCustomerById(int id)
        {
            Customer? foundCustomer = null;

            foreach (Customer customer in _customers)
            {
                if (customer.Id == id)
                {
                    foundCustomer = customer;
                    break;
                }
            }
            return foundCustomer;
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}