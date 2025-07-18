using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Modules
{
    public  class Appointment
    {

        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = "Scheduled";

        public int PatientId { get; set; }
        
       public virtual Patient Patient { get; set; }
       public string UserID { get; set; }

         public  virtual User User { get; set; }

    }
}
