using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class Rezerwacja
    {
        [Column(TypeName = "int")]

        public int Id { get; set; }

        [Column(TypeName = "int")]

        public int? UserId { get; set; }  // Klucz obcy
       
        public Użytkownik? użytkownik { get; set; }

     
        public Pracownik? pracownik { get; set; }

        [Required(ErrorMessage = "Proszę podaj Imię")]
        [MinLength(2, ErrorMessage = "Imię minimum 2 znaki.")]
        [Column(TypeName = "nvarchar(15)")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podaj Nazwisko")]
        [MinLength(2, ErrorMessage = "Nazwisko minimum 2 znaki.")]
        [Column(TypeName = "nvarchar(50)")]

        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podaj Email")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        [Column(TypeName = "nvarchar(50)")]
        [Key]

        public string Email { get; set; }


        [Required(ErrorMessage = "Proszę podaj numer dowodu tożsamości")]
        [MaxLength(15, ErrorMessage = "Numer dowodu tożsamości maksymalnie 15 znaków")]
        [Column(TypeName = "nvarchar(15)")]

        public string IDCard { get; set; }

        [Required(ErrorMessage = "Proszę podaj miejsce zamieszkania")]
        [MaxLength(30, ErrorMessage = "Miejsce zamieszkania maksymalnie 30 znaków.")]
        [Column(TypeName = "nvarchar(30)")]

        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podaj ulicę")]
        [MaxLength(30, ErrorMessage = "Ulica maksymalnie 30 znaków")]
        [Column(TypeName = "nvarchar(30)")]

        public string Street { get; set; }
        [Required(ErrorMessage = "Proszę podaj numer budynku")]

        [Column(TypeName = "nvarchar(10)")]

        public string Building { get; set; }

        [Column(TypeName = "nvarchar(10)")]

        public string? Apartment { get; set; } 


        [Required(ErrorMessage = "Proszę podaj kod pocztowy")]
        [MaxLength(6, ErrorMessage = "Kod pocztowy maksymalnie 6 znaków")]
        [Column(TypeName = "char(8)")]

        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Proszę podaj pocztę")]
        [MaxLength(30, ErrorMessage = "Poczta maksymalnie 30 znaków")]
        [Column(TypeName = "nvarchar(30)")]

        public string PostOffice { get; set; }

        [Required(ErrorMessage = "Data zameldowania jest wymagana")]
        [DataType(DataType.Date, ErrorMessage = "Nieprawidłowy format daty")]
        [Display(Name = "Data zameldowania")]
        [CustomDateValidation(ErrorMessage = "Data musi być w przyszłości.")]
        [Column(TypeName = "date")]

        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage="Musisz wybrać na ile dni chcesz dokonać rezerwacji")]
        [Column(TypeName = "int")]

        public int Days { get; set; }


        [Required(ErrorMessage = "Proszę podaj liczbę pokoi. Minimalnie możesz zarezerwować 1 pokój, maksymalnie 12")]
        [Range(1, 12)]
        [Column(TypeName = "int")]


        public int? HowManyRooms { get; set; } = 1;
        [Required(ErrorMessage = "Proszę podaj liczbę łóżek. Minimalnie możesz zarezerwować 1 łóżko, maksymalnie 30")]
        [Range(1, 30)]
        [Column(TypeName = "int")]

        public int? HowManyBeds { get; set; } = 1;

     



    }

    public class CustomDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateValue = Convert.ToDateTime(value);

            if (dateValue < DateTime.Today)
            {
                return new ValidationResult("Wybrana data musi być dzisiejsza lub późniejsza.");
            }
            return ValidationResult.Success;
        }
    }
}

