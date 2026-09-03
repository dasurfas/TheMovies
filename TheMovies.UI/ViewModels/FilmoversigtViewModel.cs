using System.Collections.ObjectModel;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

namespace TheMovies.UI.ViewModels
{
    public class FilmoversigtViewModel : ViewModelBase
    {
        private readonly IFilmRepository _filmRepository;
        private Film? _valgtFilm;

        public FilmoversigtViewModel()
        {
            _filmRepository = new FilFilmRepository();
            FilmCollection = new ObservableCollection<Film>();
            HentFilm();
        }

        public ObservableCollection<Film> FilmCollection { get; }

        public Film? ValgtFilm
        {
            get => _valgtFilm;
            set => SetProperty(ref _valgtFilm, value);
        }

        public void HentFilm()
        {
            FilmCollection.Clear();
            var films = _filmRepository.GetAll();
            foreach (var film in films)
            {
                FilmCollection.Add(film);
            }
        }
    }
}
