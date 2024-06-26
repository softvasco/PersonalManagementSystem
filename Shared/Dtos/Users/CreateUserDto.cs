﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Users
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
    }
}