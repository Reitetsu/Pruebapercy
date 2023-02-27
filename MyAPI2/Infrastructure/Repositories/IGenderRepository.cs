using Microsoft.EntityFrameworkCore;
using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;
using MyAPI2.Application.Services;

namespace MyAPI2.Infrastructure.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task AddAsync(Gender gender);
        Task UpdateAsync(Gender gender);
        Task RemoveAsync(Gender gender);
        Task<Gender> GetGenderByIdAsync(int id);

    }
}
