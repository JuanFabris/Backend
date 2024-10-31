using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Player
{
    public class UpdatePlayerRequestDto
    {   
        [Required]
        [MinLength(5, ErrorMessage = "At least 5 char")]
        [MaxLength(15, ErrorMessage = "Max 15 char")]
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