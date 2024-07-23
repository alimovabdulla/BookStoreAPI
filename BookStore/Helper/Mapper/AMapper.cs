using AutoMapper;
using BookStore.DTOs.AuthorDTOs;
using BookStore.DTOs.BookDTO;
using BookStore.DTOs.CountyDTOs;
using BookStore.Models;

namespace BookStore.Helper.Mapper
{
    public class AMapper :Profile
    {
        public AMapper()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO  >().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
