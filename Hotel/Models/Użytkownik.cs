using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Użytkownik
    {
        [Column(TypeName = "int")]
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Proszę podaj Imię")]
        [MinLength(2, ErrorMessage = "Imię za krótkie, minimum 2 znaki.")]

        [Column(TypeName = "nvarchar(15)")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podaj Nazwisko")]
        [MinLength(2, ErrorMessage = "Nazwisko za krótkie, minimum 2 znaki.")]
        [Column(TypeName = "nvarchar(50)")]

        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podaj Login")]
        [MinLength(8, ErrorMessage = "Login za krótki. Minimum 8 znaków.")]
        [Column(TypeName = "nvarchar(15)")]

        public string Nickname { get; set; }
        [Column(TypeName = "nvarchar(50)")]


        [Required(ErrorMessage = "Proszę podaj Email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podaj Hasło. Minimum 8 znaków, 1 cyfra, 1 znak specjalny, 1 mała litera, 1 wielka.")]
        [MinLength(8, ErrorMessage = "Minimum 8 znaków")]
        [RegularExpression("((?=.*\\d).*(?=.*[a-z]).*(?=.*[A-Z]).*)")]
        public string Haslo { get; set; }

        [Required(ErrorMessage = "Proszę powtórz Hasło")]
        [MinLength(8, ErrorMessage = "Minimum 8 znaków")]
        [RegularExpression("((?=.*\\d).*(?=.*[a-z]).*(?=.*[A-Z]).*)")]
        [Compare(nameof(Haslo), ErrorMessage = ("Hasła różnią się"))]
        public string powtorzHaslo { get; set; }

        public ICollection<Newsletter>? Newsletters { get; set; }
        public ICollection<Rezerwacja>? Reservations { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
