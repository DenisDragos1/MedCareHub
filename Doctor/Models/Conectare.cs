using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Doctor.Models
{
    public class Conectare
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti o adresa de email!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti parola")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Lungimea trebuie sa fie de minim 6 caractere")]
        [Display(Name = "Parola")]
        public string Parola { get; set; }
        [Display(Name = "Tine-ma minte")]
        public bool Rememberme { get; set; }

    }
}