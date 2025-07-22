using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.Repositery.MedicineRepositery
{
    public class MedicineRepoistery : GenaricRepositery<Medicine>, IMedicineRepositery
    {
        public MedicineRepoistery(DbContext context) : base(context)
        {
        }
    }
}
