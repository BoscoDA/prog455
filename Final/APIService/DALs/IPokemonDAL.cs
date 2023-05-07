using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DALs
{
    public interface IPokemonDAL
    {
        List<string> GetLocationsMetByPokemonId(int id);
        PokemonRecordModel GetById(int id);
    }
}
