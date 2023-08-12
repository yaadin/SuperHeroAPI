using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroAPI.Controllers
{
    [Route("api/heroes")]
    public class SuperHeroesController : Controller
    {
        private readonly HeroesDbContext _db;
        public SuperHeroesController(HeroesDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllHeroes()
        {
            try
            {
                var elements = await _db.hero.ToListAsync();
                if (elements == null)
                {
                    return NotFound();
                }
                return Ok(elements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<HeroModel>>> GetbyId(int id)
        {
            try
            {
                var element = await _db.hero.FirstOrDefaultAsync(u => u.ID == id);
                if (element == null)
                {
                    return NotFound();
                }
                return Ok(element);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
          
        }
    }

}
