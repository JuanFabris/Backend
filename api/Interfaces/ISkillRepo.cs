using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.Skill;
using api.Models;

namespace api.Interfaces
{
    public interface ISkillRepo
    {
        public Task<List<Skill>> GetAllAsync ();
        public Task<Skill?> GetByIdAsync (int id);
        public Task<Skill> CreateAsync(Skill skillModel);
        public Task<Skill?> UpdateAsync (int id, Skill skillModel);
        public Task<Skill?> DeleteAsync (int id);

    }
}