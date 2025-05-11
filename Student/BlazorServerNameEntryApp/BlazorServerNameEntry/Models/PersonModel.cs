using System.ComponentModel.DataAnnotations;

namespace BlazorServerNameEntry.Models;
public class PersonModel
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string LastName { get; set; }
}
