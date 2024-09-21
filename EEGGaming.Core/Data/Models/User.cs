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

        /// <summary>
        /// An auto-incremented value id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        
        public int Id { get; set; }
        /// <summary>
        /// The name of the user
        /// </summary>
        [Required]
       // [Key]
        public string Name { get; set; }
        /// <summary>
        /// the sex of the user
        /// </summary>
        [Required]
        public string Sex { get; set; }
        /// <summary>
        ///  the age of the user
        /// </summary>
        [Required]
        public int Age { get; set; }
        /// <summary>
        /// The education level of the user
        /// </summary>
        [Required]
        public string Education { get; set; }
    }
}
