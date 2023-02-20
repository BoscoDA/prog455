using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Week4Databases.Services
{
    public class Service
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();

        /// <summary>
        /// Returns the character matching the id past into the function from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Character ReturnCharacter(int? id)
        {
            return db.Characters.Find(id);
        }

        /// <summary>
        /// Returns a list of all the characters in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Character> ReturnCharacterList()
        {
            return db.Characters.ToList();
        }

        /// <summary>
        /// Deletes the character matching the id past into the function from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCharacter(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
        }

        /// <summary>
        /// Handles adding a new character to the database
        /// </summary>
        /// <param name="character"></param>
        public void CreateCharacter(Character character)
        {
            db.Characters.Add(character);
            db.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void EditCharacter(Character character)
        {
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}