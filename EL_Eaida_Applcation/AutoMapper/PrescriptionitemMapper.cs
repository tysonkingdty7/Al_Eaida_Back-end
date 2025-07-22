using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.Prescriptionitem;

namespace EL_Eaida_Applcation.AutoMapper
{
    public class PrescriptionitemMapper : Profile
    {
        public PrescriptionitemMapper()
        {
            CreateMap<PrescriptionItem, CreatePrescriptionItemDto>().ReverseMap();
            CreateMap<CreatePrescriptionItemDto, PrescriptionItem>().ReverseMap();
            CreateMap<UpdatePrescriptionItemDto,PrescriptionItem>().ReverseMap();
        }
    }
}