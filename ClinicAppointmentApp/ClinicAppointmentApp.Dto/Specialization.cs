using System.Collections.Generic;

namespace ClinicAppointmentApp.Dto
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
