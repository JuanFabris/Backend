using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Skill
{
    public class CreateRequestSkill
    {
        [Required]
        [Range(1,100)]
        public int Speed { get; set; }
        
        [Required]
        [Range(1,100)]
        public int Attack { get; set; }
        
        [Required]
        [Range(1,100)]
        public int Defense { get; set; }

        [Required]
        [Range(1,100)]
        public int Strength { get; set; }

        [Required]
        [Range(1,100)]
        public int Dribbling { get; set; }

    }
}