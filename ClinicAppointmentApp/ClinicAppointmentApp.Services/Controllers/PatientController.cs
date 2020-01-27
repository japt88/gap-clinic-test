using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Portal.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ClinicAppointmentApp.Portal.Controllers
{
    public class PatientController : ApiController
    {
        private IPatientManager _patientManager;
        private IMapper _mapper;

        public PatientController(IPatientManager patientManager, IMapper mapper)
        {
            _patientManager = patientManager;
            _mapper = mapper;
        }

        // GET: api/Patient
        public IEnumerable<PatientModel> Get()
        {
            var patientsDto = _patientManager.GetAllPatients();
            var mappedDto = MapPatients(patientsDto);
            return mappedDto;
        }

        // GET: api/Patient/5
        public PatientModel Get(int id)
        {
            var patientDto = _patientManager.GetPatient(id);
            var mappedDto = _mapper.Map<Dto.Patient, PatientModel>(patientDto);
            return mappedDto;
        }

        // POST: api/Patient
        public Result Post([FromBody]PatientModel patientInfo)
        {
            var mappedDto = _mapper.Map<PatientModel, Dto.Patient>(patientInfo);
            return _patientManager.CreatePatient(mappedDto);
        }

        // PUT: api/Patient/5
        public Result Put(int id, [FromBody]PatientModel patientInfo)
        {
            var mappedDto = _mapper.Map<PatientModel, Dto.Patient>(patientInfo);
            return _patientManager.UpdatePatient(mappedDto);
        }

        private List<PatientModel> MapPatients(List<Patient> patientsDto)
        {
            if (patientsDto != null)
            {
                var patients = new List<PatientModel>();
                foreach (var item in patientsDto)
                {
                    var model = _mapper.Map<Patient, PatientModel>(item);
                    patients.Add(model);
                }
                return patients;
            }
            return null;
        }
    }
}
