using APIService.DALs;
using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService
{
    public class AuthService
    {
        UsersDAL _dal = new UsersDAL();

        public bool UsernameExist(string username)
        {
            var users = _dal.GetByUsername(username);
            return users.Count > 0;
        }

        public Guid AddUser(UserModel model)
        {
            return _dal.InsertUser(model);
        }

        public string ValidUsername(string username, string password)
        {
            var users = _dal.GetByUsername(username);
            if(users.Count <= 0)
            {
                //No user with that username is registered
                return string.Empty;
            }

            if (users[0].Password == password)
            {
                return users[0].Id.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
