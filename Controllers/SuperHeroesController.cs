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
        [HttpGet("{id}", Name = "GetById")]
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
        [HttpPost]
        public async Task<IActionResult> post([FromBody] HeroModel heromodel)
        {
            try
            {
                if (heromodel == null)
                {
                    return BadRequest();
                }
                if (heromodel.ID != 0)
                {
                    return BadRequest();
                }
                _ = _db.hero.AddAsync(heromodel);
                await _db.SaveChangesAsync();

                return Ok(Redirect("api/heroes"));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }
    }

}
