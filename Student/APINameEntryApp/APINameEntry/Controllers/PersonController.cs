using APINameEntry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINameEntry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        // GET: api/Person?FirstName=Michael&LastName=Tadyshak
        [HttpGet]
        public IEnumerable<string> Get(string firstName, string lastName)
        {
            List<string> output = new List<string>();
            PersonModel person = new PersonModel();
            person.FirstName = firstName;
            person.LastName = lastName;
            output.Add($"Hello, {person.FirstName} {person.LastName}! Have a blessed day!");
            return output;

            //Postman setting: GET https://localhost:5001/api/person?firstname=Fred&lastname=Mertz
            // Only Fred and Mertz are case sensitive
            // Variable names in URL must match parameter names firstname, lastname except for case or null gets passed in
            // URL parameters can be in any order
            // GET works in browser of Postman
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Person
        [HttpPost]
        public void Post([FromBody] PersonModel person)
        {
            _logger.LogInformation("Our message was {firstName} {lastName} {IsActive}", person.FirstName, person.LastName, person.IsActive);

            // Postman settings:
            // POST  https://localhost:5001/api/person
            // 
            //
            // {"FirstName":"Michael", "LastName":"Tadyshak", "IsActive":true}
            // IsActive = false if not included in Postman body
            // Logger: Our message was Michael Tadyshak True
            // This has to be done by Postman or need to have a UI with submit button to cause a POST
            // Using array brackets [] with only one array entry causes an error in Postman
            // [FromBody] means take the data from the body and not from URL parameters
            // Nothing returned by POST command
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
