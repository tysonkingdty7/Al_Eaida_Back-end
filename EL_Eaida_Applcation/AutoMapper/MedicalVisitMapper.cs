using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicalVisitDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class MedicalVisitMapper : Profile
    {
        public MedicalVisitMapper()
        {
            CreateMap<MedicalVisit, MedicalVisitDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.user.UserName));
            CreateMap<CreateMedicalVisitDto, MedicalVisit>();
            CreateMap<UpdateMedicalVisitDto, MedicalVisit>();
        }
    }
}
