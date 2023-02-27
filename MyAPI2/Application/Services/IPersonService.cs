using Microsoft.EntityFrameworkCore;
using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;
using MyAPI2.Application.Services;

namespace MyAPI2.Application.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllPeopleAsync();
        Task<PersonDto> GetPersonByIdAsync(int id);
        Task<int> CreatePersonAsync(PersonDto personDto);
        Task UpdatePersonAsync(int id, PersonDto personDto);
        Task DeletePersonAsync(int id);
        Task<bool> PersonExistsAsync(int id);
    }
}
