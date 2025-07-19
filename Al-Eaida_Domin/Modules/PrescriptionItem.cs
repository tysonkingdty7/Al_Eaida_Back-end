using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class PrescriptionItem : BaseEntity
    {
        
        public string Dosage { get; set; }
        public string Duration { get; set; }

        public Guid PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public Guid MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
