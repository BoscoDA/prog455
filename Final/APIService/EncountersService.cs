using APIService.DALs;
using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class EncountersService
    {

        EncountersDAL _dal = new EncountersDAL();

        public List<EncounterRecordModel> GetAllEncounters(Guid id)
        {
            return _dal.GetById(id);
        }
    }
}
