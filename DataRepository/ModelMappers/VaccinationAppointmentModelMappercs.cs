using DataModel;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataRepository.ModelMappers
{

    public class VaccinationAppointmentModelMapper
    {
        DataBaseGateWay<VaccinationReservationRepository> dataBaseGateWay;
        public VaccinationAppointmentModelMapper()
        {
            dataBaseGateWay = new DataBaseGateWay<VaccinationReservationRepository>();
        }

        public void AddVaccinationType(VaccinationReservationDataModel model)
        {
            VaccinationReservationRepository vaccinationReservation  = new VaccinationReservationRepository();

            vaccinationReservation.RegistrarId =(int) model.RegistrarId;
            vaccinationReservation.VaccinationTypeId =(int) model.VaccinationTypeId;
            vaccinationReservation.ReservationDateTime = model.ReservationDateTime;
            dataBaseGateWay.Add(vaccinationReservation);

        }

        public void Edit(VaccinationReservationDataModel model)
        {
            VaccinationReservationRepository vaccinationReservation  = new VaccinationReservationRepository();
            vaccinationReservation.RegistrarId = (int)model.RegistrarId;
            vaccinationReservation.VaccinationTypeId = (int)model.VaccinationTypeId;
            vaccinationReservation.ReservationDateTime = model.ReservationDateTime;
            dataBaseGateWay.Edit(vaccinationReservation);
        }

        public void Delete(int id)
        {
            VaccinationTypesRepository vaccinationTypes;
            VaccinationReservationRepository vaccinationReservation = dataBaseGateWay.GetById(c => c.Id == id);
            dataBaseGateWay.Delete(vaccinationReservation);

        }

        public VaccinationReservationDataModel GetById(int id)
        {
            DataBaseGateWay<RegistrarsRepository> RegistrarsDataBaseGateWay;
            DataBaseGateWay<VaccinationTypesRepository> VaccinationTypeDataBaseGateWay;
            RegistrarsRepository registrar;
            VaccinationTypesRepository VaccinationTypes;

            VaccinationReservationRepository vaccinationReservation = dataBaseGateWay.GetById(c => c.Id == id);
            RegistrarsDataBaseGateWay = new DataBaseGateWay<RegistrarsRepository>();
            VaccinationTypeDataBaseGateWay = new DataBaseGateWay<VaccinationTypesRepository>();

             registrar = RegistrarsDataBaseGateWay.GetById(c=>c.Id==vaccinationReservation.RegistrarId);
            VaccinationTypes = VaccinationTypeDataBaseGateWay.GetById(c => c.Id == vaccinationReservation.VaccinationTypeId);
            return new VaccinationReservationDataModel
            {
                Id = vaccinationReservation.Id,
                RegistrarId = vaccinationReservation.RegistrarId,
                Registrar=new RegistrarsDataModel { Name=registrar.Name,Telephone=registrar.Telephone},
                VaccinationType= new VaccinationTypesDataModel { Name=VaccinationTypes.Name},

                ReservationDateTime = vaccinationReservation.ReservationDateTime
            };

        }

        public List<VaccinationTypesDataModel> list()
        {


            //List<VaccinationTypesRepository> vaccinationTypesRepositories = dataBaseGateWay.List();
            //return (from r in vaccinationTypesRepositories
            //        select new VaccinationTypesDataModel
            //        {
            //            Id = r.Id,
            //            Name = r.Name
            //        }).ToList();
            return null;
        }
    }

}

}