using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public List<Address> Addresses { get; set; } = new List<Address>();

        [Required]
        public List<Employer> Employers { get; set; } = new List<Employer>();
    }
}
