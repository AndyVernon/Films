using Films.Domain;
using Films.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Films.WebApp.Controllers.API
{    
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<DataController> _logger;

        public DataController(IFilmService filmService, ILogger<DataController> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        public async Task<IActionResult> FilmSummaries()
        {
            var data = await _filmService.GetFilmSummaries();
            return Ok(data);
        }
    }
}
