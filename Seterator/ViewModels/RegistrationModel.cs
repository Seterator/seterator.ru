using System.ComponentModel.DataAnnotations;

namespace Seterator.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}
