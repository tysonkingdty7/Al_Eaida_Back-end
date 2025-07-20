
using Al_Eaida_Domin.Interface;
using Al_Eaida_Domin.Modules;
using AL_Eaida_Infrastructure__Layer.IRepositery;
using Microsoft.EntityFrameworkCore;

namespace AL_Eaida_Infrastructure__Layer.Repositery.MedicalVisitRepositery
{
    public class MedicalVisitREpositery : GenaricRepositery<MedicalVisit>, IMedicalVisitRepositery
    {
        public MedicalVisitREpositery(DbContext context) : base(context)
        {
        }
    }
}
