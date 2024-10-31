using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Player;
using api.Models;

namespace api.Mappers
{
    public static class PlayerMapper
    {
        public static PlayerDto ToPlayerDto (this Player playerModel)
        {
            return new PlayerDto
            {
                Id = playerModel.Id,
                Name = playerModel.Name,
                Surname = playerModel.Surname,
                Username = playerModel.Username,
                PhoneNumber = playerModel.PhoneNumber,
                Email = playerModel.Email,
                Skills = playerModel.Skills.Select(s => s.ToSkillDto()).ToList()
            };

        }

        public static Player FromDtoToPlayer (this CreateRequestPlayerDto playerDto)
        {
            return new Player
            {
                Name = playerDto.Name,
                Surname = playerDto.Surname,
                Username = playerDto.Username,
                PhoneNumber = playerDto.PhoneNumber,
                Email = playerDto.Email,
            };
        }
    }
}