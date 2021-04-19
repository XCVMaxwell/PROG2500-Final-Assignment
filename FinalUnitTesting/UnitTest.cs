using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonTcgSdk.Models;
using FinalApp.Repos;

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
    }
}
