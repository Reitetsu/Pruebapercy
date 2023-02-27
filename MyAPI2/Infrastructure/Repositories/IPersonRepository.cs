using MyAPI2.Domain.Entities;

namespace MyAPI2.Infrastructure.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
        Task<bool> ExistsAsync(int id);
    }
}
