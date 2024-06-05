using Films.Domain;
using Films.WebApp.Interfaces;

namespace Films.WebApp.Services
{
    public class FilmService : IFilmService
    {
        private IFilmService _this;

        public FilmService() 
        {
            _this = this;
        }
        async Task<IEnumerable<FilmSummary>> IFilmService.GetFilmSummaries()
        {
            throw new NotImplementedException();
        }
    }
}
