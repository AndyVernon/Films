using Films.Domain;

namespace Films.WebApp.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmSummary>> GetFilmSummaries();
    }
}
