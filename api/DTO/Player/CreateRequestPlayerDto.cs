using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Player
{
    public class CreateRequestPlayerDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Surname { get; set; } = string.Empty;
        
        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only digits.")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}