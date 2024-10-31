using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Player
    {
        public int Id { get; set; }
        
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

        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
}
