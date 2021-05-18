using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Admin
{
    public class Staff:BaseEntity
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int SpecId { get; set; }
        public string imgUrl { get; set; }

        public Speciality speciality { get; set; }
    }
}
