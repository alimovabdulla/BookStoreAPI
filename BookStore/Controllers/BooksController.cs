using BookStore.DTOs.BookDTO;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ClassDbContext _dbContext;
        public BooksController(ClassDbContext classDbContext)
        {
            _dbContext = classDbContext;

        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _dbContext.Books.Include(b=>b.Genre).Include(b=>b.Author).ToListAsync();
            return Ok(data);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(BookDTO bookDTO)
        {
            Book book = new Book()
            {
                Name = bookDTO.Name,
                AuthorId = bookDTO.AuthorId,
                GenreId = bookDTO.GenreId,
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return Ok(book);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,BookDTO bookDTO)
        {
            Book book = new Book()
            {
                Name = bookDTO.Name,
                AuthorId = bookDTO.AuthorId,
                GenreId = bookDTO.GenreId,
            };
            Book old = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            old.Genre = book.Genre;
            old.Name = book.Name;
            old.Author = book.Author;
            _dbContext.SaveChanges();
            return Ok(book);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var dta = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            _dbContext.Books.Remove(dta);
            _dbContext.SaveChanges();
            return Ok(dta);
        }



    }
}
