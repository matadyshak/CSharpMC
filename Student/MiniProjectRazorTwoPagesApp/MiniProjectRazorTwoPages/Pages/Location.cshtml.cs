using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ValidateInSetterLibrary;

namespace MiniProjectRazorTwoPages.Pages
{
    public class LocationModel : PageModel
    {
        [BindProperty]
        public AddressModel Address { get; set; } = new AddressModel();

        public string AddressAll { get; set; }

        public void OnGet()
        {
            AddressAll = "";
        }

        public IActionResult OnPost()
        {
            //Need validate methods to run first before setters so they can eliminate illegal chars
            //But the setters run first and if any bad chars found sets the value to ""
            //That has now been fixed by calling the validate functions from the setters

            AddressAll = $"{Address.AddressLine1} {Address.AddressLine2} {Address.City} {Address.State}  {Address.Zipcode}";

            if (ModelState.IsValid == true)
            {
                return Page();  // Will go right back to the same page
            }

            return RedirectToPage("./Index");
        }
    }
}
