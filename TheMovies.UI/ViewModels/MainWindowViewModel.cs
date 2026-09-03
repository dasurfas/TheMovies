using System.Windows.Input;
using TheMovies.UI.Helpers;

namespace TheMovies.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;

        public MainWindowViewModel()
        {
            NavigateToFilmoversigCommand = new RelayCommand(_ => NavigateToFilmoversig());
            NavigateToRegistrerFilmCommand = new RelayCommand(_ => NavigateToRegistrerFilm());

            // Set initial view to Filmoversigt
            NavigateToFilmoversig();
        }

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public ICommand NavigateToFilmoversigCommand { get; }
        public ICommand NavigateToRegistrerFilmCommand { get; }

        private void NavigateToFilmoversig()
        {
            CurrentViewModel = new FilmoversigtViewModel();
        }

        private void NavigateToRegistrerFilm()
        {
            CurrentViewModel = new RegistrerFilmViewModel();
        }
    }
}
