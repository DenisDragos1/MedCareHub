using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doctor.Models;

namespace Doctor.Controllers
{
    public class ConsultatiesController : Controller
    {
        private DoctorEntities db = new DoctorEntities();

        // GET: Consultaties
        public ActionResult Index1(int consultatieid)
        {
            // var consultaties = db.Consultaties.Include(c => c.Medic).Include(c => c.Pacient);
            List<Consultatie> consultatie = db.Consultaties.Include(a => a.Pacient).Include(a => a.Medic).ToList();
          
            //return View(consultaties.ToList());
            if(consultatieid!=0)
            {
                consultatie=consultatie.Where(a => a.PacientId==consultatieid).ToList();
            }
            return View(consultatie.ToList());
        }

        // GET: Consultaties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultatie consultatie = db.Consultaties.Find(id);
            if (consultatie == null)
            {
                return HttpNotFound();
            }
            return View(consultatie);
        }

        // GET: Consultaties/Create
        public ActionResult Create()
        {
            ViewBag.MediCId = new SelectList(db.Medics, "ID", "Nume");
            ViewBag.PacientId = new SelectList(db.Pacients, "ID", "Nume");
            return View();
        }

        // POST: Consultaties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PacientId,MediCId,Data,Temperatura,Greutate,Talie,Inaltime,IMC,RezultateAnalize,Diagnostic,Tratament,Observatii")] Consultatie consultatie,int consultatieid)
        {
            if (ModelState.IsValid)
            {
                Pacient pacient = db.Pacients.Find(consultatieid);

                db.Consultaties.Add(consultatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MediCId = new SelectList(db.Medics, "ID", "Nume", consultatie.MediCId);
            ViewBag.PacientId = new SelectList(db.Pacients, "ID", "Nume", consultatie.PacientId);
            return View(consultatie);
        }

        // GET: Consultaties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultatie consultatie = db.Consultaties.Find(id);
            if (consultatie == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediCId = new SelectList(db.Medics, "ID", "Nume", consultatie.MediCId);
            ViewBag.PacientId = new SelectList(db.Pacients, "ID", "Nume", consultatie.PacientId);
            return View(consultatie);
        }

        // POST: Consultaties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PacientId,MediCId,Data,Temperatura,Greutate,Talie,Inaltime,IMC,RezultateAnalize,Diagnostic,Tratament,Observatii")] Consultatie consultatie)
        {
            if (ModelState.IsValid)
            {
                consultatie.Data = DateTime.Now;
                db.Entry(consultatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Pacients");
            }
            ViewBag.MediCId = new SelectList(db.Medics, "ID", "Nume", consultatie.MediCId);
            ViewBag.PacientId = new SelectList(db.Pacients, "ID", "Nume", consultatie.PacientId);
            return View(consultatie);
        }

        // GET: Consultaties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultatie consultatie = db.Consultaties.Find(id);
            if (consultatie == null)
            {
                return HttpNotFound();
            }
            return View(consultatie);
        }

        // POST: Consultaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultatie consultatie = db.Consultaties.Find(id);
            db.Consultaties.Remove(consultatie);
            db.SaveChanges();
            
            return RedirectToAction("Index","Pacients");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
