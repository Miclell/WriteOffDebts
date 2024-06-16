using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WriteOffDebts.Data;

namespace WriteOffDebts.Models
{
    public class DebtorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

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
        public DateTime DebtDate { get; set; }

        [Display(Name = "Путь до фото")]
        public string PhotoPath { get; set; }

        // Свойство для связи с пользователем
        [ForeignKey("User")]
        public string UserId { get; set; }
        public UserModel User { get; set; }
    }
}
