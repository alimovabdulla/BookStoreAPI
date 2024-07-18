namespace BookStore.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
    }
}
