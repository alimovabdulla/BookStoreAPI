using AutoMapper;
using BookStore.DTOs.AuthorDTOs;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ClassDbContext _dbContext;
        public AuthorsController(ClassDbContext classDbContext, IMapper mapper)
        {
            _dbContext = classDbContext;
            _mapper = mapper;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            Author author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return BadRequest();
            }
            return Ok(author);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _dbContext.Authors.Include("Country").ToListAsync();
            return Ok(data);

        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(AuthorDTO authorDTO)
        {
            Author author = _mapper.Map<Author>(authorDTO);
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
            return Ok(author);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, AuthorDTO authorDTO)
        {
            Author author = _mapper.Map<Author>(authorDTO);
            Author old = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
            old.Surname = authorDTO.Surname;
            old.Name = authorDTO.Name;
            old.Birth = authorDTO.Birth;
            old.CountryId = authorDTO.CountryId;
            await _dbContext.SaveChangesAsync();
            return Ok(old);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = _dbContext.Authors.FirstOrDefault(x => x.Id == id);
            _dbContext.Authors.Remove(data);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
