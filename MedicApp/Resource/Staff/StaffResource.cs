using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Resource.Staff
{
    public class StaffResource
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string SpecId { get; set; }
        public string imgUrl { get; set; }
        public DateTime createdAt { get; set; }

    }
}
