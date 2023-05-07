using APIService.DALs;
using APIService.Models;
using APIService;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ServiceLayerTest.APIServiceTests
{
    public class EncounterDALTests
    {
        [Fact]
        public void GetByUserId_ReturnsListOfEncounterHistoryModel()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IEncountersDAL>()
                    .Setup(x => x.GetByUserId(Guid.Empty))
                    .Returns(GetSampleEncountersHistory());

                var cls = mock.Create<IEncountersDAL>();
                var expected = GetSampleEncountersHistory();
                var actual = cls.GetByUserId(Guid.Empty);

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
            }

        }

        [Fact]
        public void UpdateEncounterById_WasCalledOnce ()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var record = new EncounterRecordModel
                {
                    ID = Guid.Empty,
                    PokedexNum = 1,
                    Name = "Bulbasaur",
                    Type1 = "Grass",
                    Type2 = "Poison",
                    Ability = "Overgrow",
                    AbilDesc = "Powers up Grass-type moves in a pinch.",
                    Location = "Pallet Town",
                    Sprite = "./css/sprites/1.png",
                    Caught = true
                };

                mock.Mock<IEncountersDAL>()
                    .Setup(x => x.UpdateEncounterById(record));

                var cls = mock.Create<IEncountersDAL>();

                cls.UpdateEncounterById(record);

                mock.Mock<IEncountersDAL>()
                    .Verify(x => x.UpdateEncounterById(record), Times.Exactly(1));
            }
        }

        [Fact]
        public void GetByEncounterById_ReturnsEncounterRecordModel()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var output = new EncounterRecordModel
                {
                    ID = Guid.Empty,
                    PokedexNum = 1,
                    Name = "Bulbasaur",
                    Type1 = "Grass",
                    Type2 = "Poison",
                    Ability = "Overgrow",
                    AbilDesc = "Powers up Grass-type moves in a pinch.",
                    Location = "Pallet Town",
                    Sprite = "./css/sprites/1.png",
                    Caught = true
                };

                mock.Mock<IEncountersDAL>()
                    .Setup(x => x.GetEncounterById(Guid.Empty))
                    .Returns(output);

                var cls = mock.Create<IEncountersDAL>();
                var expected = output;
                var actual = cls.GetEncounterById(Guid.Empty);

                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }

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
