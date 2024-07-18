using BookStore.Models;

namespace BookStore.DTOs.AuthorDTOs
{
    public class AuthorDTO
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public int CountryId { get; set; }
     }
}
