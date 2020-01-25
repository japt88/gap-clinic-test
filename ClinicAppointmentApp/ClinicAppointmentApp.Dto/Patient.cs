using System.Collections.Generic;

namespace ClinicAppointmentApp.Dto
{
    public class Patient
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }              
        public List<Appointment> Appointments { get; set; }
    }
}
