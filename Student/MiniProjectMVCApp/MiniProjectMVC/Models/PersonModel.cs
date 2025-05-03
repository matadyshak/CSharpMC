using System.ComponentModel.DataAnnotations;

namespace MiniProjectMVCContactData.Models
{
    public class PersonModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsValid { get; set; }
    }
}
