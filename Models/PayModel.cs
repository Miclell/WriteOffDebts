using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WriteOffDebts.Models
{
    public class PayModel
    {
        [BindProperty]
        [Required]
        [Display(Name = "Номер карты")]
        [StringLength(19, MinimumLength = 16, ErrorMessage = "Номер карты должен содержать от 16 до 19 символов!")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "Год")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/[0-9]{2}$", ErrorMessage = "Неверный формат срока действия. Используйте формат MM/YY.")]
        public string Validity { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "CVV")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "CVV должен содержать от 3 до 4 символов!")]
        public string CVV { get; set; }
    }
}