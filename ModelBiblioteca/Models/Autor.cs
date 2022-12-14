namespace ModelBiblioteca.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public List<Book> Books { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {Name} {LastName}";
        }
    }
}