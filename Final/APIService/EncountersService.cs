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
        IEncountersDAL _dal;

        public EncountersService() 
        {
            _dal = new EncountersDAL();
        }

        public EncountersService(IEncountersDAL dal)
        {
            _dal = dal;
        }

        public List<EncounterHistoryRecordModel> GetAllEncounters(Guid id)
        {
            return _dal.GetByUserId(id);
        }
    }
}
