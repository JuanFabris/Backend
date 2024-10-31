using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Player;
using api.Models;

namespace api.Interfaces
{
    public interface IPlayerRepo
    {
        Task<List<Player>> GetAllAsync ();
        Task<Player?> GetIdByAsync (int id);
        Task<Player> CreateAsync (Player playerModel);
        Task<Player?> UpdateAsync (int id, UpdatePlayerRequestDto playerDto);
        Task<Player?> DeleteAsync (int id);
        Task<bool> PlayerExists (int id);
    }
}