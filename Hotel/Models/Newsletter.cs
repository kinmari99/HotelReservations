using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Newsletter
    {
     
        public int? UserId { get; set; }  // Klucz obcy
        public Użytkownik? użytkownik { get; set; }

        [Required(ErrorMessage = "Proszę podaj Imię")]
        [MinLength(2, ErrorMessage = "Imię za krótkie. Minimum 2 znaki")]
        [Column(TypeName = "nvarchar(15)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podaj Email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Column(TypeName = "nvarchar(50)")]
        [Key]
        public string Email {  get; set; }

        [Display(Name = "Wyrażam zgodę na przetwarzanie moich danych przez Hotel XYZ")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Musisz wyrazić zgodę.")]
        [Column(TypeName = "bit")]
        public bool IsAccepted { get; set; }
    }
}
