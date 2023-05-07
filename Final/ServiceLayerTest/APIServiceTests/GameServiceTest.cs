using APIService.DALs;
using APIService;
using Autofac.Extras.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIService.Models;
using APIService.Adapter;
using Moq;

namespace ServiceLayerTest.APIServiceTests
{
    public class GameServiceTest
    {
        [Fact]
        public void NewGame_ReturnsGameRecordModel()
        {
            using (var mock = AutoMock.GetLoose())
            {

                PokemonRecordModel pokemon = new PokemonRecordModel()
                {
                    PokedexNumber = 1,
                    Name = "Bulbasaur",
                    Type1 = "Grass",
                    Type2 = "Poison",
                    Ability = "Overgrow",
                    AbilityDescription = "Powers up Grass-type moves in a pinch.",
                    SpriteLocation = "./css/sprites/1.png",
                    OutlineLocation = "./css/sprites/outline_1.png"
                };

                EncounterRecordModel encounter = new EncounterRecordModel()
                {
                    Name = pokemon.Name,
                    PokedexNum = pokemon.PokedexNumber,
                    Type1 = pokemon.Type1,
                    Type2 = pokemon.Type2,
                    Ability = pokemon.Ability,
                    AbilDesc = pokemon.AbilityDescription,
                    Location = pokemon.LocationMet,
                    Sprite = pokemon.SpriteLocation,
                    Caught = false
                };

                List<string> locations = new List<string>
                {
                    "Pallet Town"
                };

                var game = new GameRecordModel()
                {
                    UserId = Guid.Empty,
                    Encounter = Guid.Empty,
                    Completed = false
                };

                mock.Mock<Random>()
                    .Setup(x => x.Next(1, 150))
                    .Returns(1);

                var rand = mock.Create<Random>();

                mock.Mock<IPokemonDAL>()
                    .Setup(x => x.GetById(rand.Next(1, 150)))
                    .Returns(pokemon);

                mock.Mock<IPokemonDAL>()
                    .Setup(x => x.GetLocationsMetByPokemonId(1))
                    .Returns(locations);

                mock.Mock<IEncountersDAL>()
                    .Setup(x => x.InsertEncounter(encounter))
                    .Returns(Guid.Empty);

                mock.Mock<IGameDAL>()
                    .Setup(x => x.InsertGameRecord(game))
                    .Returns(Guid.Empty);



                var gdal = mock.Create<IGameDAL>();
                var pdal = mock.Create<IPokemonDAL>();
                var edal = mock.Create<IEncountersDAL>();


                GameService service = new GameService(gdal, pdal, edal, rand);
                var actual = service.NewGame(Guid.Empty);
                game.Id = Guid.Empty;
                Assert.True(actual != null);
                Assert.Equal(game.Id, actual.Id);
                Assert.Equal(game.Timestamp, actual.Timestamp);
                Assert.Equal(game.Completed, actual.Completed);
                Assert.Equal(game.UserId, actual.UserId);
            }
        }

        [Fact]
        public void GetGameById_ReturnsGameRecordModel()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var game = new GameRecordModel()
                {
                    UserId = Guid.Empty,
                    Encounter = Guid.Empty,
                    Completed = false
                };

                mock.Mock<IGameDAL>()
                    .Setup(x => x.GetGameById(Guid.Empty))
                    .Returns(game);

                var gdal = mock.Create<IGameDAL>();


                GameService service = new GameService(gdal, new PokemonDAL(), new EncountersDAL(), new Random());
                var actual = service.GetGameById(Guid.Empty);

                Assert.True(actual != null);
                Assert.Equal(game.Id, actual.Id);
                Assert.Equal(game.Timestamp, actual.Timestamp);
                Assert.Equal(game.Completed, actual.Completed);
                Assert.Equal(game.UserId, actual.UserId);
            }
        }

        [Fact]
        public void UpdateRecord()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var game = new GameRecordModel()
                {
                    UserId = Guid.Empty,
                    Encounter = Guid.Empty,
                    Completed = false
                };

                mock.Mock<IGameDAL>()
                    .Setup(x => x.UpdateGameById(game));

                var gdal = mock.Create<IGameDAL>();


                GameService service = new GameService(gdal, new PokemonDAL(), new EncountersDAL(), new Random());
                service.UpdateRecord(game);

                mock.Mock<IGameDAL>()
                    .Verify(x => x.UpdateGameById(game), Times.Exactly(1));
            }
        }

        [Fact]
        public void GetEncounterById_ReturnsEncounterRecordModel()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var encounter = new EncounterRecordModel()
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
                    .Returns(encounter);

                var edal = mock.Create<IEncountersDAL>();


                GameService service = new GameService(new GameDAL(), new PokemonDAL(), edal, new Random());
                var actual = service.GetEncounterById(Guid.Empty);

                Assert.True(actual != null);
                Assert.Equal(encounter, actual);
            }
        }

        [Fact]
        public void UpdateEncounter()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var encounter = new EncounterRecordModel()
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
                    .Setup(x => x.UpdateEncounterById(encounter));

                var edal = mock.Create<IEncountersDAL>();


                GameService service = new GameService(new GameDAL(), new PokemonDAL(), edal, new Random());
                service.UpdateEncounter(encounter);

                mock.Mock<IEncountersDAL>()
                    .Verify(x => x.UpdateEncounterById(encounter), Times.Exactly(1));
            }
        }

        [Fact]
        public void ConstructorNoParams_ReturnsNotNull()
        {
            //arrange
            var result = new GameService();
            //act

            //assert
            Assert.NotNull(result);
        }
    }
}
