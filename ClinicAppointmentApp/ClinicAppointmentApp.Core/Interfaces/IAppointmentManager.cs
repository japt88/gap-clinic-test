using ClinicAppointmentApp.Dto;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core.Interfaces
{
    public interface IAppointmentManager
    {
        List<Appointment> GetAllAppointmentsByDate(DateTime date);
        List<Appointment> GetAllAppointmentsByPatient(int patientId);
        bool CreateAppointment(Appointment appointmentInfo);
        bool CancelAppointment(int appointmentId);
    }
}
