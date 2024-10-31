using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Account
{
    public class LoginDto
    {
        [Required]
        public string UserLog { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}