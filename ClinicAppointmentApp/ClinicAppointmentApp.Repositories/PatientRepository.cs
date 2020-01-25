using ClinicAppointmentApp.DbManager;
using ClinicAppointmentApp.Repositories.Interfaces;

namespace ClinicAppointmentApp.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
    }
}
