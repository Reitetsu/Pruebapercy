using Microsoft.EntityFrameworkCore;
using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;
using MyAPI2.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI2.Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _context;

        public GenderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<Gender> GetByIdAsync(int id)
        {
            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
            {
                throw new ArgumentException($"No se encontró el género con el Id {id}");
            }
            return gender;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Genders.AnyAsync(g => g.Id == id);
        }

        public async Task AddAsync(Gender gender)
        {
            await _context.Genders.AddAsync(gender);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gender gender)
        {
            _context.Entry(gender).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Gender gender)
        {
            _context.Genders.Remove(gender);
            await _context.SaveChangesAsync();
        }

        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            return await _context.Genders.FindAsync(id);
        }
    }
}

