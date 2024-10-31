using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.DTO.Player;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly AppDBContext _context;
        public PlayerRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Player> CreateAsync(Player playerModel)
        {
            await _context.Players.AddAsync(playerModel);
            await _context.SaveChangesAsync();
            return playerModel;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.Include(s => s.Skills).ToListAsync(); //List Player
        }

        public async Task<Player?> GetIdByAsync(int id)
        {
            return await _context.Players.Include(s => s.Skills).FirstOrDefaultAsync(p => p.Id == id); //Get unique Ids
        }

        public async Task<Player?> UpdateAsync(int id, UpdatePlayerRequestDto playerDto)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(i => i.Id == id);

            if(existingPlayer == null)
            {
                return null;
            }

            existingPlayer.Username = playerDto.Username;
            existingPlayer.PhoneNumber = playerDto.PhoneNumber;
            existingPlayer.Email = playerDto.Email;

            await _context.SaveChangesAsync();
            return existingPlayer;
        }
        
        public async Task<Player?> DeleteAsync(int id)
        {
           var playerModel = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
           
           if(playerModel == null)
           {
            return null;
           }

           _context.Players.Remove(playerModel);
           await _context.SaveChangesAsync();
           return playerModel;

        }

        public async Task<bool> PlayerExists(int id)
        {
            return await _context.Players.AnyAsync(p => p.Id == id);
        }

    }
}