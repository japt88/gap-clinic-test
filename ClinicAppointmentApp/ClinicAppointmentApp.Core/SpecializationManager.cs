using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core
{
    public class SpecializationManager : ISpecializationManager
    {
        private ISpecializationRepository _specializationRepo;

        public SpecializationManager(ISpecializationRepository specializationRepo)
        {
            _specializationRepo = specializationRepo;
        }

        public List<Specialization> GetAllSpecializations()
        {
            //var spcecializations = _specializationRepo.GetAll();
            //return spcecializations;
            return null;
        }
    }
}
