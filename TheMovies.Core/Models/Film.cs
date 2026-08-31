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

        // Konstruktør
        // OBS: Hvis instruktør og premiereDato ikke er angivet, vil de blive sat til tom streng og default(DateTime) henholdsvis.
        // Dette giver mulighed for at oprette en Film uden at skulle angive disse værdier.
        // Dette er for at imødekomme Scenarie 1, hvor instruktør og premiereDato ikke er nødvendige.
        // De bliver dog nødvendige i næste scenarie.
        public Film(string titel, string genre, int varighed, string instruktør = "", DateTime premiereDato = default)
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
