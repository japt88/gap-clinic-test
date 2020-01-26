using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Repositories;
using ClinicAppointmentApp.Repositories.Interfaces;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core
{
    public class SpecializationManager : ISpecializationManager
    {

        private ISpecializationRepository _specializationRepo;
        private readonly IMapper _mapper;

        public SpecializationManager(ISpecializationRepository specializationRepo, IMapper mapper)
        {
            _specializationRepo = specializationRepo ?? new SpecializationRepository();
            _mapper = mapper;
        }

        public List<Specialization> GetAllSpecializations()
        {
            var spcecializations = _specializationRepo.GetAll();
            var spcecializationsDto = MapSpecializations(spcecializations);
            return spcecializationsDto;
        }

        private List<Specialization> MapSpecializations(IEnumerable<DbManager.Specialization> specializationsDao)
        {
            if (specializationsDao != null)
            {
                var specializationsList = new List<Specialization>();
                foreach (var item in specializationsDao)
                {
                    var specializationDto = _mapper.Map<DbManager.Specialization, Specialization>(item);
                    specializationsList.Add(specializationDto);
                }
                return specializationsList;
            }
            return null;
        }
    }
}
