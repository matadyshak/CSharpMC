using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniProjectAPINameAddress.Models;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniProjectAPINameAddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger=logger;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] PersonModel person)
        {
            _logger.LogInformation("Posted Name: {FirstName} {LastName} {IsActive}", person.FirstName, person.LastName, person.IsActive);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
