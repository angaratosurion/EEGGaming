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

    /// <summary>
    /// The class representation of the packets containing the data coming from the headset
    /// </summary>
    public class Brainwaves
    {
        /// <summary>
        /// Thenumber of the packet
        /// </summary>
        public uint PackNumber { get; set; }
        /// <summary>
        /// The packet marker
        /// </summary>
        public byte Marker { get; set; }
        /// <summary>
        /// The date the packet is captured
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// The time  the packet is captured
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// The second the packet is captured
        /// </summary>
        public double Second { get; set; }
        /// <summary>
        /// The milisecond the packet is captured
        /// </summary>
        public double MiliSecond { get; set; }
        /// <summary>
        /// The average of Delta band value of the 2 channels 
        /// </summary>

        public double Delta_avgch { get; set; }
        /// <summary>
        /// The average of Theta band value of the 2 channels 
        /// </summary>
        public double Theta_avgch { get; set; }
        /// <summary>
        /// The average of Alpha band value of the 2 channels 
        /// </summary>
        public double Alpha1_avgch { get; set; }
        /// <summary>
        /// The average of Beta band value of the 2 channels 
        /// </summary>

        public double Beta1_avgch { get; set; }
        /// <summary>
        /// The average of Gamma band value of the 2 channels 
        /// </summary>

        public double Gamma1_avgch { get; set; }
        /// <summary>
        /// The average of Delta band  Relative value of the 2 channels 
        /// </summary>


        public double Delta_Rel_avgch { get; set; }
        /// <summary>
        /// The average of Theta band  Relative value of the 2 channels 
        /// </summary>
        public double Theta_Rel_avgch { get; set; }
        /// <summary>
        /// The average of Alpha band  Relative value of the 2 channels 
        /// </summary>
        public double Alpha1_Rel_avgch { get; set; }
        /// <summary>
        /// The average of Beta band  Relative value of the 2 channels 
        /// </summary>

        public double Beta1_Rel_avgch { get; set; }
        /// <summary>
        /// The average of Gamma band  Relative value of the 2 channels 
        /// </summary>

        public double Gamma1_Rel_avgch { get; set; }
        /// <summary>
        /// The  value of Delta band  from the channel 1
        /// </summary>

        public double Delta_ch1 { get; set; }
        /// <summary>
        /// The  value of Theta band  from the channel 1
        /// </summary>
        public double Theta_ch1 { get; set; }
        /// <summary>
        /// The  value of Alpha band  from the channel 1
        /// </summary>
        public double Alpha1_ch1 { get; set; }
        /// <summary>
        /// The  value of Beta band  from the channel 1
        /// </summary>

        public double Beta1_ch1 { get; set; }
        /// <summary>
        /// The  value of Gamma band  from the channel 1
        /// </summary>

        public double Gamma1_ch1 { get; set; }
        /// <summary>
        /// The  Relative value of Delta band  from the channel 1
        /// </summary>
        public double Delta_Rel_ch1 { get; set; }
        /// <summary>
        /// The  Relative value of Theta band  from the channel 1
        /// </summary>
        public double Theta_Rel_ch1 { get; set; }
        /// <summary>
        /// The  Relative value of Alpha band  from the channel 1
        /// </summary>
        public double Alpha1_Rel_ch1 { get; set; }
        /// <summary>
        /// The  Relative value of Beta band  from the channel 1
        /// </summary>

        public double Beta1_Rel_ch1 { get; set; }
        /// <summary>
        /// The  Relative value of Gamma band  from the channel 1
        /// </summary>
        public double Gamma1_Rel_ch1 { get; set; }
        /// <summary>
        /// The value of Delta band  from the channel  2
        /// </summary>
        public double Delta_ch2 { get; set; }
        /// <summary>
        /// The value of Theta band  from the channel  2
        /// </summary>
        public double Theta_ch2 { get; set; }
        /// <summary>
        /// The value of Alpha band  from the channel  2
        /// </summary>
        public double Alpha1_ch2 { get; set; }
        /// <summary>
        /// The value of Beta band  from the channel  2
        /// </summary>

        public double Beta1_ch2 { get; set; }
        /// <summary>
        /// The value of Gamma band  from the channel  2
        /// </summary>

        public double Gamma1_ch2 { get; set; }
        /// <summary>
        /// The Relative value of Delta band  from the channel  2
        /// </summary>
        public double Delta_Rel_ch2 { get; set; }
        /// <summary>
        /// The Relative value of Theta band  from the channel  2
        /// </summary>
        public double Theta_Rel_ch2 { get; set; }
        /// <summary>
        /// The Relative value of Alpha band  from the channel  2
        /// </summary>
        public double Alpha1_Rel_ch2 { get; set; }
        /// <summary>
        /// The Relative value of Beta band  from the channel  2
        /// </summary>

        public double Beta1_Rel_ch2 { get; set; }
        /// <summary>
        /// The Relative value of Gamma band  from the channel  2
        /// </summary>

        public double Gamma1_Rel_ch2 { get; set; }

         
        /// <summary>
        /// If user had blinked
        /// </summary>
        public bool Blinked { get; set; }



    }
}
