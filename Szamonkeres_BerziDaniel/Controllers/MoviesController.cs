using Microsoft.AspNetCore.Mvc;
using Szamonkeres_BerziDaniel.Models;


namespace Szamonkeres_BerziDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CinemadbContext _context;
        public MoviesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("Feladat10")]
        public IActionResult FetchAllMovies()
        {
            try
            {
                var movies = _context.Movies
                    .Select(m => new
                    {
                        Id = m.MovieId,
                        Title = m.Title,
                        ReleaseDate = m.ReleaseDate,
                        ActorId = m.ActorId,
                        FilmTypeId = m.FilmTypeId
                    })
                    .ToList();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Hiba történt a filmek lekérdezésekor",
                    details = ex.Message
                });
            }
        }


    }
}