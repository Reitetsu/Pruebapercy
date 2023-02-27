using MyAPI2.Application.Dtos;
using MyAPI2.Domain.Entities;
using MyAPI2.Application.Services;
using MyAPI2.Infrastructure.Repositories;
using AutoMapper;

namespace MyAPI2.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IGenderRepository _genderRepository;

        public PersonService(IPersonRepository personRepository, IGenderRepository genderRepository)
        {
            _personRepository = personRepository;
            _genderRepository = genderRepository;
        }

        public async Task<IEnumerable<PersonDto>> GetAllPeopleAsync()
        {
            var people = await _personRepository.GetAllAsync();
            var personDtos = new List<PersonDto>();

            foreach (var person in people)
            {
                var personDto = new PersonDto
                {
                    Id = person.Id,
                    Names = person.Names,
                    GenderId = person.GenderId,
                    Gender = new GenderDto
                    {
                        Id = person.Gender.Id,
                        Description = person.Gender.Description,
                        Code = person.Gender.Code
                    }
                };

                personDtos.Add(personDto);
            }

            return personDtos;
        }

        public async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);

            if (person == null)
            {
                return null;
            }

            var personDto = new PersonDto
            {
                Id = person.Id,
                Names = person.Names,
                GenderId = person.GenderId,
                Gender = new GenderDto
                {
                    Id = person.Gender.Id,
                    Description = person.Gender.Description,
                    Code = person.Gender.Code
                }
            };

            return personDto;
        }

        public async Task<int> CreatePersonAsync(PersonDto personDto)
        {
            var person = new Person
            {
                Names = personDto.Names,
                GenderId = personDto.GenderId
            };

            await _personRepository.AddAsync(person);

            return person.Id;
        }

        public async Task UpdatePersonAsync(int id, PersonDto personDto)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found");
            }

            if (personDto.GenderId != null)
            {
                var gender = await _genderRepository.GetByIdAsync(personDto.GenderId.Value);
                if (gender == null)
                {
                    throw new KeyNotFoundException("Gender not found");
                }

                person.Gender = gender;
            }

            person.Names = personDto.Names;

            await _personRepository.UpdateAsync(person);
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found");
            }

            await _personRepository.DeleteAsync(person);
        }
        public async Task<bool> PersonExistsAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id) != null;
        }


    }
}
