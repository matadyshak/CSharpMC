using ApiDBUI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace ApiDBUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGet()
        {
            // Not needed now that there is a web-based user interface !!!
            // await CreateContact();
            // await GetAllContacts();
        }

        private async Task CreateContact()
        {
            ContactModel contact = new ContactModel
            {
                FirstName = "Tim",
                LastName = "Corey"
            };

            contact.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tim@iamtimcorey.com" });
            contact.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
            contact.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
            contact.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1234" });

            var _client = _httpClientFactory.CreateClient();
            var reponse = await _client.PostAsync(
                "https://localhost:44374/api/Contacts",
                new StringContent(JsonSerializer.Serialize(contact), Encoding.UTF8, "application/json"));
        }

        private async Task GetAllContacts()
        {
            var _client = _httpClientFactory.CreateClient();
            var response = await _client.GetAsync("https://localhost:44374/api/Contacts");

            List<ContactModel> contacts;

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string responseText = await response.Content.ReadAsStringAsync();
                contacts = JsonSerializer.Deserialize<List<ContactModel>>(responseText, options);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
