using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicalVisitDTO;
using EL_Eaida_Applcation.InterFaceServices.IMedicalvisitServices;

namespace EL_Eaida_Applcation.Services
{
    public class MedicalVisitServices : IMedicalVisitServices
    {   
          protected readonly IUnitOfWork _unitOfWork;
           protected readonly IMapper _mapper;
        public MedicalVisitServices(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task  CreateMedicalVisitAsync(CreateMedicalVisitDto createMedicalVisitDto)
        {
             var medicalVisit = _mapper.Map<MedicalVisit>(createMedicalVisitDto);
            await _unitOfWork.Repository<MedicalVisit>().AddAsync(medicalVisit);
            await _unitOfWork.CompleteAsync();
         
        }

        public async Task<bool> DeleteMedicalVisitAsync(Guid id)
        {
            var medicalVisit = _unitOfWork.Repository<MedicalVisit>().GetByIdAsync(id);
        
            await _unitOfWork.Repository<MedicalVisit>().Delete(medicalVisit.Result);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<MedicalVisitDto>> GetAllMedicalVisitsAsync(int pageSize, int pageNumber)
        {
            var medicalVisits = await _unitOfWork.Repository<MedicalVisit>().GetAllAsync(pageNumber, pageSize);
            var medicalVisitDtos = _mapper.Map<IEnumerable<MedicalVisitDto>>(medicalVisits);
            return medicalVisitDtos;
        }

        public async Task<MedicalVisitDto> GetMedicalVisitByIdAsync(Guid id)
        {
            var medicalVisit = await _unitOfWork.Repository<MedicalVisit>().GetByIdAsync(id);
           
            var medicalVisitDto = _mapper.Map<MedicalVisitDto>(medicalVisit);
           return medicalVisitDto;

        }

        public async Task<List<MedicalVisitDto>> GetMedicalVisitsByPatientIdAsync(Guid patientId)
        {
            var allVisits = await _unitOfWork.Repository<MedicalVisit>().GetAllAsync(1, int.MaxValue);
            var filteredVisits = allVisits.Where(mv => mv.PatientId == patientId).ToList();
            var medicalVisitDtos = _mapper.Map<List<MedicalVisitDto>>(filteredVisits);
            return medicalVisitDtos;
        }

        public async Task<MedicalVisitDto?> UpdateMedicalVisitAsync(UpdateMedicalVisitDto updateDto)
        {
            var medicalVisit = await _unitOfWork.Repository<MedicalVisit>().GetByIdAsync(updateDto.Id);
            if (medicalVisit == null)
                return null;

            if (updateDto.VisitDate.HasValue)
                medicalVisit.VisitDate = updateDto.VisitDate.Value;

            if (!string.IsNullOrEmpty(updateDto.Diagnosis))
                medicalVisit.Diagnosis = updateDto.Diagnosis;

            if (!string.IsNullOrEmpty(updateDto.Notes))
                medicalVisit.Notes = updateDto.Notes;

            if (updateDto.PatientId.HasValue)
                medicalVisit.PatientId = updateDto.PatientId.Value;

            if (!string.IsNullOrEmpty(updateDto.UserID))
                medicalVisit.UserID = updateDto.UserID;

          await  _unitOfWork.Repository<MedicalVisit>().Update(medicalVisit);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<MedicalVisitDto>(medicalVisit);
        }

    }
}
