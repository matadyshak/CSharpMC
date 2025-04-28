using DemoLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            Address.AddressLine1 = (Address.AddressLine1 != null) ? Address.ValidateAddressLine1(Address.AddressLine1) : "";
            Address.AddressLine2 = (Address.AddressLine2 != null) ? Address.ValidateAddressLine2(Address.AddressLine2) : "";
            Address.City         = (Address.City         != null) ? Address.ValidateCity(Address.City) : "";
            Address.State        = (Address.State        != null) ? Address.ValidateState(Address.State) : "";
            Address.Zipcode      = (Address.Zipcode      != null) ? Address.ValidateZipcode(Address.Zipcode) : "";

            AddressAll = $"{Address.AddressLine1} {Address.AddressLine2} {Address.City} {Address.State}  {Address.Zipcode}";

            if (ModelState.IsValid == true)
            {
                return Page();  // Will go right back to the same page
            }

            return RedirectToPage("./Index");
        }
    }
}
