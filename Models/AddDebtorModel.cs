using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WriteOffDebts.Models
{
    public class AddDebtorModel
    {
        [Display(Name = "ФИО")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string FullName { get; set; }

        [Display(Name = "Сумма долга")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public decimal DebtAmount { get; set; }

        [Display(Name = "Процент в день")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public decimal InterestRate { get; set; }

        [Display(Name = "Дата взятия долга")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DebtDate { get; set; }

        [Display(Name = "Ссылка на фото")]
        public string PhotoPath { get; set; }
    }
}
