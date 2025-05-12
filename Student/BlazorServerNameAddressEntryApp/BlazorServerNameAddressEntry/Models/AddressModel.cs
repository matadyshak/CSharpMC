using System.ComponentModel.DataAnnotations;

namespace BlazorServerNameAddressEntry.Models
{
    public class AddressModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Zipcode { get; set; }
    }
}
