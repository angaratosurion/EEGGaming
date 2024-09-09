using EEGGaming.Core.Data.Models;
using EEGGaming.Core.Data.NonDataModels;
using EEGGaming.Core.Managers;

using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;


namespace EEGGaming.Core.Data
{

    public class EEGGamingDbContext :DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<GamingSesion> GameSession { get; set; }
        public DbSet<BrainwavesRecord> BrainWaves{ get; set; }
        public EEGGamingDbContext( )

        {
          
        }
        

        //public EEGGamingDbContext(DbContextOptions<EEGGamingDbContext> options) : base(options)
        //{
           
        //}
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
            //modelBuilder.Entity<BrainwavesRecord>()
            //    .Property(b => b.DateAndTime)
            //    .HasDefaultValueSql("getdate()-gettime()");
            modelBuilder.Entity<BrainwavesRecord>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();


        }
    }
}
