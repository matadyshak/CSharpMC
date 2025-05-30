﻿using System.ComponentModel.DataAnnotations;

namespace MiniProjectAPINameAddress.Models
{
    public class PersonModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
