using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public string CreatedBy { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<InvoiceItem> Items { get; set; }
    }

}

