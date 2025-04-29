using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMessageWall.Models
{
    public class MessageModel
    {
        [Required]
        [StringLength(10, MinimumLength = 5)]
        [Display(Name = "Really Cool Message")]
        public string Message { get; set; }
    }
}
