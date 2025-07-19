using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Prescription : BaseEntity
    {
    
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid VisitId { get; set; } 
        public virtual MedicalVisit Visit { get; set; }

        public virtual ICollection<PrescriptionItem> Items { get; set; }
    }
}
