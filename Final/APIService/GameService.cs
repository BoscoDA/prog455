using APIService.Adapter;
using APIService.DALs;
using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class GameService
    {
        IGameDAL _gameDal;
        IPokemonDAL _pokeDAL;
        IEncountersDAL _encounterDAL;
        Random _rand;

        public GameService()
        {
           _gameDal = new GameDAL();
            _pokeDAL = new PokemonDAL();
            _encounterDAL = new EncountersDAL();
            _rand = new Random();
        }

        public GameService(IGameDAL gdal, IPokemonDAL pdal, IEncountersDAL edal, Random rand)
        {
            _gameDal = gdal;
            _pokeDAL = pdal;
            _encounterDAL = edal;
            _rand = rand;
        }

        /// <summary>
        /// Creates a random new pokemon using the PokemonDAL and then creates a new Game on in the database using the pokemon created and the user id that is passed in
        /// </summary>
        /// <param name="playerID"></param>
        /// <returns>Returns the new GameRecordModel to be used in the game</returns>
        public GameRecordModel NewGame(Guid playerID)
        {
            //Get a random pokemon from the DB
            PokemonRecordModel pokemon = _pokeDAL.GetById(_rand.Next(1,150));

            //Get all spawn location associated with pokemon from the DB and give a random one to the pokemon
            var location = _pokeDAL.GetLocationsMetByPokemonId(pokemon.PokedexNumber);
            if (location.Count <= 0)
            {
                pokemon.LocationMet = "Evolution";
            }
            else
            {
                pokemon.LocationMet = location[_rand.Next(0, location.Count)];
            }

            var encounter = PokemonEncounterAdapter.PokemonToEncounter(pokemon);

            // Insert into encounter table and return its id for the game
            Guid pokeID = _encounterDAL.InsertEncounter(encounter);

            // make the game and save in Games table
            var game = new GameRecordModel()
            {
                UserId = playerID,
                Encounter = pokeID,
                Completed = false
            };

            Guid gameId = _gameDal.InsertGameRecord(game);

            game.Id = gameId;

            return game;
        }

        /// <summary>
        /// Uses the provide game id to call tge GameDAL and retrieve the game that corrisponds to it in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>GameRecordModel</returns>
        public GameRecordModel GetGameById(Guid id)
        {
            var game = _gameDal.GetGameById(id);
            if(game == null)
            {
                return null;
            }
            return game;
        }

        /// <summary>
        /// Calls the GameDAL using the provided record to update it in the database
        /// </summary>
        /// <param name="record"></param>
        public void UpdateRecord(GameRecordModel record)
        {
                _gameDal.UpdateGameById(record);
        }

        public EncounterRecordModel GetEncounterById(Guid? id)
        {
            return _encounterDAL.GetEncounterById(id);
        }
        
        /// <summary>
        /// Using the passed in record to call the GameDAL to update the specified enounter in the database
        /// </summary>
        /// <param name="record"></param>
        public void UpdateEncounter(EncounterRecordModel record) 
        {
            _encounterDAL.UpdateEncounterById(record);
        }
    }
}
