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
        IUserDAL _dal;

        public AuthService()
        {
            _dal = new UsersDAL();
        }

        public AuthService(IUserDAL dal)
        {
            _dal = dal;
        }

        public bool UsernameExist(string username)
        {
            var users = _dal.GetByUsername(username);
            return users.Count <= 0;
        }

        public Guid AddUser(UserRecordModel model)
        {
            return _dal.InsertUser(model);
        }

        public string ValidLogin(string username, string password)
        {
            var users = _dal.GetByUsername(username);
            if(users.Count <= 0)
            {
                //No user with that username is registered
                return string.Empty;
            }

            if (Utilities.HashUtil.CheckPassword(password,users[0].Salt, users[0].Password))
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
