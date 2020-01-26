using ClinicAppointmentApp.Dto;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core.Interfaces
{
    public interface IAppointmentManager
    {
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAllAppointmentsByDate(DateTime date);
        List<Appointment> GetAllAppointmentsByPatient(int patientId);
        Result CreateAppointment(Appointment appointmentInfo);
        Result CancelAppointment(int appointmentId);
    }
}
