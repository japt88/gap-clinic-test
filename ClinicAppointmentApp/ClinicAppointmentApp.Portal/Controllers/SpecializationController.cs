using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class SpecializationController : ApiController
    {

        private ISpecializationManager _specializationManager;
        public SpecializationController(ISpecializationManager specializationManager)
        {
            _specializationManager = specializationManager;
        }

        // GET: api/Specialization
        public IEnumerable<Specialization> Get()
        {
            return _specializationManager.GetAllSpecializations();
        }
    }
}
