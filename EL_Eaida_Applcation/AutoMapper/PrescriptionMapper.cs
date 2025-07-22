using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescription;

namespace EL_Eaida_Applcation.AutoMapper
{
    internal class PrescriptionMapper : Profile
    {
        public PrescriptionMapper()
        {
            CreateMap<Prescription, PrescriptionDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();
            CreateMap<CreatePrescriptionDto, Prescription>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();
            CreateMap<UpdatePrescriptionDto,Prescription>().ReverseMap();
        }
    }
    
}
