using System.ComponentModel.DataAnnotations;

namespace BlazorServerNameAddressEntry.Models
{
    public class PersonModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
