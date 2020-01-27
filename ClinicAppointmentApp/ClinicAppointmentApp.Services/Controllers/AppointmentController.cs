using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Portal.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class AppointmentController : ApiController
    {

        private IAppointmentManager _appointmentManager;
        private IMapper _mapper;
        public AppointmentController(IAppointmentManager appointmentManager, IMapper mapper)
        {
            _appointmentManager = appointmentManager;
            _mapper = mapper;
        }

        // GET: api/Appointment
        public IEnumerable<AppointmentModel> Get()
        {
            var appointments = _appointmentManager.GetAllAppointments();
            var mappedDto = MapAppointments(appointments);
            return mappedDto;
        }

        // GET: api/Appointment/5
        public AppointmentModel Get(int id)
        {
            var appointment = _appointmentManager.GetAppointmentById(id);
            var mappedDto = _mapper.Map<Dto.Appointment, AppointmentModel>(appointment);
            return mappedDto;
        }

        // POST: api/Appointment
        public Result Post(AppointmentModel value)
        {
            var mappedDto = _mapper.Map<AppointmentModel, Dto.Appointment>(value);
            return _appointmentManager.CreateAppointment(mappedDto);
        }

        // DELETE: api/Appointment/5
        public Result Cancel(int id)
        {
            return _appointmentManager.CancelAppointment(id);
        }



        private List<AppointmentModel> MapAppointments(List<Appointment> appointmentsDto)
        {
            if (appointmentsDto != null)
            {
                var appointments = new List<AppointmentModel>();
                foreach (var item in appointmentsDto)
                {
                    var model = _mapper.Map<Appointment, AppointmentModel>(item);
                    appointments.Add(model);
                }
                return appointments;
            }
            return null;
        }
    }
}
