﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class TokenModel
    {
        [Required]
        public string AccessToken { get; set; } = string.Empty;

        [Required]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
