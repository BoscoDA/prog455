using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.Adapter
{
    public static class PokemonEncounterAdapter
    {

        public static EncounterRecordModel PokemonToEncounter(PokemonModel model) 
        {
            return new EncounterRecordModel()
            {
                Name = model.Name,
                PokedexNum = model.PokedexNumber,
                Type1 = model.Type1,
                Type2 = model.Type2,
                Ability = model.Ability,
                AbilDesc = model.AbilityDescription,
                Location = model.LocationMet,
                Sprite = model.SpriteLocation,
                Caught = false
            };
        }
    }
}
