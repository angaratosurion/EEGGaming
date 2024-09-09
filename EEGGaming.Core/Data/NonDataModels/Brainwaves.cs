using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EEGGaming.Core.Data.NonDataModels
{
    public class Brainwaves
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public int Id { get; set; }
        //[Required]
        //public int UserId { get; set; }
        //[Required]
        //public int GamingSessionId { get; set; }
        //[Required]
        //// [DefaultValue(typeof(DateTime), value: DateTime.Now.ToString("dd-MM-yyy:hh:mm:ss"))]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public uint PackNumber { get; set; }
        public byte Marker { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double Second { get; set; }
        public double MiliSecond { get; set; }

        public double Delta_avgch { get; set; }
        public double Theta_avgch { get; set; }
        public double Alpha1_avgch { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_avgch { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_avgch { get; set; }


        public double Delta_Rel_avgch { get; set; }
        public double Theta_Rel_avgch { get; set; }
        public double Alpha1_Rel_avgch { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_Rel_avgch { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_Rel_avgch { get; set; }

        public double Delta_ch1 { get; set; }
        public double Theta_ch1 { get; set; }
        public double Alpha1_ch1 { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_ch1 { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_ch1 { get; set; }


        public double Delta_Rel_ch1 { get; set; }
        public double Theta_Rel_ch1 { get; set; }
        public double Alpha1_Rel_ch1 { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_Rel_ch1 { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_Rel_ch1 { get; set; }
        public double Delta_ch2 { get; set; }
        public double Theta_ch2 { get; set; }
        public double Alpha1_ch2 { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_ch2 { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_ch2 { get; set; }


        public double Delta_Rel_ch2 { get; set; }
        public double Theta_Rel_ch2 { get; set; }
        public double Alpha1_Rel_ch2 { get; set; }
        // public double Alpha2 { get; set; }
        public double Beta1_Rel_ch2 { get; set; }
        //  public double Beta2 { get; set; }
        public double Gamma1_Rel_ch2 { get; set; }

        //  public double Beta2 { get; set; }

        public bool Blinked { get; set; }



    }
}
