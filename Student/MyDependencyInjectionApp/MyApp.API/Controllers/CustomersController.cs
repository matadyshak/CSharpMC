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
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ICustomerRepository repository, ILogger<CustomersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _repository.AddCustomer(customer);
            _logger.LogInformation("Customer with ID {id} {name} added successfully!", customer.Id, customer.Name);
            return Ok("Customer added successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _repository.GetCustomerById(id);
            if (customer == null)
            {
                _logger.LogInformation("Customer with ID {Id} not found.", id);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("Customer with ID {id} is {name}", customer.Id, customer.Name);
                return Ok(customer);
            }
        }
    }
}
