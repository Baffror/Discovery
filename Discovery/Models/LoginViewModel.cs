using System.ComponentModel.DataAnnotations;

namespace Discovery.Models
{
    public class LoginViewModel
    {
        [EmailAddress,Required]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        [Display(Name ="Mot de passe")]
        public string Password { get; set; }
        [Display(Name = "Se souvenir de moi")]
        public bool RemenberMe { get; set; }
    }
}
