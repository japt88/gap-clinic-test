using ClinicAppointmentApp.Dto;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core.Interfaces
{
    public interface IPatientManager
    {
        Result CreatePatient(Patient patientInfo);
        List<Patient> GetAllPatients();
        Patient GetPatient(int patientId);
        Result UpdatePatient(Patient patientInfo);
    }
}
