using DataRepository.DataRepositoryEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DataRepository.GateWay
{
    public class DbConext:DbContext
    {
       public DbConext()
        {
           

           

            
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            AppConfiguration configuration = new AppConfiguration();

          
            string conn = configuration.ConnectionString;

            optionsBuilder.UseSqlServer(conn);
         
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<VaccinationTypesRepository>().HasKey(o => o.Id);
            modelBuilder.Entity<RegistrarsRepository>().HasKey(o => o.Id);
            modelBuilder.Entity<VaccinationReservationRepository>().HasKey(o => o.Id);
            modelBuilder.Entity<SystemSettingsRepository>().HasKey(o => o.Id);

        }
    
    




        public  DbSet<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public DbSet<RegistrarsRepository> Registrars { get; set; }

        public DbSet<VaccinationReservationRepository> VaccinationReservation { get; set; }

        public DbSet<SystemSettingsRepository> SystemSettings { get; set; }


    }
}
