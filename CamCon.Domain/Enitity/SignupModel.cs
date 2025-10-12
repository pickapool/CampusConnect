﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamCon.Domain.Enitity
{
    public class SignupModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;

        public ProfileInfo? ProfileInformation { get; set; }
    }
}
