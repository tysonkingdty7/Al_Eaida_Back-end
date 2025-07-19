using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.Repositery.PatientRepositery
{
    public class PatientRepositery : GenaricRepositery<Patient>, IPatientRepositery
    {
        public PatientRepositery(DbContext context) : base(context)
        {
        }
         
    }
}
