using MyAPI2.Domain.Enums;

namespace MyAPI2.Application.Dtos
{
    public class GenderForUpdateDto
    {
        public string Description { get; set; }
        public GenderType Code { get; set; }
    }
}

