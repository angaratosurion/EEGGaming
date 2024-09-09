﻿using EEGGaming.Core.Data.NonDataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEGGaming.Core.Data.Models
{
    public  class BrainwavesRecord:Brainwaves
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GamingSessionId { get; set; }
        public void ImportToModel(Brainwaves model)
        {
            if ( model!=null)
            {
                this.Alpha1_avgch = model.Alpha1_avgch;
                this.Alpha1_Rel_avgch = model.Alpha1_Rel_avgch;
                this.Beta1_avgch = model.Beta1_avgch; 
                this.Beta1_Rel_avgch = model.Beta1_Rel_avgch;
                this.Delta_avgch = model.Delta_avgch;
                this.Delta_Rel_avgch = model.Delta_Rel_avgch;
                this.Theta_avgch = model.Theta_avgch;
                this.Theta_Rel_avgch = model.Theta_Rel_avgch;

                this.Alpha1_ch1 = model.Alpha1_ch1;
                this.Alpha1_Rel_ch1 = model.Alpha1_Rel_ch1;
                this.Beta1_ch1 = model.Beta1_ch1;
                this.Beta1_Rel_ch1 = model.Beta1_Rel_ch1;
                this.Delta_ch1 = model.Delta_ch1;
                this.Delta_Rel_ch1 = model.Delta_Rel_ch1;
                this.Theta_ch1 = model.Theta_ch1;
                this.Theta_Rel_ch1 = model.Theta_Rel_ch1;

                this.Alpha1_ch2 = model.Alpha1_ch2;
                this.Alpha1_Rel_ch2 = model.Alpha1_Rel_ch2;
                this.Beta1_ch2 = model.Beta1_ch2;
                this.Beta1_Rel_ch2 = model.Beta1_Rel_ch2;
                this.Delta_ch2 = model.Delta_ch2;
                this.Delta_Rel_ch2 = model.Delta_Rel_ch2;
                this.Theta_ch2 = model.Theta_ch2;
                this.Theta_Rel_ch2 = model.Theta_Rel_ch2;


                this.Date= model.Date;
                this.Time = model.Time;
                this.Second= model.Second;
                this.MiliSecond=model.MiliSecond;
                this.Marker= model.Marker;
                this.PackNumber= model.PackNumber;
                this.Blinked=model.Blinked;
            }

        }
        
    }
}
