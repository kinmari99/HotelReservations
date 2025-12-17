using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Napisz
    {
        [Required(ErrorMessage = "Proszę podaj Imię")]
        [MinLength(2, ErrorMessage = "Imię za krótkie. Minimum 2 znaki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podaj Nazwisko")]
        [MinLength(2, ErrorMessage = "Nazwisko za krótkie. Minimum 2 znaki")]

        public string Surname {  get; set; }


        [Required(ErrorMessage = "Proszę podaj Email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]

        public string Email { get; set; }

        [Display(Name = "Wiadomość")]
        [Required(ErrorMessage = "Wiadomość musi posiadać od 3 do 200 znaków.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Wiadomość musi mieć od 3 do 200 znaków.")]
        public string Message { get; set; }

    }
}
