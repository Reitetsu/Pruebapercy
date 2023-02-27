namespace MyAPI2.Application.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public int? GenderId { get; set; }
        public GenderDto Gender { get; set; }
    }
}
