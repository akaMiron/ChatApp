using System.ComponentModel.DataAnnotations;

namespace CA.Common.ViewModels
{
    public class UserView
    {        
        [Required(ErrorMessage="Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage="Введите пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
    }
}
