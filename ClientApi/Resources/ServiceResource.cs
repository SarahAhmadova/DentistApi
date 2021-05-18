using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Resources
{
    public class ServiceResource
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public bool softDeleted { get; set; }
    }
}
