using System;

namespace ClinicAppointmentApp.Dto
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }

        public Patient Patient { get; set; }
        public Specialization Specialization { get; set; }
    }
}
