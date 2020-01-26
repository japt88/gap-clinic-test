using ClinicAppointmentApp.Repositories;
using ClinicAppointmentApp.Repositories.Interfaces;
using Unity;
using Unity.Extension;

namespace ClinicAppointmentApp.Core
{
    public class CoreRegisterExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            Container.RegisterType<IPatientRepository, PatientRepository>();
            Container.RegisterType<ISpecializationRepository, SpecializationRepository>();
            
        }
    }
}
