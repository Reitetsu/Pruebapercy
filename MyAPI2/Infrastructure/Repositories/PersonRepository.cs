using Microsoft.EntityFrameworkCore;
using MyAPI2.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI2.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _dbContext.Persons.Include(p => p.Gender).ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.Persons.Include(p => p.Gender)
                                             .FirstOrDefaultAsync(p => p.Id == id)
                                             ?? throw new Exception($"No se encontró ninguna persona con ID {id}");
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Persons.AnyAsync(p => p.Id == id);
        }

        public async Task AddAsync(Person person)
        {
            await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _dbContext.Persons.Update(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person person)
        {
            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}

