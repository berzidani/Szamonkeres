using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Szamonkeres_BerziDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly Models.CinemadbContext _context;
        public ActorsController(Models.CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("Feladat 12")]
        
        public IActionResult RetrieveActorTotal()
        {
            try
            {
                var totalActors = _context.Actors.Count();
                return Ok(new { message = $"Összes színész: {totalActors}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    errorMessage = "Hiba történt az adatok lekérdezése során",
                    details = ex.Message
                });
            }
        }


    }
}