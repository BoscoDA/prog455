using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Week5AuthenticationAuthorization.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Week5AuthenticationAuthorization.Services
{
    public class DBService
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();

        /// <summary>
        /// Returns 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserFromDB(string username)
        {
            return db.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        /// <summary>
        /// Returns full list of users from the users table of the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUserListFromDB()
        {
            return db.Users.ToList();
        }

        /// <summary>
        /// Deletes the user matching the id past into the function from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        /// <summary>
        /// Handles adding a new user to the database
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            user.Password = SHA256Util.CreateHash(user.Password);
            db.Users.Add(user);
            db.SaveChanges();
        }

        /// <summary>
        /// Updates the state of the user in the database
        /// </summary>
        /// <param name="user"></param>
        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}