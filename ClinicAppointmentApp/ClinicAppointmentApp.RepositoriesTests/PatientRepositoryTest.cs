using ClinicAppointmentApp.Repositories;
using ClinicAppointmentApp.Repositories.Interfaces;
using NUnit.Framework;
using Unity;
using System.Linq;

namespace ClinicAppointmentApp.RepositoriesTests
{
    [TestFixture]
    public class PatientRepositoryTest
    {
        private static IUnityContainer _unityContainer;

        public PatientRepositoryTest()
        {
            _unityContainer = new UnityContainer()
                .RegisterType<IPatientRepository, PatientRepository>();
        }

        [TestCase("12345", "Chris", "Deford")]
        [TestCase("67890", "Susan", "Johnson")]
        public void T1_CreatePatient_Success(string idNumber, string firstName, string lastName)
        {
            var patientRepoitory = _unityContainer.Resolve<IPatientRepository>();
            var patient = new DbManager.Patient()
            {
                FirstName = firstName,
                LastName = lastName,
                IdentificationNumber = idNumber
            };
            patientRepoitory.Insert(patient);
            patientRepoitory.Save();
            Assert.IsTrue(patient.Id > 0);
        }

        [TestCase(1, "Christine")]
        [TestCase(2, "Anthony")]
        public void T2_UpdatePatient_Success(int id, string firstName)
        {
            var patientRepoitory = _unityContainer.Resolve<IPatientRepository>();
            var patient = patientRepoitory.GetById(id);
            patient.FirstName = firstName;
            patientRepoitory.Update(patient);
            patientRepoitory.Save();
            Assert.IsTrue(patient.FirstName == firstName);
        }

        [TestCase()]
        public void T3_GetAllPatients_Success()
        {
            var patientRepoitory = _unityContainer.Resolve<IPatientRepository>();
            var patients = patientRepoitory.GetAll();
            Assert.IsTrue(patients != null && patients.Count() > 0);
        }
    }
}
