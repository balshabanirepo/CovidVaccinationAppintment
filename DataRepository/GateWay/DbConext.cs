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

       public  DbSet<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public DbSet<RegistrarsRepository> Registrars { get; set; }

        public DbSet<VaccinationReservationRepository> VaccinationReservation { get; set; }


    }
}
