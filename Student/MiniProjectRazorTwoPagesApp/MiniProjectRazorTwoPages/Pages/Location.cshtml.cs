using DemoLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiniProjectRazorTwoPages.Pages
{
    public class LocationModel : PageModel
    {
        [BindProperty]
        public AddressModel Address { get; set; }

        public string AddressAll { get; set; }

        public void OnGet()
        {
            AddressAll = "";
        }

        public IActionResult OnPost()
        {
            Address.AddressLine1 = (Address.AddressLine1 != null) ? Address.ValidateAddressLine1(Address.AddressLine1) : "";
            Address.AddressLine2 = (Address.AddressLine2 != null) ? Address.ValidateAddressLine2(Address.AddressLine2) : "";
            Address.City         = (Address.City         != null) ? Address.ValidateCity(Address.City) : "";
            Address.State        = (Address.State        != null) ? Address.ValidateState(Address.State) : "";
            Address.Zipcode      = (Address.Zipcode      != null) ? Address.ValidateZipcode(Address.Zipcode) : "";

            AddressAll = $"Address: {Address.AddressLine1} {Address.AddressLine2} {Address.City} {Address.State}  {Address.Zipcode}";

            if (ModelState.IsValid == false)
            {
                return Page();  // Will go right back to the same page
            }

            return RedirectToPage("./Index");
        }
    }
}
