using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Modules;
using AutoMapper;
using EL_Eaida_Applcation.DTO.MedicineDTO;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.AutoMapper
{
    public  class MedicineMapper : Profile
    {
        public MedicineMapper()
        {
            CreateMap<Medicine, CreateMedicineDTO>().ReverseMap();
            CreateMap<UpDateMedicineDTO, Medicine>().
                ReverseMap();
            CreateMap<Medicine, MedicineDTO>().ReverseMap();
        }
    }
  
}
