using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.DTO.Prescription;
using EL_Eaida_Applcation.InterFaceServices.IAppointmentServices;

namespace EL_Eaida_Applcation.Services
{
    public class AppointmentServices : IAppointmentService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitofwork;
        public AppointmentServices(IMapper mapper, IUnitOfWork unitofwork)
        {
            _mapper = mapper;
            _unitofwork = unitofwork;
        }
        public async Task<AppointmentDto> Createappointment(CreateAppointmentDto value)
        {
              var appointment = _mapper.Map<Appointment>(value);
              await _unitofwork.Repository<Appointment>().AddAsync(appointment);
              await _unitofwork.CompleteAsync();
              return _mapper.Map<AppointmentDto>(appointment);


        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var appointment =await _unitofwork.Repository<Appointment>().GetByIdAsync(id);
            var result = await _unitofwork.Repository<Appointment>().Delete(appointment);
            await _unitofwork.CompleteAsync();
            return true;



        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
             var appointments = await _unitofwork.Repository<Appointment>().GetAllAsync(1, int.MaxValue);
            var appointmentDtos =   _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            await _unitofwork.CompleteAsync();
            return appointmentDtos;
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(id);
            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);
            await _unitofwork.CompleteAsync();
            return appointmentDto;
        }

        public async Task<string> UpdateAsync(Guid id, UpdateAppointmentDto value)
        {
            var appointment = await _unitofwork.Repository<Appointment>().GetByIdAsync(id);
            if (appointment == null)
                return "Appointment not found";

            if (!string.IsNullOrWhiteSpace(value.Notes))
            {
                appointment.Notes = value.Notes;
            }

            if (value.AppointmentDate != default(DateTime))
            {
                appointment.AppointmentDate = value.AppointmentDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(value.Status))
            {
                appointment.Status = value.Status;
            }

            await _unitofwork.Repository<Appointment>().Update(appointment);
            await _unitofwork.CompleteAsync();

            return "Appointment updated successfully";
        }

    }
}
