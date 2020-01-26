using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class AppointmentController : ApiController
    {

        private IAppointmentManager _appointmentManager;
        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        // GET: api/Appointment
        public IEnumerable<Appointment> Get()
        {
            return _appointmentManager.GetAllAppointments();
        }

        // GET: api/Appointment/5
        public Appointment Get(int id)
        {
            return _appointmentManager.GetAppointmentById(id);
        }

        // POST: api/Appointment
        public Result Post([FromBody]Appointment value)
        {
            return _appointmentManager.CreateAppointment(value);
        }

        // DELETE: api/Appointment/5
        public Result Cancel(int id, [FromBody]Appointment value)
        {
            return _appointmentManager.CancelAppointment(id);
        }
    }
}
