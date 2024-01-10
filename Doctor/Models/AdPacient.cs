using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Doctor.Models
{
    public class AdPacient
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti numele!")]

        public string Nume { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti prenumele!")]

        public string Prenume { get; set; }
        public Nullable<System.DateTime> Data { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti CNP-ul dvs!")]

        public string CNP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti o adresa de email!")]

        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti o adresa!")]

        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti un numar de telefon!")]

        public string Telefon { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti nr cardului de sanatate!")]

        public string NrCard { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti nr de asiguare!")]

        public string Asigurarea { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti alergii!")]

        public string Alergii { get; set; }
        [Display(Name = "Antecedente heredocolaterale")]
        public string Antecedente_heredocolaterale { get; set; }
        [Display(Name = "Antecedente personale patologice")]
        public string Antecedente_personale_patologice { get; set; }
        [Display(Name = "Antecedente personale fiziologice")]
        public string Antecedente_personale_fiziologice { get; set; }
        public string Meseria { get; set; }
        public string LocMunca { get; set; }
        public Nullable<bool> Fumator { get; set; }
        public Nullable<bool> Elev { get; set; }
        public Nullable<bool> Student { get; set; }
        public Nullable<double> Greutate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Va rugam sa introduceti sexul dvs! (masculin/feminin)")]

        public string Sex { get; set; }
        public Nullable<int> Varsta { get; set; }
        [Display(Name ="Data nasterii(aaaa-ll-zz)")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd",
        ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DataNastere { get; set; }
    }
}