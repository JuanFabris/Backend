using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Database;
using api.DTO.Skill;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SkillRepo : ISkillRepo
    {
        private readonly AppDBContext _context;
        public SkillRepo(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Skill> CreateAsync(Skill skillModel)
        {
            await _context.AddAsync(skillModel);
            await _context.SaveChangesAsync();
            return skillModel; 
        }

        public async Task<Skill?> DeleteAsync(int id)
        {
            var skillModel = await _context.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if(skillModel == null)
            {
                return null;
            }
            _context.Skills.Remove(skillModel);
            await _context.SaveChangesAsync();
            return skillModel;
        }

        public async Task<List<Skill>> GetAllAsync ()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync (int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<Skill?> UpdateAsync(int id, Skill skillModel)
        {
            var existingSkill = await _context.Skills.FindAsync(id);

            if(existingSkill == null)
            {
                return null;
            }

            existingSkill.Attack = skillModel.Attack;
            existingSkill.Defense = skillModel.Defense;
            existingSkill.Dribbling = skillModel.Dribbling;
            existingSkill.Speed = skillModel.Speed;
            existingSkill.Strength = skillModel.Strength;

            await _context.SaveChangesAsync();
            
            return existingSkill;
        }
    }
}