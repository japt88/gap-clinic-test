using ClinicAppointmentApp.DbManager;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAppointmentsByDateAndTime(DateTime date, DateTime startTime);
        IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
    }
}
