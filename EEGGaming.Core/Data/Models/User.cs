using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEGGaming.Core.Data.Models
{
    public  class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        
        public int Id { get; set; }
        [Required]
       // [Key]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Education { get; set; }
    }
}
