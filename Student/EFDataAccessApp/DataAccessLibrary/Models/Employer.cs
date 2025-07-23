using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Employer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        public string CompanyName { get; set; }
    }
}
