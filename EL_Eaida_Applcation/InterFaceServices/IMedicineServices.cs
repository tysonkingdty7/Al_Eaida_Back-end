using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Eaida_Applcation.DTO.MedicineDTO;
using EL_Eaida_Applcation.DTO.PatientsDTO;

namespace EL_Eaida_Applcation.InterFaceServices
{
    public interface IMedicineServices
    {
        Task<IEnumerable<MedicineDTO>> GetAllMedicinesAsync(int pageSize, int pageNumber);
        Task<MedicineDTO> GetMedicineByIdAsync(Guid id);
        Task<MedicineDTO> CreateMedicineAsync(CreateMedicineDTO dto);
        Task<MedicineDTO?> UpdateMedicineAsync(UpDateMedicineDTO dto);
        Task<bool> DeleteMedicineAsync(Guid id);

    }
}
