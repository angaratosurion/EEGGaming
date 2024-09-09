using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Data;
using EEGGaming.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEGGaming.Core.Data.NonDataModels;

namespace EEGGaming.Core.Managers
{
   public  class GamingSesionManager:BaseManager
    {
       // EEGGamingDbContext db = new EEGGamingDbContext();
        public List<GamingSesion> List()
        {
            try
            {
                return this.DbContext.GameSession.ToList();
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);

                return null;


            }
        }
        public List<GmingSessionViewModel> ListasViewModel()
        {
            try
            {
                List<GmingSessionViewModel> ap = null;
                var sessions = this.List();
                if (sessions != null)
                {
                    ap = new List<GmingSessionViewModel>();
                    foreach (var session in sessions)
                    {
                        GmingSessionViewModel vm = new GmingSessionViewModel();
                        vm.ImportToModel(session);
                        ap.Add(vm);
                    }

                }
                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);

                return null;


            }
        }
        public GamingSesion Get(int id)
        {
            try
            { GamingSesion ap= null;
                ap= this.DbContext.GameSession.Find(id);
                //if (ap != null)
                //{

                    return ap;
            //}
            //    else
            //{
            //    ap = new GamingSesion();
            //    return ap;
            //}
        }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return null;


            }
        }
        public bool Exists(int id)
        {
            try
            {
                bool exists = false;

                if (this.Get(id) != null)
                { exists = true; }

                return exists;

            }
            catch (Exception ex)
            {
                return false;


            }
        }
        public void Update(GamingSesion gamingSesion)
        {
            try
            {
                if (gamingSesion != null && this.Exists(gamingSesion.Id))
                {

                    var oldvalues = this.Get(gamingSesion.Id);
                    this.DbContext.Entry(oldvalues).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    this.DbContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


            }
        }
        public void Delete(int id)
        {
            try
            {
                if (this.Exists(id))
                {
                    var  tobedelete = this.Get(id);
                   this.DbContext.GameSession.Remove( tobedelete);
                    this.DbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


            }
        }
        public GamingSesion AddGamingSession(GamingSesion gamingSesion)
        {
            try
            {
                GamingSesion ap = null;
                int id = this.PredictLastId("GamingSesion") +1;
                gamingSesion.Id= id;
               this.DbContext.GameSession.Add(gamingSesion);
                this.DbContext.SaveChanges();
                ap = gamingSesion;
                return ap;
            }
            catch (Exception ex)
            {
                throw;
                CommonTools.ErrorReporting(ex);
                return null;

            }
        }
    }
}
