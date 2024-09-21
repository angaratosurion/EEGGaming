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
{/// <summary>
/// The Class that manages the gaming sessin
/// </summary>
   public  class GamingSesionManager:BaseManager
    {
        /// <summary>
        /// Get all the gaming sessions
        /// </summary>
        /// <returns>all the gaming sessions</returns>
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
        /// <summary>
        /// Get all the gaming sessions as ViewModels
        /// </summary>
        /// <returns>all the gaming sessions as ViewModels</returns>
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
        /// <summary>
        /// Gets the gamingsession with the given Id
        /// </summary>
        /// <param name="id">id of the gamingsession</param>
        /// <returns>gamingsession with the given Id</returns>
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
        /// <summary>
        /// checks if a gamingsession has thegivn id 
        /// </summary>
        /// <param name="id"> the id of the gamingsession we are searching for </param>
        /// <returns>true if it exists false it isnt </returns>
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
        /// <summary>
        /// updates the gamingsession record
        /// </summary>
        /// <param name="gamingSesion"> the new values of gamingsession</param>
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
        /// <summary>
        /// Delete the record with thegiven id
        /// </summary>
        /// <param name="id">idof the record to bedeeted</param>
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
        /// <summary>
        /// Adds a new record to the gamingsession and it returns it 
        /// </summary>
        /// <param name="gamingSesion"> new recordof gamingsession to be added</param>
        /// <returns> new record to the gamingsession and it returns it </returns>
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
