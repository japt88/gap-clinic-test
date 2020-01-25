using ClinicAppointmentApp.Dto;
using System.Collections.Generic;

namespace ClinicAppointmentApp.Core.Interfaces
{
    public interface ISpecializationManager
    {
        List<Specialization> GetAllSpecializations();
    }
}
