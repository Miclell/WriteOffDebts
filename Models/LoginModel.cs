using System.ComponentModel.DataAnnotations;

namespace WriteOffDebts.Models
{
    public class LoginModel
    {
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
