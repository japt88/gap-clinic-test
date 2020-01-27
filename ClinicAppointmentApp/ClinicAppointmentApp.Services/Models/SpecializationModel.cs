using System.Collections.Generic;

namespace ClinicAppointmentApp.Portal.Models
{
    public class SpecializationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public List<AppointmentModel> Appointments { get; set; }
    }
}