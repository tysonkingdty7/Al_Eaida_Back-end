using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }

        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }

        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
