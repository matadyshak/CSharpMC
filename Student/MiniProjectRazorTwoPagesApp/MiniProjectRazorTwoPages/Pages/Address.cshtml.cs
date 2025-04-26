using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniProjectRazorTwoPages.Pages
{
    public class AddressModel : PageModel
    {
        [BindProperty]
        public string AddressLine1 { get; set; }

        [BindProperty]
        public string AddressLine2 { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string State { get; set; }

        [BindProperty]
        public string Zipcode { get; set; }

        public string AddressAll { get; set; }

        public void OnGet()
        {
            AddressAll = "";
        }

        public IActionResult OnPost()
        {
            AddressAll = $"Address: {AddressLine1} {AddressLine2} {City} {State}  {Zipcode}";
            return Page();  // Will go right back to the same page
        }
    }
}
