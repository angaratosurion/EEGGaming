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
    public class UserManager:BaseManager
    {
         
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
