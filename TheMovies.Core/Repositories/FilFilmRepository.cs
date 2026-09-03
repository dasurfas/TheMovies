using System.Globalization;
using TheMovies.Core.Models;

namespace TheMovies.Core.Repositories
{
    public class FilFilmRepository : IFilmRepository
    {
        private readonly string _filePath;
        private const string Delimiter = ";";

        public FilFilmRepository(string filePath = "film.txt")
        {
            _filePath = filePath;
        }

        public void Add(Film film)
        {
            string line = $"{film.Titel}{Delimiter}{film.Genre}{Delimiter}{film.Varighed}{Delimiter}{film.Instruktør}{Delimiter}{film.PremiereDato:o}";
            File.AppendAllText(_filePath, line + Environment.NewLine);
        }

        public List<Film> GetAll()
        {
            List<Film> films = new List<Film>();

            if (!File.Exists(_filePath))
            {
                return films;
            }

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split(Delimiter);

                if (parts.Length >= 5)
                {
                    string titel = parts[0];
                    string genre = parts[1];
                    int varighed = int.Parse(parts[2]);
                    string instruktør = parts[3];
                    DateTime premiereDato = DateTime.Parse(parts[4], CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

                    Film film = new Film(titel, genre, varighed, instruktør, premiereDato);
                    films.Add(film);
                }
            }

            return films;
        }
    }
}
