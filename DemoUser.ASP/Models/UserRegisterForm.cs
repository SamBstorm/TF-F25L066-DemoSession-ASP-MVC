using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoUser.ASP.Models
{
    public class UserRegisterForm
    {
        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [PasswordPropertyText]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+$@µ£_!#])$.{8,64}", ErrorMessage = "Le mot de passe doit contenir au minimum 1 minuscule, 1 majuscule, 1 chiffre et 1 symbole (-.=+$@µ£_!#) et être composé de 8 à 64 caractères.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Veuillez confirmer le mot de passe.")]
        [PasswordPropertyText]
        [Compare(nameof(Password), ErrorMessage = "La confirmation ne correspond pas au mot de passe.")]
        public string ConfirmPassword { get; set; }
    }
}
