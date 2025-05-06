using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMiniProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILogger _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        // POST: api/Person
        [HttpPost]
        public void Post([FromBody] PersonModel data)
        {
            _logger.LogInformation("The person was logged as {Person}", data);
        }
    }
}
