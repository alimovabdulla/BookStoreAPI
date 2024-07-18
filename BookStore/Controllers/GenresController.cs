using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ClassDbContext _dbContext;
        public GenresController(ClassDbContext classDb)
        {
            _dbContext = classDb;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var data = _dbContext.Genres.FirstOrDefault(x => x.Id == id);
            return Ok(data);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
             var data =await _dbContext.Genres.ToListAsync();
            return Ok(data);
        }
        [HttpPost("Create")]
        public async Task <IActionResult> Create(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task <IActionResult> Update(int id , Genre genre)
        {
           Genre old = _dbContext.Genres.FirstOrDefault(y => y.Id == id);
            old.Name = genre.Name;
            _dbContext.SaveChanges();
            return Ok(old);
        }
        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            var data = _dbContext.Genres.FirstOrDefault(z => z.Id == id);
            _dbContext.Genres.Remove(data);
            _dbContext.SaveChanges();
            return Ok(data);
        }
   
    
    }
}
