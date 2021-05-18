using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Admin
{
    public class aboutus
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string textContext { get; set; }
        public string ImgPath { get; set; }
        public int PatientCount { get; set; }
        public int DoctorCount { get; set; }
        public int BranchCount { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
