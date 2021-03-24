using DataModel;
using DataRepository.GateWay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataRepository.ModelMappers.Interface;
namespace DataRepository.ModelMappers
{

    public class VaccinationAppointmentModelMapper: IVaccinationAppointmentModelMapper
    {
        RepositoryGateWay<VaccinationReservationRepository> _repositoryGateWay;
              public VaccinationAppointmentModelMapper()
        {
            _repositoryGateWay = new RepositoryGateWay<VaccinationReservationRepository>();
        }

        public void AddVaccinationReservation(VaccinationReservationDataModel model)
        {
            VaccinationReservationRepository vaccinationReservation  = new VaccinationReservationRepository();

            vaccinationReservation.RegistrarId =(int) model.RegistrarId;
            vaccinationReservation.VaccinationTypeId =(int) model.VaccinationTypeId;
            vaccinationReservation.ReservationDateTime = model.ReservationDateTime;
            _repositoryGateWay.Add(vaccinationReservation);
            
        }

        public void Edit(VaccinationReservationDataModel model)
        {
            VaccinationReservationRepository vaccinationReservation  = new VaccinationReservationRepository();
            vaccinationReservation.RegistrarId = (int)model.RegistrarId;
            vaccinationReservation.VaccinationTypeId = (int)model.VaccinationTypeId;
            vaccinationReservation.ReservationDateTime = model.ReservationDateTime;
            _repositoryGateWay.Edit(vaccinationReservation);
        }

        public void Delete(int id)
        {
            VaccinationTypesRepository vaccinationTypes;
            VaccinationReservationRepository vaccinationReservation = _repositoryGateWay.GetById(c => c.Id == id);
            _repositoryGateWay.Delete(vaccinationReservation);

        }

        public VaccinationReservationDataModel GetById(int id)
        {
            RepositoryGateWay<RegistrarsRepository> RegistrarsDataBaseGateWay;
            RepositoryGateWay<VaccinationTypesRepository> VaccinationTypeDataBaseGateWay;
            RegistrarsRepository registrar;
            VaccinationTypesRepository VaccinationTypes;

            VaccinationReservationRepository vaccinationReservation = _repositoryGateWay.GetById(c => c.Id == id);
            RegistrarsDataBaseGateWay = new RepositoryGateWay<RegistrarsRepository>();
            VaccinationTypeDataBaseGateWay = new RepositoryGateWay<VaccinationTypesRepository>();

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


            return null;
          
        }
    }

}

