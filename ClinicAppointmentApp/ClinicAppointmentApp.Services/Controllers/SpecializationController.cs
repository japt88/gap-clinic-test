using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Portal.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class SpecializationController : ApiController
    {

        private ISpecializationManager _specializationManager;
        private IMapper _mapper;
        public SpecializationController(ISpecializationManager specializationManager, IMapper mapper)
        {
            _specializationManager = specializationManager;
            _mapper = mapper;
        }

        // GET: api/Specialization
        public IEnumerable<SpecializationModel> Get()
        {
            var spcializations = _specializationManager.GetAllSpecializations();
            var mappedModel = MapSpecializations(spcializations);
            return mappedModel;
        }

        private List<SpecializationModel> MapSpecializations(List<Specialization> specializationsDto)
        {
            if (specializationsDto != null)
            {
                var specs = new List<SpecializationModel>();
                foreach (var item in specializationsDto)
                {
                    var model = _mapper.Map<Specialization, SpecializationModel>(item);
                    specs.Add(model);
                }
                return specs;
            }
            return null;
        }
    }
}
