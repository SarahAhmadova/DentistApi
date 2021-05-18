using System.ComponentModel.DataAnnotations;

namespace MedicApp.Resoruce.Auth
{
    public class LoginResource
    {
        [Required(ErrorMessage = "E-poçt boş ola bilməz")]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}