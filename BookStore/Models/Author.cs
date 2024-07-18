namespace BookStore.Models
{
    public class Author:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth {  get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
