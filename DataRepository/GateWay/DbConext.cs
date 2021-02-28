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
            string conn= "Data Source=U-PC\\SQLEXPRESS;Initial Catalog=CovidVaccinationAppointment;User ID=sa;Password=sa1234";
            optionsBuilder.UseSqlServer(conn);
         
        }

         DbSet<VaccinationTypesRepository> VaccinationTypes { get; set; }

         DbSet<RegistrarsRepository> Registrars { get; set; }

         DbSet<VaccinationReservationRepository> VaccinationReservation { get; set; }


    }
}
