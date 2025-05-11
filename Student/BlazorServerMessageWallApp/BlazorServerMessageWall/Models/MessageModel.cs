using System.ComponentModel.DataAnnotations;

namespace BlazorServerMessageWall.Models;

public class MessageModel
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Message { get; set; }
}
