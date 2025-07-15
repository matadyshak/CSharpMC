using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private MongoDBDataAccess db;
        private readonly string tableName = "Contacts";
        private readonly IConfiguration _config;

        public ContactsController(IConfiguration config)
        {
            _config = config;
            db = new MongoDBDataAccess("MongoContactsDB", _config.GetConnectionString("Default"));
        }

        [HttpPost]
        public void CreateOrUpdateRecord(ContactModel contact)
        {
            db.UpsertRecord<ContactModel>(tableName, contact.Id, contact);
        }

        [HttpGet]
        public List<ContactModel> ReadAllRecords()
        {
            return db.ReadRecords<ContactModel>(tableName);
        }

        [HttpPut]
        public void UpdateRecord(ContactModel contact)
        {
            db.UpsertRecord<ContactModel>(tableName, contact.Id, contact);
        }

        [HttpDelete("{id}")]
        public void DeleteRecord(Guid id)
        {
            db.DeleteRecord<ContactModel>(tableName, id);
        }

    }
}