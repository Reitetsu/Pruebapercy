using AutoMapper;
using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;
using MyAPI2.Infrastructure.Repositories;

namespace MyAPI2.Application.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _genderRepository.GetAllAsync();
        }

        public async Task<Gender> GetGenderByIdAsync(int id)
        {
            return await _genderRepository.GetByIdAsync(id);
        }

        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            await _genderRepository.AddAsync(gender);
            return gender;
        }

        public async Task UpdateGenderAsync(int id, Gender gender)
        {
            var existingGender = await _genderRepository.GetByIdAsync(id);

            if (existingGender == null)
            {
                // Throw an exception or return a specific response if the gender does not exist
            }

            existingGender.Description = gender.Description;

            await _genderRepository.UpdateAsync(existingGender);
        }

        public async Task DeleteGenderAsync(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            if (gender == null)
            {
                // Throw an exception or return a specific response if the gender does not exist
            }

            await _genderRepository.RemoveAsync(gender);
        }
        public async Task<bool> GenderExistsAsync(int id)
        {
            return await _genderRepository.GetGenderByIdAsync(id) != null;
        }
    }
}
