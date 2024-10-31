using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Skill
{
    public class SkillDto
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Strength { get; set; }
        public int Dribbling { get; set; }
        public int? PlayerId { get; set; }
    }
}