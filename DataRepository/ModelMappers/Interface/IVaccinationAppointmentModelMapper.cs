using DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.ModelMappers.Interface
{
   public interface IVaccinationAppointmentModelMapper
    {
        void AddVaccinationReservation(VaccinationReservationDataModel model);
        void Edit(VaccinationReservationDataModel model);
        void Delete(int id);
        VaccinationReservationDataModel GetById(int id);

        List<VaccinationTypesDataModel> list();

    }
}
