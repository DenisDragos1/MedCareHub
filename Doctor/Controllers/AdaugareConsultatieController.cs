using Doctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor.Controllers
{
    public class AdaugareConsultatieController : Controller
    {
        // GET: AdaugareConsultatie
        DoctorEntities db=new DoctorEntities();
        [HttpGet]
        public ActionResult Adauga(int consultatieid)
        {
            AdConsultatie model = new AdConsultatie();


            Pacient pacient = db.Pacients.Find(consultatieid);
            model.PacientId = consultatieid;


            return View("Adauga", model);
        }
        [HttpPost]
        public ActionResult Adauga(AdConsultatie cons)
        {
            Consultatie con=new Consultatie();
            con.PacientId= cons.PacientId;
            con.MediCId = (int)Session["ID"];
            con.IMC = cons.IMC;
            con.Observatii = cons.Observatii;
            con.Temperatura = cons.Temperatura;
            con.Data=DateTime.Now;
            con.Diagnostic = cons.Diagnostic;
            con.Greutate = cons.Greutate;
            con.Inaltime = cons.Inaltime;
            con.Talie = cons.Talie;
            con.RezultateAnalize = cons.RezultateAnalize;
            con.Tratament = cons.Tratament;
            db.Consultaties.Add(con);
            db.SaveChanges();
            return RedirectToAction("Index", "Pacients");

        }
    }
}