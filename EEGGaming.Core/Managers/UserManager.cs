using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Tools;
using Microsoft.EntityFrameworkCore;
using ScottPlot;
using ScottPlot.Palettes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EEGGaming.Core.Managers
{
    /// <summary>
    /// Class that manages user's and their info
    /// </summary>
    public class UserManager:BaseManager
    {
         /// <summary>
         /// Adds new user to the database
         /// </summary>
         /// <param name="user"> new user info</param>
        public void AddNew(User user)
        {
            try
            {
                if( user!=null)
                {
                    DbContext.Users.Add(user);
                    DbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }

        }
        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns>all the users</returns>
        public List<User> List ()
        {

            try
            {
                return DbContext.Users.ToList();

            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }
        /// <summary>
        /// Gets the user of the given id
        /// </summary>
        /// <param name="id">id of the user we are looking for </param>
        /// <returns>user of the given id</returns>
        public User GetUser(int id)
        {
            try
            {
                return DbContext.Users.FirstOrDefault(x => x.Id == id);

            }
            catch (Exception ex)
            {
               // throw;

                CommonTools.ErrorReporting(ex);
                return null;

            }
        }
        /// <summary>
        /// Gets the user of the given name
        /// </summary>
        /// <param name="name">name of the user we are looking for </param>
        /// <returns>user of the given name</returns>
        public User GetUser(string name)
        {
            try
            {
                return DbContext.Users.FirstOrDefault(x => x.Name == name);

            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }
        /// <summary>
        /// Edits the info of the user with the given id 
        /// </summary>
        /// <param name="id"> id of the user</param>
        /// <param name="user">new values of the user</param>
        public void Edit(int? id , User user)
        {
            try
            {
                if (user != null && id != null && user !=null)
                {
                    User olduser = this.GetUser((int)id);
                    if( olduser!=null )
                    {
                        this.DbContext.Entry(olduser).State = EntityState.Modified;

                        this.DbContext.Entry(olduser).CurrentValues.SetValues(user);
                         
                          this.DbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }
        /// <summary>
        /// Deletes theuser with the given nme
        /// </summary>
        /// <param name="username">name of the user tobeleteed </param>
        public void Delete(string username)
        {
            try
            {
                if (username != null)
                {
                    var user = this.GetUser(username);
                    if (user != null)
                    {
                        DbContext.Users.Remove(user);
                        DbContext.SaveChanges();
                    }


                }
            }
            catch (Exception ex)
            {
                throw;

                CommonTools.ErrorReporting(ex);

            }
        }

    }
}
