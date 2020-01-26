using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core
{
    public class PatientManager : IPatientManager
    {
        private IPatientRepository _patientRepo;
        private readonly IMapper _mapper;

        public PatientManager(IPatientRepository patientRepo, IMapper mapper)
        {
            _patientRepo = patientRepo;
            _mapper = mapper;
        }

        public Result CreatePatient(Patient patientInfo)
        {
            try
            {
                //Check if patient exists
                var patientExists = _patientRepo.GetPatientByIdentificationNumber(patientInfo.IdentificationNumber);
                if (patientExists != null)
                    return new Result() { Status = false, Message = "The patient already exists." };

                //Convert to Dao
                var patientDao = _mapper.Map<Patient, DbManager.Patient>(patientInfo);

                //Insert element
                _patientRepo.Insert(patientDao);
                _patientRepo.Save();
                return new Result() { IdResult = patientDao.Id, Status = true, Message = "The patient has been successfully saved." };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, Message = "An exception has occurred, please try again." };
            }
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                var patients = _patientRepo.GetAll();
                var patientsDto = MapPatients(patients);
                return patientsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Patient GetPatient(int patientId)
        {
            try
            {
                var patient = _patientRepo.GetById(patientId);
                var patientDto = _mapper.Map<DbManager.Patient, Patient>(patient);
                return patientDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Result UpdatePatient(Patient patientInfo)
        {
            try
            {
                //Check if patient exists
                var patientExists = _patientRepo.GetPatientByIdentificationNumber(patientInfo.IdentificationNumber);
                if (patientExists == null)
                    return new Result() { Status = false, Message = "The patient doesn't exists." };

                //Convert to Dao
                var patientDao = _mapper.Map<Patient, DbManager.Patient>(patientInfo);

                //Insert element
                _patientRepo.Update(patientDao);
                _patientRepo.Save();
                return new Result() { IdResult = patientDao.Id, Status = true, Message = "The patient has been successfully updated." };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, Message = "An exception has occurred, please try again." };
            }
        }


        private List<Patient> MapPatients(IEnumerable<DbManager.Patient> patientsDao)
        {
            if (patientsDao != null)
            {
                var patientList = new List<Patient>();
                foreach (var item in patientsDao)
                {
                    var patientDto = _mapper.Map<DbManager.Patient, Patient>(item);
                    patientList.Add(patientDto);
                }
                return patientList;
            }
            return null;
        }
    }
}
