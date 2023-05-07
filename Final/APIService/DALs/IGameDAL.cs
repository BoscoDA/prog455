using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DALs
{
    public interface IGameDAL
    {
        Guid InsertGameRecord(GameRecordModel model);
        GameRecordModel GetGameById(Guid id);
        void UpdateGameById(GameRecordModel model);
        
    }
}
