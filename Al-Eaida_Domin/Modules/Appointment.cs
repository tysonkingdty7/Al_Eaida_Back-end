using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public  class Appointment : BaseEntity
    {
 

       
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = "Scheduled";

        public Guid PatientId { get; set; }
        
       public virtual Patient Patient { get; set; }
       public string UserID { get; set; }

       public  virtual User User { get; set; }

    }
}
