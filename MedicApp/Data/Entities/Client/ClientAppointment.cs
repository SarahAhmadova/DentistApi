using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Client
{
    public class ClientAppointment
    {
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public string Patient { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public bool Accepted { get; set; }
    }
}
