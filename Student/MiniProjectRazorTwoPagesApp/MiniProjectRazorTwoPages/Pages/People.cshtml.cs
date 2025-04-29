using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValidateInSetterLibrary;

namespace MiniProjectRazorTwoPages.Pages
{
    public class PeopleModel : PageModel
    {
        [BindProperty]
        public PersonModel Person { get; set; } = new PersonModel();
        public string Greeting { get; set; }
        public void OnGet()
        {
            Greeting = "";
        }

        public IActionResult OnPost()
        {
            Person.FirstName = (Person.FirstName != null) ? Person.ValidateName(Person.FirstName) : "";
            Person.LastName = (Person.LastName != null) ? Person.ValidateName(Person.LastName) : "";

            Greeting = $"Hello, {Person.FirstName} {Person.LastName}!";
            return Page();  // Will go right back to the same page
        }
    }
}
