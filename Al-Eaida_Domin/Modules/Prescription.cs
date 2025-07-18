using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int VisitId { get; set; }
        public virtual MedicalVisit Visit { get; set; }

        public virtual ICollection<PrescriptionItem> Items { get; set; }
    }
}
