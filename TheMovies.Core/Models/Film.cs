using System;

namespace TheMovies.Core.Models
{
    public class Film
    {
        // Fields:
        private string _titel;
        private string _genre;
        private int _varighed;
        private string _instruktør;
        private DateTime _premiereDato;

        // Konstruktoer:
        public Film(string titel, string genre, int varighed, string instruktør, DateTime premiereDato)
        {
            _titel = titel;
            _genre = genre;
            _varighed = varighed;
            _instruktør = instruktør;
            _premiereDato = premiereDato;
        }

        // Properties:
        public string Titel
        {
            get { return _titel; }
            set { _titel = value; }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public int Varighed
        {
            get { return _varighed; }
            set { _varighed = value; }
        }


        public string Instruktør
        {
            get { return _instruktør; }
            set { _instruktør = value; }
        }

        public DateTime PremiereDato
        {
            get { return _premiereDato; }
            set { _premiereDato = value; }
        }
    }
}
