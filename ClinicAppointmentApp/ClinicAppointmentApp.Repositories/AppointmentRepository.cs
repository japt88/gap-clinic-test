using System;
using System.Collections.Generic;
using ClinicAppointmentApp.DbManager;
using ClinicAppointmentApp.Repositories.Interfaces;
using System.Linq;

namespace ClinicAppointmentApp.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository()
        {

        }
        public IEnumerable<Appointment> GetAppointments(DateTime date, TimeSpan startTime, int specializationId)
        {
            return _context.Appointments.Where(x => x.Date.Date == date.Date && x.StartTime == startTime && x.SpecializationId == specializationId);
        }

        public IEnumerable<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return _context.Appointments.Where(x => x.Date.Date == date.Date);
        }

        public IEnumerable<Appointment> GetAppointmentsByDateAndTime(DateTime date, TimeSpan startTime)
        {
            return _context.Appointments.Where(x => x.Date.Date == date.Date && x.StartTime == startTime);
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _context.Appointments.Where(x => x.PatientId == patientId);
        }
    }
}
