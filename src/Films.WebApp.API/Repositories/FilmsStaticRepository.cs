using Films.Domain;
using Films.WebApp.API.Interfaces;

namespace Films.WebApp.API.Repositories
{
    public class FilmsStaticRepository : IFilmsRepository
    {
        public IEnumerable<FilmSummary> FilmSummaries()
        {
            throw new NotImplementedException();
        }
    }
}
