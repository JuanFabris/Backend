using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Skill;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/skill")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepo _skillRepo;
        private readonly IPlayerRepo _playerRepo;
        public SkillController(ISkillRepo skillRepo, IPlayerRepo playerRepo)
        {
            _skillRepo = skillRepo;
            _playerRepo = playerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            var skill = await _skillRepo.GetAllAsync();

            var skillDto = skill.Select(s => s.ToSkillDto());

            return Ok (skill);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById ([FromRoute] int id)
        {
            var skill = await _skillRepo.GetByIdAsync(id);
            if(skill == null)
            {
                return NotFound();
            }

            return Ok (skill.ToSkillDto());
        }

        [HttpPost("{playerId}")]
        public async Task<IActionResult> Create ([FromRoute] int playerId, CreateRequestSkill skillDto)
        {
            if(!await _playerRepo.PlayerExists(playerId))
            {
                return BadRequest("I did not find any player with that ID sir");
            }

            var skillModel = skillDto.ToCreateSkill(playerId);
            await _skillRepo.CreateAsync(skillModel);
            return CreatedAtAction(nameof(GetById), new {id = skillModel.Id}, skillModel.ToSkillDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update ([FromRoute] int id, [FromBody] UpdateSkill updateSkill)
        {
            var skill = await _skillRepo.UpdateAsync(id, updateSkill.ToUpdateSkill());
            if(skill == null)
            {
                return NotFound("No skills to update");
            }
            
            return Ok(skill.ToSkillDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var skill = await _skillRepo.DeleteAsync(id);
            if(skill == null)
            {
                return NotFound("Skill does not exists sir");
            }
            return Ok(skill);
        }
    }
}