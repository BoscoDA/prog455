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

        public GameRecordModel GetGameById(Guid id)
        {
            var game = _gameDal.GetGameById(id);
            if(game == null)
            {
                return null;
            }
            return game;
        }

        public void UpdateRecord(GameRecordModel record)
        {
                _gameDal.UpdateGameById(record);
        }

        public EncounterRecordModel GetEncounterById(Guid? id)
        {
            return _encounterDAL.GetEncounterById(id);
        }
        
        //On game end update the encounter to show if you won or not
        public void UpdateEncounter(EncounterRecordModel record) 
        {
            _encounterDAL.UpdateEncounterById(record);
        }
    }
}
