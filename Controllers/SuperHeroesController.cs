using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperHeroAPI.Controllers
{
    [Route("api/heroes")]
    public class SuperHeroesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            return Ok();
        }
    }
}

