using System;
using System.Collections.Generic;
using ClinicAppointmentApp.DbManager;
using ClinicAppointmentApp.Repositories.Interfaces;
using System.Linq;

namespace ClinicAppointmentApp.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAppointmentsByDateAndTime(DateTime date, DateTime startTime)
        {
            return _context.Appointments.Where(x => x.Date.Date == date.Date && x.StartTime.ToString("hh:mm") == startTime.ToString("hh:mm"));
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _context.Appointments.Where(x => x.PatientId == patientId);
        }
    }
}
