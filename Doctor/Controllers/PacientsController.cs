using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor.Models;
using static System.Net.WebRequestMethods;

namespace Doctor.Controllers
{
    public class PacientsController : Controller
    {
        private DoctorEntities db = new DoctorEntities();

        // GET: Pacients
        /// <summary>
        /// pentru searchbox sunt folosite doua variabile una pentru cautare se tip streeng -searching
        /// si una pentru verificare de tip bool -myRequestsOnly
        /// </summary>
        /// <param name="searching"></param>
        /// <param name="myRequestsOnly"></param>
        /// <returns></returns>
        public ActionResult Index(string searching, bool myRequestsOnly = false)
        {
            //var pacients = db.Pacients.Include(p => p.Medic);

            //List<Pacient> result = db.Pacients.Where(r => r.CNP.Contains(searching) || searching == null).ToList();

            //return View(pacients.ToList());
            List<Pacient> result = db.Pacients.Where(r => r.CNP.Contains(searching) || searching == null).ToList();
            Pacient pacient = new Pacient();
            if (myRequestsOnly == true)
            {
                result = result.Where(r => r.MedicPId == (int)Session["ID"]).ToList();
            }
            return View(result);
        }
        /// <summary>
        /// primeste id-ul de referinta a pacientului si trimite catre view informatiile de afisare
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Pacients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            return View(pacient);
        }

        // GET: Pacients/Create
      
        public ActionResult Create()
        {
            ViewBag.MedicPId = new SelectList(db.Medics, "ID", "Nume");
            return View();
        }

        // POST: Pacients/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nume,Prenume,Data,CNP,Email,Adresa,Telefon,NrCard,Asigurarea,Alergii,Antecedente_heredocolaterale,Antecedente_personale_patologice,Antecedente_personale_fiziologice,Meseria,LocMunca,Fumator,Elev,Student,Greutate,Sex,Varsta,DataNastere,MedicPId,Vaccinuri,Nr_sarcini,Nr_avorturi")] Pacient pacient,Medic medic)
        {
            if (ModelState.IsValid)
            {
                //Pacient p = new Pacient();
               
                // pacient.ID = medic.ID;
                //pacient.ID = (int)Session["ID"];
                pacient.MedicPId = (int)Session["ID"];
                pacient.Data = DateTime.Now;
                db.Pacients.Add(pacient);
                db.SaveChanges();
                return RedirectToAction("Index","Pacients");
            }

            ViewBag.MedicPId = new SelectList(db.Medics, "ID", "Nume", pacient.MedicPId);
            return View(pacient);
        }

        // GET: Pacients/Edit/5


        /// <summary>
        /// primeste id-ul de referinta a pacientului si editeaza informatiile despre pacient
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicPId = new SelectList(db.Medics, "ID", "Nume", pacient.MedicPId);
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        /// <summary>
        /// facem un obiect de tip Pacient pentru a putea actualiza informatiile
        /// </summary>
        /// <param name="pacient"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nume,Prenume,Data,CNP,Email,Adresa,Telefon,NrCard,Asigurarea,Alergii,Antecedente_heredocolaterale,Antecedente_personale_patologice,Antecedente_personale_fiziologice,Meseria,LocMunca,Fumator,Elev,Student,Greutate,Sex,Varsta,DataNastere,MedicPId,Vaccinuri,Nr_sarcini,Nr_avorturi")] Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicPId = new SelectList(db.Medics, "ID", "Nume", pacient.MedicPId);
            return View(pacient);
        }

        // GET: Pacients/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacient pacient = db.Pacients.Find(id);
            if (pacient == null)
            {
                return HttpNotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacient pacient = db.Pacients.Find(id);
            db.Pacients.Remove(pacient);
            db.SaveChanges();
            
            return RedirectToAction("Index","Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public int consultatieid;
        [HttpGet]
        public ActionResult AdaugaConsultatie(int consultatieid)
        {
            AdConsultatie model = new AdConsultatie();
            Consultatie consultatie = new Consultatie();
            if (Session["ID"] != null)
            {

                Pacient pacient = db.Pacients.Find(consultatieid);
                consultatie.PacientId = consultatieid;
                model.PacientId = consultatieid;
                model.MediCId = (int)Session["ID"];
                model.Data = DateTime.Now;
                return View("AdaugaConsultatie", model);
            }
            else
                return RedirectToAction("Conectare", "Inregistare");
        }

        /// <summary>
        /// creeam un obiect consultatie care deriva din clasa AdConsultatie
        /// creeam o variabila consultatieid in care stocam id-ul pacientului
        /// </summary>
        /// <param name="consultatie"></param>
        /// <param name="consultatieid"></param>
        /// <returns>string</returns>
        [HttpPost]
        public ActionResult AdaugaConsultatie(AdConsultatie consultatie,int consultatieid)
        {
            if (Session["ID"] != null)
            {
                Consultatie con = new Consultatie();
                Pacient pacient = db.Pacients.Find(consultatieid);
               // con.PacientId = consultatie.PacientId;
                con.PacientId = consultatieid;
                con.MediCId = (int)Session["ID"];
                con.Data = DateTime.Now;
                con.IMC=consultatie.IMC;
                con.Observatii = consultatie.Observatii;
                con.Temperatura = consultatie.Temperatura;
                con.Diagnostic = consultatie.Diagnostic;
                con.Greutate = consultatie.Greutate;
                con.Inaltime = consultatie.Inaltime;
                con.RezultateAnalize = consultatie.RezultateAnalize;
                con.Talie=consultatie.Talie;
                con.Tratament = consultatie.Tratament;


                db.Consultaties.Add(con);
                db.SaveChanges();
                return RedirectToAction("Index", "Pacients");
            }
            else
                return RedirectToAction("Inregistrare", "Conectare");


        }

    }
}
