using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonTcgSdk.Models;
using FinalApp.Repos;
using FinalApp.ViewModels;

namespace FinalUnitTesting
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetAllPokemonCards_GetsAllCards()
        {
            var cards = PokemonRepo.GetAllPokemonCards();
            var firstCard = cards[0];
            var name = firstCard.Name;

            Assert.IsTrue(cards.Count > 20);
            Assert.IsNotNull(firstCard);
            Assert.IsNotNull(name);
        }

        [TestMethod]
        public void TestFilteringCards()
        {
            PokemonViewModel pvm = new PokemonViewModel();
            var cards = PokemonRepo.GetAllPokemonCards();

            pvm.Filter = "Charizard";
            pvm.PerformFiltering();
            
            Assert.IsTrue(cards.Count == 2);
        }

        [TestMethod]
        public void TestSelectedCard()
        {
            var cards = PokemonRepo.GetAllPokemonCards();
            PokemonViewModel pvm = new PokemonViewModel();

            pvm.SelectedPokemon = cards[0];

            Assert.AreEqual("Growlithe", pvm.PokemonName);         
        }
    }
}
