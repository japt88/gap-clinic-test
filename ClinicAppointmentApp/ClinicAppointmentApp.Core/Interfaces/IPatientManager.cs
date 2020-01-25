using ClinicAppointmentApp.Dto;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core.Interfaces
{
    public interface IPatientManager
    {
        bool CreatePatient(Patient patientInfo);
        List<Patient> GetAllPatients();
        Patient GetPatient(int patientId);
        bool UpdatePatient(Patient patientInfo);
    }
}
