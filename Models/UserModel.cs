using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WriteOffDebts.Models
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Свойство для коллекции должников
        public ICollection<DebtorModel> Debtors { get; set; } = [];
    }
}
