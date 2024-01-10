using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Doctor.Models
{
    public class Inregistrare
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa va introduceti numele!")]
        public string Nume { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa va introduceti prenumele!")]
        public string Prenume { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti o adresa de email!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti parola")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Lungimea trebuie sa fie de minim 6 caractere")]
        [Display(Name = "Parola")]

        public string Parola { get; set; }

        [Display(Name = "Confirmare Parola")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirmarea parolei este necesara!")]
        [DataType(DataType.Password)]
        [Compare("Parola", ErrorMessage = "Parolele nu se potrivesc")]
        public string ConfirmareParola { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa va introduceti CNP-ul!")]
        public string CNP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti adresa dvs!")]
        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti numarul dvs de delefon!")]
        public string Telefon { get; set; }

    }
}