using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApi.Resources
{
    public class StaffResource
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int specId { get; set; }
        public string imgUrl { get; set; }
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public bool softDeleted { get; set; }
    }
}
