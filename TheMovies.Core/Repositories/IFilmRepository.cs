using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public interface IFilmRepository
    {
        void Add(Film film);
        List<Film> GetAll();
    }
}
