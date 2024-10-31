using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.DTO.Player;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query) //filtering e.g. by name..username..
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var player = await _playerRepo.GetAllAsync(query);

            var playerDto = player.Select(x => x.ToPlayerDto());

            return Ok(player);
        }

        [HttpGet("{id:int}")] //Contrains for Route
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerModel = playerDto.FromDtoToPlayer();
            await _playerRepo.CreateAsync(playerModel);
            return CreatedAtAction(nameof(GetById), new { id = playerModel.Id}, playerModel.ToPlayerDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePlayerRequestDto updateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerModel = await _playerRepo.UpdateAsync(id, updateDto);
            
            if (playerModel == null)
            {
                return NotFound();
            }

            return Ok(playerModel.ToPlayerDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerModel = await _playerRepo.DeleteAsync(id);
            
            if(playerModel == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

    }
}