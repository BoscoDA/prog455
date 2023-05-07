using APIService.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ServiceLayerTest.APIServiceTests
{
    public class EncounterHistoryModelTests
    {
        [Fact]
        public void ConstructorParamterEncounterRecordModel_ReturnsNotNull()
        {
            //arrange
            var model = new EncounterHistoryRecordModel()
            {
                PokedexNum = 1,
                Name = "Bulbasaur",
                Type1 = "Grass",
                Type2 = "Poison",
                Ability = "Overgrow",
                AbilDesc = "Powers up Grass-type moves in a pinch.",
                Location = "Pallet Town",
                Sprite = "./css/sprites/1.png",
                Caught = true,
                TimeStamp = DateTime.Now
            };

            //act
            var result = new EncounterHistoryModel(model);

            //assert
            Assert.NotNull(result);
        }
    }
}
