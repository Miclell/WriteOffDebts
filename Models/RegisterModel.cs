using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WriteOffDebts.Models
{
    public class RegisterModel
    {
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
