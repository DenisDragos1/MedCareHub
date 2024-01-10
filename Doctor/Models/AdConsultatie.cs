using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Doctor.Models
{
    public class AdConsultatie
    {
        public /*Nullable<int>*/ int? PacientId { get; set; }
        public Nullable<int> MediCId { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<double> Temperatura { get; set; }
        public Nullable<double> Greutate { get; set; }
        public Nullable<double> Talie { get; set; }
        public Nullable<double> Inaltime { get; set; }
        public Nullable<double> IMC { get; set; }
        [Display(Name = "Rezultate analize")]
        public string RezultateAnalize { get; set; }
        public string Diagnostic { get; set; }
        public string Tratament { get; set; }
        public string Observatii { get; set; }

        public virtual Medic Medic { get; set; }
        public virtual Pacient Pacient { get; set; }
    }
}