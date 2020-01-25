using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core
{
    public class AppointmentManager : IAppointmentManager
    {
        public bool CancelAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public bool CreateAppointment(Appointment appointmentInfo)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointmentsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAllAppointmentsByPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
