using MyAPI2.Application.Dtos;
using MyAPI2.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GenderDto>> GetGenderByIdAsync(int id)
        {
            var gender = await _genderService.GetGenderByIdAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            return Ok(gender);
        }
        /*
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GenderDto>> CreateGenderAsync(GenderForCreationDto genderForCreationDto)
        {
            var genderDto = await _genderService.CreateGenderAsync(genderForCreationDto);
            return CreatedAtAction(nameof(GetGenderByIdAsync), new { id = genderDto.Id }, genderDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateGenderAsync(long id, GenderForUpdateDto genderForUpdateDto)
        {
            if (!await _genderService.GenderExistsAsync(id))
            {
                return NotFound();
            }

            await _genderService.UpdateGenderAsync(id, genderForUpdateDto);

            return NoContent();
        }
        */
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteGenderAsync(int id)
        {
            if (!await _genderService.GenderExistsAsync(id))
            {
                return NotFound();
            }

            await _genderService.DeleteGenderAsync(id);

            return NoContent();
        }
    }
}


