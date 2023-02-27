using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAPI2.Application.Dtos;
using MyAPI2.Application.Services;
using MyAPI2.Application.Validators;

namespace MyAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersonsAsync()
        {
            var persons = await _personService.GetPersonsAsync();
            return Ok(persons);
        }
        */
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPersonByIdAsync(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePersonAsync(PersonDto personDto)
        {
            var validator = new PersonValidator();
            var validationResult = await validator.ValidateAsync(personDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var createdPerson = await _personService.CreatePersonAsync(personDto);
            return CreatedAtAction(nameof(GetPersonByIdAsync), new { id = createdPerson }, createdPerson);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonAsync(int id, PersonDto personDto)
        {
            var validator = new PersonValidator();
            var validationResult = await validator.ValidateAsync(personDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var personExists = await _personService.PersonExistsAsync(id);

            if (!personExists)
            {
                return NotFound();
            }

            await _personService.UpdatePersonAsync(id, personDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            var personExists = await _personService.PersonExistsAsync(id);

            if (!personExists)
            {
                return NotFound();
            }

            await _personService.DeletePersonAsync(id);

            return NoContent();
        }
    }
}
