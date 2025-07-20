using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class PatientsMapper : Profile
    {
        public PatientsMapper() {
        
            CreateMap<CreatePatientDTO, Patient>().
                ForMember(dto=>dto.Id, opt => opt.Ignore()) 
                .ForMember(dto=>dto.Address, opt => opt.MapFrom(src => src.Address)).
                ForMember(dto=>dto.FullName, opt => opt.MapFrom(src => src.FullName)).
                ForMember(dto=>dto.MedicalVisits, opt => opt.Ignore()) 
                .ForMember(dto => dto.MedicalHistory, opt => opt.MapFrom(src => src.MedicalHistory)).
                ForMember(dto=>dto.Phone, opt => opt.MapFrom(src => src.Phone)).
                ForMember(dto=>dto.BirthDate, opt => opt.MapFrom(src => src.BirthDate)).
                ReverseMap();
            CreateMap<Patient, PatientDTO>(); 
            CreateMap<PatientDTO, Patient>();
            CreateMap<UpdatePatientDTO, Patient>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
