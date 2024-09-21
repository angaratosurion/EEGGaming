using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EEGGaming.Core.Data.Models
{
    /// <summary>
    /// The class representation of the Gamingsession table from the database
    /// </summary>
    public class GamingSesion
    {
        /// <summary>
        /// An auto-incremented value id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The time and date the gaming session start
        /// </summary>
        [Required]
        public DateTime  Start { get; set; }
        /// <summary>
        /// The time and date the gaming session end
        /// </summary>
        [Required]
        public DateTime End { get; set; }
        /// <summary>
        /// The user'sid that plays in the current session 
        /// </summary>
      
        [Required]
        public int User { get; set; }
        /// <summary>
        /// The score the user scored in this gaming session
        /// </summary>
        [Required]
        public double Score { get; set; }
    }
}
