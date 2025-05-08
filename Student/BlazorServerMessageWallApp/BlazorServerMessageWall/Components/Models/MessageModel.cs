using System.ComponentModel.DataAnnotations;

namespace BlazorServerMessageWall.Components.Models;

public class MessageModel
{
    [Required]
    [StringLength(10, MinimumLength = 5)]
    //    public string? Message { get; set; }
    public string Message { get; set; }
}