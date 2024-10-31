using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.DTO.Player;
using api.Helpers;
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

        public async Task<List<Player>> GetAllAsync(QueryObject query)
        {
            var players = _context.Players.Include(s => s.Skills).AsQueryable();

            //Filter
            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                players = players.Where(p => p.Name.Contains(query.Name));
            }
            
            if(!string.IsNullOrWhiteSpace(query.Username))
            {
                players = players.Where(p => p.Username.Contains(query.Username));
            }


            //Sort
            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    players = query.IsDecsending ? players.OrderByDescending(p => p.Name) : players.OrderBy(p => p.Name);
                }
            }
            
            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Username", StringComparison.OrdinalIgnoreCase))
                {
                    players = query.IsDecsending ? players.OrderByDescending(p => p.Username) : players.OrderBy(p => p.Username);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            
            //Skip First and grab others
            return await players.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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