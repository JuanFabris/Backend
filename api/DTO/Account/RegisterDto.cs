using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserLog { get; set; }
        
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        
        [Required]
        public string? Password { get; set; }
    }
}