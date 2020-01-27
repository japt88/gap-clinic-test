using ClinicAppointmentApp.Repositories;
using ClinicAppointmentApp.Repositories.Interfaces;
using NUnit.Framework;
using Unity;
using System;
using System.Linq;

namespace ClinicAppointmentApp.RepositoriesTests
{
    [TestFixture]
    public class AppointmentRepositoryTest
    {
        private static IUnityContainer _unityContainer;

        public AppointmentRepositoryTest()
        {
            _unityContainer = new UnityContainer()
                .RegisterType<IAppointmentRepository, AppointmentRepository>();
        }


        [TestCase(1, 1, "30/01/2020", "9:00", 20)]
        [TestCase(2, 2, "01/02/2020", "11:00", 30)]
        public void T1_CreateAppointment_Success(int patientIdNumber, int specializationId, string date, string startTime, double duration)
        {
            var appRepoitory = _unityContainer.Resolve<IAppointmentRepository>();
            var appointmentDate = Convert.ToDateTime(date);
            var startTimeApp = TimeSpan.Parse(startTime);
            var endTimeApp = startTimeApp.Add(TimeSpan.FromMinutes(duration));


            var appointment = new DbManager.Appointment()
            {
                PatientId = patientIdNumber,
                Date = appointmentDate,
                StartTime = startTimeApp,
                EndTime = endTimeApp,
                SpecializationId = specializationId

            };
            appRepoitory.Insert(appointment);
            appRepoitory.Save();
            Assert.IsTrue(appointment.Id > 0);
        }

        [TestCase()]
        public void T2_GetAllAppointments_Success()
        {
            var appRepoitory = _unityContainer.Resolve<IAppointmentRepository>();
            var apps = appRepoitory.GetAll();
            Assert.IsTrue(apps != null && apps.Count() > 0);
        }


        [TestCase(3)]
        public void T3_DeleteAppointment_Success(int appointmentId)
        {
            var appRepoitory = _unityContainer.Resolve<IAppointmentRepository>();
            appRepoitory.Delete(appointmentId);
            appRepoitory.Save();

            var deletedApp = appRepoitory.GetById(appointmentId);
            Assert.IsTrue(deletedApp == null);
        }


        [TestCase(1)]
        [TestCase(2)]
        public void T4_GetAppointmentByPatient_Success(int patientId)
        {
            var appRepoitory = _unityContainer.Resolve<IAppointmentRepository>();
            var apps = appRepoitory.GetAppointmentsByPatientId(patientId);
            Assert.IsTrue(apps != null && apps.Count() > 0);
        }
    }
}
