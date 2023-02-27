namespace MyAPI2.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }
        public Person() { }
        public Person(string names, int? genderId)
        {
            Names = names;
            GenderId = genderId;
        }
        public Person(int id, string names, int? genderId)
        {
            Id = id;
            Names = names;
            GenderId = genderId;
        }
    }
}
