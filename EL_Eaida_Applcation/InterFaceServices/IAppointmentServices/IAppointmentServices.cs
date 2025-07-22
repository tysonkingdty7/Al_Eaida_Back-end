using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.AppointmentDTO;
using EL_Eaida_Applcation.DTO.Prescription;

namespace EL_Eaida_Applcation.InterFaceServices.IAppointmentServices
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto?> GetByIdAsync(Guid id);
        Task<AppointmentDto> Createappointment(CreateAppointmentDto value);
        Task<string> UpdateAsync(Guid id, UpdateAppointmentDto value);
        Task<bool> DeleteAsync(Guid id);
    }
}
