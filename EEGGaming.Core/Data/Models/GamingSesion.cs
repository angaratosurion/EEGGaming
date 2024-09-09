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
    public class GamingSesion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime  Start { get; set; }
        [Required]
        public DateTime End { get; set; }
      
        [Required]
        public int User { get; set; }
        [Required]
        public double Score { get; set; }
    }
}
