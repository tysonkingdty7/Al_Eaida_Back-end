using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class MedicalVisit : BaseEntity
    {
     
        public DateTime VisitDate { get; set; } = DateTime.UtcNow;
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }

        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public string UserID { get; set; }
        public  virtual User user { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
