using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Skill
{
    public class UpdateSkill
    {   
        
        [Range(1,100)]
        public int Speed { get; set; }
        
        [Range(1,100)]
        public int Attack { get; set; }
        
        [Range(1,100)]
        public int Defense { get; set; }
        
        [Range(1,100)]
        public int Strength { get; set; }
        
        [Range(1,100)]
        public int Dribbling { get; set; }
        
    }
}