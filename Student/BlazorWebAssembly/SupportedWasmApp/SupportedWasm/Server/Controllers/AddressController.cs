using Microsoft.AspNetCore.Mvc;
using SupportedWasm.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupportedWasm.Server.Controllers
{

    //[Route("api/[controller]")]

    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] AddressModel address)
        {
            _logger.LogInformation("Posted address: {AddressLine1} {AddressLine2} {City} {State}  {Zipcode}",
                address.AddressLine1, address.AddressLine2, address.City, address.State, address.Zipcode);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
