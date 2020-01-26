using System;
using ClinicAppointmentApp.DbManager;
using ClinicAppointmentApp.Repositories.Interfaces;
using System.Linq;

namespace ClinicAppointmentApp.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository()
        {

        }

        public Patient GetPatientByIdentificationNumber(string idNumber)
        {
            return _context.Patients.FirstOrDefault(x => x.IdentificationNumber == idNumber);
        }
    }
}
