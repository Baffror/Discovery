using System.ComponentModel.DataAnnotations;

namespace Discovery.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string  Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        public string  ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string  Name { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string  Lastname { get; set; }
    }
}
