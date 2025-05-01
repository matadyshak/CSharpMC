using System.ComponentModel.DataAnnotations;

namespace MVCMessageWall.Models
{
    public class MessageModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Really Cool Message")]
        public string Message { get; set; }
    }
}
