using APIService;
using APIService.Adapter;
using APIService.DALs;
using APIService.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest.APIServiceTests
{
    public class PokemonEncounterAdapterTests
    {
        [Fact]
        public void PokemonToEncounter_ReturnsExpectedEncounterRecordModel()
        {
            // Arrange
            var pokemon = new PokemonRecordModel()
            {
                Name = "Bulbasaur",
                PokedexNumber = 1,
                Type1 = "Grass",
                Type2 = "Poison",
                Ability = "Overgrow",
                AbilityDescription = "Powers up Grass-type moves when the Pokémon's HP is low.",
                LocationMet = "Pallet Town",
                SpriteLocation = "/sprites/bulbasaur.png"
            };

            // Act
            var encounter = PokemonEncounterAdapter.PokemonToEncounter(pokemon);

            // Assert
            Assert.Equal("Bulbasaur", encounter.Name);
            Assert.Equal(1, encounter.PokedexNum);
            Assert.Equal("Grass", encounter.Type1);
            Assert.Equal("Poison", encounter.Type2);
            Assert.Equal("Overgrow", encounter.Ability);
            Assert.Equal("Powers up Grass-type moves when the Pokémon's HP is low.", encounter.AbilDesc);
            Assert.Equal("Pallet Town", encounter.Location);
            Assert.Equal("/sprites/bulbasaur.png", encounter.Sprite);
            Assert.False(encounter.Caught);
        }
    }
}
