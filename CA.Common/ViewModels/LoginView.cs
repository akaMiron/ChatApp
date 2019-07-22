using System.ComponentModel.DataAnnotations;

namespace CA.Common.ViewModels
{
    public class LoginView
    {
        [Required(ErrorMessage = "Введите логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}
