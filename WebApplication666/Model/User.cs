using System.ComponentModel.DataAnnotations;

namespace WebApplication666.Model
{
    public class User
    {
        [Display(Name = "Введи логин:")]
        [MinLength(3, ErrorMessage = "Логин мин 3 буквы")]
        [MaxLength(255, ErrorMessage = "Логин макс 255 букв")]
        public string Name { get; set; } = null!;


        [Display(Name = "Введи пароль:")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage="Пароль мин 3 буквы")]
        [MaxLength(255, ErrorMessage="Пароль макс 255 букв")]
        public string Password { get; set; } = null!;

        [Display(Name = "Повтори пароль:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string PasswordAgain { get; set; } = null!;

        [Display(Name = "Введи страну:")]
        [MinLength(3, ErrorMessage = "Пароль мин 3 буквы")]
        [MaxLength(255, ErrorMessage = "Пароль макс 255 букв")]

        public string Country { get; set; } = null!;


    }
}
