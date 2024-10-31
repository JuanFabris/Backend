using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.DTO.Player;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPlayerRepo _playerRepo;

        public PlayerController(AppDBContext context, IPlayerRepo playerRepo)
        {
            _context = context;
            _playerRepo = playerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await _playerRepo.GetAllAsync();

            var playerDto = player.Select(x => x.ToPlayerDto());

            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await _playerRepo.GetIdByAsync(id);
            
            if(player == null)
            {
                return NotFound("No player has been found");
            }

            return Ok(player.ToPlayerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRequestPlayerDto playerDto)
        {
            var playerModel = playerDto.FromDtoToPlayer();
            await _playerRepo.CreateAsync(playerModel);
            return CreatedAtAction(nameof(GetById), new { id = playerModel.Id}, playerModel.ToPlayerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlayerRequestDto updateDto)
        {
            var playerModel = await _playerRepo.UpdateAsync(id, updateDto);
            
            if (playerModel == null)
            {
                return NotFound();
            }

            return Ok(playerModel.ToPlayerDto());
        }

        [HttpDelete]
        [Route("({id})")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            var playerModel = await _playerRepo.DeleteAsync(id);
            
            if(playerModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}