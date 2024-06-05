using Films.WebApp.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Films.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsDataController : ControllerBase
    {
        private readonly IFilmsRepository _filmsRepository;

        public FilmsDataController(IFilmsRepository filmsRepository)
        {
            _filmsRepository = filmsRepository;
        }

        [HttpGet(Name = "GetFilmSummaries")]
        public IActionResult FilmSummaries()
        {
            var data = _filmsRepository.FilmSummaries();
            return Ok(data);
        }
    }
}
