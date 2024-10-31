using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Skill
{
    public class CreateRequestSkill
    {
        public int Speed { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Strength { get; set; }
        public int Dribbling { get; set; }

    }
}