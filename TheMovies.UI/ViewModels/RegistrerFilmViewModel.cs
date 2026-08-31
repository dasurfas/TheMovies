using System.Windows;
using System.Windows.Input;
using TheMovies.UI.Helpers;
using TheMovies.Core.Models;
using TheMovies.Core.Repositories;

namespace TheMovies.UI.ViewModels
{
    public class RegistrerFilmViewModel : ViewModelBase
    {
        private readonly IFilmRepository _filmRepository;
        private string _titel = string.Empty;
        private string _genre = string.Empty;
        private int _varighed;
        private string _varighedTimer = string.Empty;
        private string _varighedMinutter = string.Empty;
        private string _instruktør = string.Empty;
        private DateTime _premiereDato = DateTime.Today;

        public RegistrerFilmViewModel()
        {
            _filmRepository = new FilFilmRepository();
            GemFilmCommand = new RelayCommand(_ => GemFilm(), _ => CanGemFilm());
        }

        public string Titel
        {
            get => _titel;
            set => SetProperty(ref _titel, value);
        }

        public string Genre
        {
            get => _genre;
            set => SetProperty(ref _genre, value);
        }

        public int Varighed
        {
            get => _varighed;
            set => SetProperty(ref _varighed, value);
        }

        public string VarighedTimer
        {
            get => _varighedTimer;
            set
            {
                if (SetProperty(ref _varighedTimer, value))
                {
                    UpdateVarighedTotal();
                }
            }
        }

        public string VarighedMinutter
        {
            get => _varighedMinutter;
            set
            {
                if (SetProperty(ref _varighedMinutter, value))
                {
                    UpdateVarighedTotal();
                }
            }
        }

        private void UpdateVarighedTotal()
        {
            int timer = int.TryParse(_varighedTimer, out int t) ? t : 0;
            int minutter = int.TryParse(_varighedMinutter, out int m) ? m : 0;
            Varighed = (timer * 60) + minutter;
        }
        
        
        public string Instruktør
        {
            get => _instruktør;
            set => SetProperty(ref _instruktør, value);
        }

        public DateTime PremiereDato
                {
            get => _premiereDato;
            set => SetProperty(ref _premiereDato, value);
        }

        public ICommand GemFilmCommand { get; }

        private bool CanGemFilm()
        {
            return !string.IsNullOrWhiteSpace(Titel) 
                   && !string.IsNullOrWhiteSpace(Genre) 
                   && Varighed > 0;
        }

        private void GemFilm()
        {
            try
            {
                Film film = new Film(Titel, Genre, Varighed, Instruktør, PremiereDato);
                _filmRepository.Add(film);

                // Show success message
                MessageBox.Show(
                    $"Filmen '{Titel}' er blevet registreret.",
                    "Film registreret",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                // Tøm formularen
                Titel = string.Empty;
                Genre = string.Empty;
                Varighed = 0;
                VarighedTimer = string.Empty;
                VarighedMinutter = string.Empty;
                Instruktør = string.Empty;
                PremiereDato = DateTime.Today;
            }
            catch (Exception ex)
            {
                // Show error message
                MessageBox.Show(
                    $"Der opstod en fejl ved registrering af filmen:\n{ex.Message}",
                    "Fejl",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
