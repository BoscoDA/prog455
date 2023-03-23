using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week3Databases.Services
{
    public class Service
    {
        private PROG455FA23Entities db = new PROG455FA23Entities();

        /// <summary>
        /// Returns the character matching the id past into the function from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Character ReturnCharacter(int? id)
        {
            try
            {
                var character = db.Characters.Find(id);
                return character;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("Could not find that character in the database.", ex);
            }
        }

        /// <summary>
        /// Returns a list of all the characters in the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Character> ReturnCharacterList()
        {
            try
            {
                var characters = db.Characters.ToList();
                return characters;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Database operation failed", ex);
            }
        }

        /// <summary>
        /// Deletes the character matching the id past into the function from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCharacter(int id)
        {
            try
            {
                Character character = db.Characters.Find(id);
                db.Characters.Remove(character);
                db.SaveChanges();
            }
            catch(InvalidOperationException ex)
            {
                throw new Exception("Database operation failed", ex);
            }
        }

        /// <summary>
        /// Handles adding a new character to the database
        /// </summary>
        /// <param name="character"></param>
        public void CreateCharacter(Character character)
        {
            try
            {
                db.Characters.Add(character);
                db.SaveChanges();
            }
            catch(DbUpdateException ex) { throw new Exception("Database operation failed", ex); }
            catch (DbEntityValidationException ex) { throw new Exception("Database operation failed", ex); }
            catch (NotSupportedException ex) { throw new Exception("Database operation failed", ex); }
            catch (ObjectDisposedException ex) { throw new Exception("Database operation failed", ex); }
            catch (InvalidOperationException ex) { throw new Exception("Database operation failed", ex); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void EditCharacter(Character character)
        {
            try
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateException ex) { throw new Exception("Database operation failed", ex); }
            catch (DbEntityValidationException ex) { throw new Exception("Database operation failed", ex); }
            catch (NotSupportedException ex) { throw new Exception("Database operation failed", ex); }
            catch (ObjectDisposedException ex) { throw new Exception("Database operation failed", ex); }
            catch (InvalidOperationException ex) { throw new Exception("Database operation failed", ex); }
        }
    }
}