using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace RazorMessageWall.Pages
{
    public class MessageWallModel : PageModel
    {
        //BindProperty - When you post data you can set this property
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        public List<string> Messages { get; set; } = new List<string>();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Messages.Add(Message);
            return Page();  // Will go right back to the same page
        }
    }
}
