using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEGGaming.Core.Data.NonDataModels
{
    public  class GmingSessionViewModel:GamingSesion
    {
        [Required]
        // [Key]
        public string UserName { get; set; }
        public void ImportToModel(GamingSesion model)
        {
            if (model != null)
            {
                this.Id=model.Id;
                this.User=model.User;
                this.Start=model.Start;
                this.End=model.End; 
                this.Score=model.Score;
                UserManager userManager = new UserManager();
                var usr = userManager.GetUser(this.User);
                if (usr != null)
                {
                    this.UserName = usr.Name;
                }
            }

        }
    }
}
