using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.PatientsDTO;
using EL_Eaida_Applcation.InterFaceServices.IPatientServices;
using Microsoft.EntityFrameworkCore;

namespace EL_Eaida_Applcation.Services.PatientServices
{
    public class PatientServices : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddPatientAsync(CreatePatientDTO patient)
        {
            var patientEntity = _mapper.Map<Patient>(patient);
            await _unitOfWork.Repository<Patient>().AddAsync(patientEntity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeletePatientAsync(Guid id)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);
            if (patient == null)
                return false;

             await  _unitOfWork.Repository<Patient>().Delete(patient);
            await _unitOfWork.CompleteAsync();
            return true;
        }


        public async Task<PatientDTO> GetPatientByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.Repository<Patient>().GetByIdAsync(id);

            if (entity == null)
                return null;

            var dto =  _mapper.Map<PatientDTO>(entity);
            return dto;
        }
        public async Task<bool> UpdatePatientAsync(UpdatePatientDTO patients)
        {
            var patient = await _unitOfWork.Repository<Patient>().GetByIdAsync(patients.Id);

            if (patient == null)
                return false;

            // فقط نحدث الحقول غير الفارغة أو التي تم تعديلها
            if (!string.IsNullOrWhiteSpace(patients.FullName))
                patient.FullName = patients.FullName;

            if (!string.IsNullOrWhiteSpace(patients.Address))
                patient.Address = patients.Address;

            if (!string.IsNullOrWhiteSpace(patients.Phone))
                patient.Phone = patients.Phone;

            if (patients.BirthDate != null && patients.BirthDate != default)
                patient.BirthDate = patients.BirthDate;

            if (!string.IsNullOrWhiteSpace(patients.MedicalHistory))
                patient.MedicalHistory = patients.MedicalHistory;

            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();
            var patients = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }


        public async Task<IEnumerable<PatientDTO>> FilterPatientsAsync(string? name, string? gender)
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.FullName.Contains(name));

            if (!string.IsNullOrWhiteSpace(gender))
                query = query.Where(p => p.Gender == gender);

            var result = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(result);
        }

        public async Task<IEnumerable<PatientDTO>> GetPatientFilter(int pageNumber, int pageSize, string? name = null, string? gender = null)
        {
            var query = _unitOfWork.Repository<Patient>().GetQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.FullName.Contains(name));

            if (!string.IsNullOrWhiteSpace(gender))
                query = query.Where(p => p.Gender == gender);

            var patients = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}
   
