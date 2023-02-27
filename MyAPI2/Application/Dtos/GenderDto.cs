using MyAPI2.Domain.Enums;

namespace MyAPI2.Application.Dtos
{
    public class GenderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public GenderType Code { get; set; }
    }
}
