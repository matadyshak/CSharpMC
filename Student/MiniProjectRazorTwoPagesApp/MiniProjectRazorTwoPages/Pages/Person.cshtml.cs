using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniProjectRazorTwoPages.Pages
{
    public class PersonModel : PageModel
    {
        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public string Greeting { get; set; }

        public void OnGet()
        {
            Greeting = "";
        }

        public IActionResult OnPost()
        {
            Greeting = $"Hello, {FirstName} {LastName}!";
            return Page();  // Will go right back to the same page
        }
    }
}
