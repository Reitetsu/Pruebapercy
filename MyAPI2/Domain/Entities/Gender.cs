using MyAPI2.Domain.Enums;

namespace MyAPI2.Domain.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public GenderType Code { get; set; }

        public Gender() { }

        public Gender(string description, GenderType code)
        {
            Description = description;
            Code = code;
        }
    }
}
