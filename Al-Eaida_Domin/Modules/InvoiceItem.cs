using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class InvoiceItem : BaseEntity
    {
      
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
