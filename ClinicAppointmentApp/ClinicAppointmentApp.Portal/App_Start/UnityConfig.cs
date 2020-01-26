using AutoMapper;
using ClinicAppointmentApp.Core;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Core.Mappings;
using ClinicAppointmentApp.Portal.Models;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ClinicAppointmentApp.Portal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.AddNewExtension<CoreRegisterExtension>();
            
            container.RegisterType<IAppointmentManager, AppointmentManager>();
            container.RegisterType<IPatientManager, PatientManager>();
            container.RegisterType<ISpecializationManager, SpecializationManager>();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingConfiguration>();

                cfg.CreateMap<Dto.Patient, PatientModel>();
                cfg.CreateMap<PatientModel, Dto.Patient>();
                cfg.CreateMap<Dto.Appointment, AppointmentModel>();
                cfg.CreateMap<AppointmentModel, Dto.Appointment>();
                cfg.CreateMap<Dto.Specialization, SpecializationModel>();
                cfg.CreateMap<SpecializationModel, Dto.Specialization>();

            });
            container.RegisterInstance(config.CreateMapper());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}