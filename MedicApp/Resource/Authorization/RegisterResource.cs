using System.ComponentModel.DataAnnotations;

namespace MedicApp.Resoruce.Auth
{
    public class RegisterResource
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}