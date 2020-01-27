using System;

namespace ClinicAppointmentApp.Portal.Models
{
    public class AppointmentModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }

        public PatientModel Patient { get; set; }
        public SpecializationModel Specialization { get; set; }
    }
}