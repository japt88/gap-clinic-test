using AutoMapper;

namespace ClinicAppointmentApp.Core.Mappings
{
    public class MappingConfiguration : Profile
    {

        
        public MappingConfiguration()
        {
            CreateMap<Dto.Appointment, DbManager.Appointment>();
            CreateMap<DbManager.Appointment, Dto.Appointment>();
            
            CreateMap<Dto.Patient, DbManager.Patient>();
            CreateMap<DbManager.Patient, Dto.Patient>();

            CreateMap<Dto.Specialization, DbManager.Specialization>();
            CreateMap<DbManager.Specialization, Dto.Specialization>();
        }
    }
}
