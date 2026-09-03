using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMovies.Core.Models;

namespace TheMovies.Tests
{
    // Test klasse.
    [TestClass]
    public class FilmTests
    {
        [TestMethod]
        public void Constructor_MedTreArgumenter_SaetterTitelGenreVarighed()
        {
            // Arrange + Act (Opret objektet):
            Film film = new Film("Alien", "Sci-fi", 120);

            // Assert (Forventet foerst, faktisk bagefter):
            Assert.AreEqual("Alien", film.Titel);
            Assert.AreEqual("Sci-fi", film.Genre);
            Assert.AreEqual(120, film.Varighed);
        }

        [TestMethod]
        public void Constructor_UdenValgfrieArgumenter_GiverDefaultVaerdier()
        {
            // Arrange + Act:
            Film film = new Film("Alien", "Sci-fi", 120);

            // Assert: De 2 valgfrie parametre's defaults:
            Assert.AreEqual("", film.Instruktør);
            Assert.AreEqual(default(DateTime), film.PremiereDato);
        }

        [TestMethod]
        public void Constructor_MedAlleArgumenter_SaetterInstruktoerOgPremiereDato()
        {
            // Arrange:
            DateTime premiere = new DateTime(1979, 5, 25);

            // Act:
            Film film = new Film("Alien", "Sci-fi", 120, "Ridley Scott", premiere);

            // Assert:
            Assert.AreEqual("Ridley Scott", film.Instruktør);
            Assert.AreEqual(premiere, film.PremiereDato);

        }

    }
}
