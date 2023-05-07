using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DALs
{
    public interface IUserDAL
    {
        List<UserRecordModel> GetByUsername(string username);
        Guid InsertUser(UserRecordModel model);
    }
}
