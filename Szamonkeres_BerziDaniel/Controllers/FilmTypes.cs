using Microsoft.AspNetCore.Mvc;
using Szamonkeres_BerziDaniel.Models;


namespace Szamonkeres_BerziDaniel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmtypesController : ControllerBase
    {
        public readonly CinemadbContext _context;
        public FilmtypesController(CinemadbContext context)
        {
            _context = context;
        }

        [HttpGet("Feladat")]
        public IActionResult FetchFilmTypesAndTheirMovies()
        {
            try
            {
                var filmTypesWithMovies = _context.FilmTypes
                    .Select(ft => new
                    {
                        Id = ft.TypeId,
                        Name = ft.TypeName,
                        Movies = ft.Movies.Select(m => new
                        {
                            Id = m.MovieId,
                            Title = m.Title,
                            ReleaseDate = m.ReleaseDate,
                            ActorId = m.ActorId,
                            FilmTypeId = m.FilmTypeId
                        }).ToList()
                    })
                    .ToList();

                return Ok(filmTypesWithMovies);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Hiba történt a film típusok lekérése közben",
                    details = ex.Message
                });
            }
        }


    }
}