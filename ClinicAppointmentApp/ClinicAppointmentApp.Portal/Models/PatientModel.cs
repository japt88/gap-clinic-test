using System.Collections.Generic;

namespace ClinicAppointmentApp.Portal.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AppointmentModel> Appointments { get; set; }
    }
}