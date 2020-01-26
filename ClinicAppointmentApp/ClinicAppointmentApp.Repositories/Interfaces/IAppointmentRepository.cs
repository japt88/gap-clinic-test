using ClinicAppointmentApp.DbManager;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsByDateAndTime(DateTime date, TimeSpan startTime);
        IEnumerable<Appointment> GetAppointments(DateTime date, TimeSpan startTime, int specializationId);
        IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
        IEnumerable<Appointment> GetAppointmentsByDate(DateTime date);
    }
}
