using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Admin
{
    public class Medservices:BaseEntity
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
