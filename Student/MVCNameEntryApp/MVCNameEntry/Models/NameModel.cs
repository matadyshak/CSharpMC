using System.ComponentModel.DataAnnotations;

namespace MVCNameEntry.Models
{
    public class NameModel
    {
        [Required]
        [StringLength(40, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
