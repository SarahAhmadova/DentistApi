using System.ComponentModel.DataAnnotations;

namespace MedicApp.Resource.Staff
{
    public class AddStaffResource
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }

        [MaxLength(16)]
        public string Phone { get; set; }

        public string Description { get; set; }

        [Required]
        public int SpecId { get; set; }
        public string imgUrl { get; set; }

    }
}
