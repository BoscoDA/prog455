using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DALs
{
    public interface IEncountersDAL
    {
        List<EncounterHistoryRecordModel> GetByUserId(Guid id);
        void UpdateEncounterById(EncounterRecordModel model);
        EncounterRecordModel GetEncounterById(Guid? id);
        Guid InsertEncounter(EncounterRecordModel model);
    }
}
