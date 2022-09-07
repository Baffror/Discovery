using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Discovery.Models
{
    public class ResetPasswordViewModel
    {
        [Required,EmailAddress,Display(Name = "Email")]
        public string Email { get; set; }

        [Required,DataType(DataType.Password),Display(Name = "Mot de passe")]
        public string Password { get; set; }
        [Required,DataType(DataType.Password),Display(Name = "Confirmation du mot de passe")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
