﻿using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public  class LoginModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}