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
            //string conn= "Data Source=U-PC\\SQLEXPRESS;Initial Catalog=CovidVaccinationAppointment;User ID=sa;Password=sa1234";
            string conn = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =C:\\Users\\balshabani\\Source\\Repos\\basemsha3bani\\CovidVaccinationAppointment\\DataRepository\\CovidVaccinationProject.mdf; Integrated Security = True";
            optionsBuilder.UseSqlServer(conn);
         
        }

       public  DbSet<VaccinationTypesRepository> VaccinationTypes { get; set; }

        public DbSet<RegistrarsRepository> Registrars { get; set; }

        public DbSet<VaccinationReservationRepository> VaccinationReservation { get; set; }


    }
}
