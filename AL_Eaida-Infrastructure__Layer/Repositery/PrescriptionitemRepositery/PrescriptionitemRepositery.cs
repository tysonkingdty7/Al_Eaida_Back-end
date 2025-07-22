using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.Repositery.PrescriptionitemRepositery
{
    public class PrescriptionitemRepositery : GenaricRepositery<PrescriptionItem>, IprescriptionitemRepositery
    {
        public PrescriptionitemRepositery(DbContext context) : base(context)
        {
        }
    }
}
