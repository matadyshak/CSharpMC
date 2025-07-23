using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
