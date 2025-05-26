using Microsoft.AspNetCore.Mvc;
using MyApp.Core.Interfaces;
using MyApp.Core.Models;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _repository.AddCustomer(customer);
            return Ok("Customer added successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }
    }
}
