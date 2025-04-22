using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorMessageWall.Pages
{
    public class MessageWallModel : PageModel
    {
        //BindProperty - When you post data you can set this property
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();  // Will go right back to the same page

        }
    }
}
