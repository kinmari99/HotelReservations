using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hotel.Models
{
    public class Logowanie
    {

        [Required(ErrorMessage = "Proszę podaj login")]
        [MinLength(8, ErrorMessage = "Login za krótki. Minimum 8 znaków")]
        public string Nickname { get; set; }


        [Required(ErrorMessage = "Proszę podaj Hasło.")]
        [MinLength(8, ErrorMessage = "Hasło za krótkie. Minimum 8 znaków")]
        [RegularExpression("((?=.*\\d).*(?=.*[a-z]).*(?=.*[A-Z]).*)")]
        public string Haslo { get; set; }
    }
}
