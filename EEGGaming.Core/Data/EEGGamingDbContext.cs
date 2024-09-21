using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Data.NonDataModels;
using EEGGaming.Core.Managers;

using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;


namespace EEGGaming.Core.Data
{
    /// <summary>
    /// DbContext of the EEGGaming library
    /// </summary>
    public class EEGGamingDbContext :DbContext
    {
        /// <summary>
        /// The list of Users' table records
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// The list of GamingSession's table records
        /// </summary>
        public DbSet<GamingSesion> GameSession { get; set; }
        /// <summary>
        /// The list of Brainwaves' table records
        /// </summary>
        public DbSet<BrainwavesRecord> BrainWaves{ get; set; }
        public EEGGamingDbContext( )

        {
          
        }
        

        
        public EEGGamingDbContext(string DefaultConnection)  
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(AppSettingsManager.GetDefaultConnectionString());
           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<BrainwavesRecord>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();


        }
    }
}
