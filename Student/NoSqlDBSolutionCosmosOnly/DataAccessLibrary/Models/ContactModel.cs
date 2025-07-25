﻿using Newtonsoft.Json;

namespace DataAccessLibrary.Models
{
    public class ContactModel : IPartitionedDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<EmailAddressModel> EmailAddresses { get; set; } = new List<EmailAddressModel>();
        public List<PhoneNumberModel> PhoneNumbers { get; set; } = new List<PhoneNumberModel>();

        [JsonIgnore]
        public string PartitionKey => LastName;
    }
}