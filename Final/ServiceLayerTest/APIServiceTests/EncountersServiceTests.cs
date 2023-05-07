using APIService;
using APIService.DALs;
using APIService.Models;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTest.APIServiceTests
{
    public class EncountersServiceTests
    {
        [Fact]
        public void GetAllEncounters_ReturnsListOfEncounterHistoryModel()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEncountersDAL>()
                    .Setup(x => x.GetByUserId(Guid.Empty))
                    .Returns(GetSampleEncountersHistory());

                var cls = mock.Create<IEncountersDAL>();
                var expected = GetSampleEncountersHistory();
                EncountersService service = new EncountersService(cls);
                var actual = service.GetAllEncounters(Guid.Empty);

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }

        }

        [Fact]
        public void ConstructorEmpty_ReturnsNotNull()
        {
            var expected = new EncountersService();

            Assert.NotNull(expected);
        }

        private List<EncounterHistoryRecordModel> GetSampleEncountersHistory()
        {
            List<EncounterHistoryRecordModel> output = new List<EncounterHistoryRecordModel>
            {
                new EncounterHistoryRecordModel
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
                },
                new EncounterHistoryRecordModel
                {
                    PokedexNum = 1,
                    Name = "Ivysaur",
                    Type1 = "Grass",
                    Type2 = "Poison",
                    Ability = "Overgrow",
                    AbilDesc = "Powers up Grass-type moves in a pinch.",
                    Location = "Pallet Town",
                    Sprite = "./css/sprites/2.png",
                    Caught = true,
                    TimeStamp = DateTime.Now
                },
                new EncounterHistoryRecordModel
                {
                    PokedexNum = 1,
                    Name = "Venusaur",
                    Type1 = "Grass",
                    Type2 = "Poison",
                    Ability = "Overgrow",
                    AbilDesc = "Powers up Grass-type moves in a pinch.",
                    Location = "Pallet Town",
                    Sprite = "./css/sprites/3.png",
                    Caught = true,
                    TimeStamp = DateTime.Now
                }
            };

            return output;
        }
    }
}
