using Films.Domain;

namespace Films.WebApp.API.Interfaces
{
    public interface IFilmsRepository
    {
        IEnumerable<FilmSummary> FilmSummaries();
    }
}
