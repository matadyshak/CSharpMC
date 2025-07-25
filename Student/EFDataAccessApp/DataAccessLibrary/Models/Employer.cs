using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Employer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; } // Foreign key to Person
        [Required]
        public Person Person { get; set; } // Navigation property
        public string CompanyName { get; set; }
    }
}
