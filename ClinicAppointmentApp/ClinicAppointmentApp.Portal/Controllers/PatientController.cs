using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class PatientController : ApiController
    {
        private IPatientManager _patientManager;

        public PatientController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        // GET: api/Patient
        public IEnumerable<Patient> Get()
        {
            return _patientManager.GetAllPatients();
        }

        // GET: api/Patient/5
        public Patient Get(int id)
        {
            return _patientManager.GetPatient(id);
        }

        // POST: api/Patient
        public Result Post([FromBody]Patient patientInfo)
        {
            return _patientManager.CreatePatient(patientInfo);
        }

        // PUT: api/Patient/5
        public Result Put(int id, [FromBody]Patient patientInfo)
        {
            return _patientManager.UpdatePatient(patientInfo);
        }
    }
}
