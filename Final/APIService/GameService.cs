using APIService.Adapter;
using APIService.Data_Access_Layers;
using APIService.Models;
using APIService.Models.ResponseModels;
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
        DAL _dal = new DAL();
        Random _rand = new Random();

        public GameResponseModel NewGame(Guid playerID)
        {
            //Create Pokemon
            PokemonModel pokemon = _dal.GetById(_rand.Next(1, 150));
            var location = _dal.GetLocationsMetByPokemonId(pokemon.PokedexNumber);
            if (location.Count <= 0)
            {
                pokemon.LocationMet = "Evolution";
            }
            else
            {
                pokemon.LocationMet = location[_rand.Next(0, location.Count)];
            }
            // Insert into encount table and return id for game
            Guid pokeID = _dal.InsertEncounter(PokemonEncounterAdapter.PokemonToEncounter(pokemon));

            // make the game and save in Games table
            var game = new GameRecordModel()
            {
                UserId = playerID,
                Timestamp = DateTime.Now,
                Completed = false,
                Encounter = pokeID,
            };

            Guid gameId = _dal.InsertGameRecord(game);
            

            return new GameResponseModel(){
                GameId = gameId,
                Pokemon = pokemon
            };
        }

        public GameRecordModel GetGameById(Guid id)
        {
            var game = _dal.GetGameById(id);
            if(game == null)
            {
                return null;
            }
            return game;
        }

        public void UpdateRecord(GameRecordModel record)
        {
            _dal.UpdateGameById(record);
        }

        public EncounterRecordModel GetEncounterById(Guid id)
        {
            return _dal.GetEncounterById(id);
        }
        
        //On game end update the encounter to show if you won or not
        public void UpdateEncounter(EncounterRecordModel record) 
        {
            _dal.UpdateEncounterById(record);
        }
    }
}
