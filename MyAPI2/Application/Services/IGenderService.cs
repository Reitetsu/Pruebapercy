using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;

namespace MyAPI2.Application.Services
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender> GetGenderByIdAsync(int id);
        Task<Gender> CreateGenderAsync(Gender gender);
        Task UpdateGenderAsync(int id, Gender gender);
        Task DeleteGenderAsync(int id);
        Task<bool> GenderExistsAsync(int id);
    }
}
