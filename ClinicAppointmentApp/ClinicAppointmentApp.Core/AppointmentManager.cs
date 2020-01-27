using AutoMapper;
using ClinicAppointmentApp.Core.Interfaces;
using ClinicAppointmentApp.Dto;
using ClinicAppointmentApp.Repositories;
using ClinicAppointmentApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicAppointmentApp.Core
{
    public class AppointmentManager : IAppointmentManager
    {
        private IAppointmentRepository _appointmentRepo;
        private IMapper _mapper;

        public AppointmentManager(IAppointmentRepository appointmentRepo, IMapper mapper)
        {
            _appointmentRepo = appointmentRepo ?? new AppointmentRepository();
            _mapper = mapper;
        }

        public Result CancelAppointment(int appointmentId)
        {
            try
            {
                //check appointment exists
                var appointment = _appointmentRepo.GetById(appointmentId);
                if (appointment != null)
                {
                    //check if appointment date will be on more than 24 hours
                    var appointmentDateandTime = appointment.Date + appointment.StartTime;
                    var dateDiff = appointmentDateandTime.Subtract(DateTime.Now).TotalHours;
                    if (dateDiff > 24)
                    {
                        _appointmentRepo.Delete(appointmentId);
                        _appointmentRepo.Save();
                        return new Result() { Status = true, Message = "The appointment has been canceled." };
                    }
                    else
                        return new Result() { Status = false, Message = "The appointment should be canceled more than 24 hours in advance." };
                }
                return new Result() { Status = false, Message = "The requested appointment doesn't exists." };

            }
            catch (Exception)
            {

                return new Result() { Status = false, Message = "An exception has occurred, please try again." };
            }
        }

        public Result CreateAppointment(Appointment appointmentInfo)
        {
            try
            {
                //Check appointment is available
                var appointmentSpot = _appointmentRepo.GetAppointments(appointmentInfo.Date, appointmentInfo.StartTime, appointmentInfo.PatientId);
                if (appointmentSpot != null && appointmentSpot.Count() > 0)
                    return new Result() { Status = false, Message = "This appointment has been already taken, try another time." };

                //Check patient appointments
                var patientAppointments = _appointmentRepo.GetAppointmentsByPatientId(appointmentInfo.PatientId);
                if (patientAppointments != null && patientAppointments.Count() > 0)
                {
                    var apointmentsOnDay = patientAppointments.FirstOrDefault(x => x.Date == appointmentInfo.Date);
                    if (apointmentsOnDay != null)
                        return new Result() { Status = false, Message = "This appointment cannot be assigned since the patient has already one for today, try another date." };
                }

                //Create appointment
                var appointmentDao = _mapper.Map<Appointment, DbManager.Appointment>(appointmentInfo);
                appointmentDao.EndTime = appointmentDao.StartTime.Add(TimeSpan.FromMinutes(30));
                _appointmentRepo.Insert(appointmentDao);
                _appointmentRepo.Save();

                return new Result() { IdResult = appointmentDao.Id, Status = true, Message = "The appointment has been assigned to the patient." };
            }
            catch (Exception ex)
            {
                return new Result() { Status = false, Message = "An exception has occurred, please try again." };
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            try
            {
                var appointment = _appointmentRepo.GetById(id);
                var appointmentDto = _mapper.Map<DbManager.Appointment, Appointment>(appointment);
                return appointmentDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            try
            {
                var appointments = _appointmentRepo.GetAll();
                var appointmentsDto = MapAppointments(appointments);
                return appointmentsDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Appointment> GetAllAppointmentsByDate(DateTime date)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByDate(date);
                var appointmentsDto = MapAppointments(appointments);
                return appointmentsDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Appointment> GetAllAppointmentsByPatient(int patientId)
        {
            try
            {
                var appointments = _appointmentRepo.GetAppointmentsByPatientId(patientId);
                var appointmentsDto = MapAppointments(appointments);
                return appointmentsDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Appointment> MapAppointments(IEnumerable<DbManager.Appointment> appointmentsDao)
        {
            if (appointmentsDao != null)
            {
                var appointmentsDto = new List<Appointment>();
                foreach (var item in appointmentsDao)
                {
                    var appointmentDto = _mapper.Map<DbManager.Appointment, Appointment>(item);
                    appointmentsDto.Add(appointmentDto);
                }
                return appointmentsDto;
            }
            return null;
        }
    }
}
