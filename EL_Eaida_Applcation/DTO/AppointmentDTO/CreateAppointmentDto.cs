﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Eaida_Applcation.DTO.AppointmentDTO
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public Guid PatientId { get; set; }
        public string UserID { get; set; }
    }

}
