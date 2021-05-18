using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Admin
{
    public class Appointments:BaseEntity
    {
        public string Patient { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public int DoctorId { get; set; }
        public string Time { get; set; }
        public DateTime Date { get; set; }
        public bool completed { get; set; }
        public Staff Doctor { get; set; }
    }
}
