using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Skill;
using api.Models;

namespace api.Mappers
{
    public static class SkillMapper
    {
        public static SkillDto ToSkillDto (this Skill skillModel)
        {
            return new SkillDto
            {
                Id = skillModel.Id,
                Speed = skillModel.Speed,
                Attack = skillModel.Attack,
                Defense = skillModel.Defense,
                Strength = skillModel.Strength,
                Dribbling = skillModel.Dribbling,
                PlayerId = skillModel.PlayerId
            };
        }

        public static Skill ToCreateSkill (this CreateRequestSkill skillDto, int PlayerId)
        {
            return new Skill
            {
                Speed = skillDto.Speed,
                Attack = skillDto.Attack,
                Defense = skillDto.Defense,
                Strength = skillDto.Strength,
                Dribbling = skillDto.Dribbling,
                PlayerId = PlayerId
            };
        }

        public static Skill ToUpdateSkill (this UpdateSkill skillDto)
        {
            return new Skill
            {
                Speed = skillDto.Speed,
                Attack = skillDto.Attack,
                Defense = skillDto.Defense,
                Strength = skillDto.Strength,
                Dribbling = skillDto.Dribbling,
            };
        }
    }
}