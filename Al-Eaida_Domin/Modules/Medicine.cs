using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }


    }
}
