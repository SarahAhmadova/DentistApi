using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Data.Entities
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public string Patient { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
    }
}
