using BookStore.DTOs.CountyDTOs;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ClassDbContext _dbContext;
        public CountriesController(ClassDbContext classDbContext)
        {
            _dbContext = classDbContext;
        }

        [HttpGet("All")]
        public async Task <IActionResult> GetAll()
        {
            var data = await _dbContext.Countries.ToListAsync();
            return Ok(data);

        }
        [HttpGet("Get")]
        public async Task <IActionResult> Get(int id)
        {
            Country country = await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(country);
        }
        [HttpPost("Create")]
        public  async Task <IActionResult> Create(CountryDTO countrydto)
        {
            Country country = new Country()
            {
                Name = countrydto.Name,

            };
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return Ok(country);
        }
        [HttpPut("Update")]
        public async Task <IActionResult> Update(int id, Country country)
        {
          Country   old = await _dbContext.Countries.FirstOrDefaultAsync(x=>x.Id==id);
            old.Name= country.Name;
            _dbContext.SaveChangesAsync();
            return Ok(country);
        }
        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            Country country = _dbContext.Countries.FirstOrDefault(x=>x.Id==id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return Ok(country);
        }
    
    
    }
}
