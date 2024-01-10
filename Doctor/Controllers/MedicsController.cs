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
    public class MedicsController : Controller
    {
        private DoctorEntities db = new DoctorEntities();

        // GET: Medics
        public ActionResult Index()
        {
            return View(db.Medics.ToList());
        }
        /// <summary>
        /// id-ul fiecarui medic
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Medics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }
        /// <summary>
        /// view
        /// </summary>
        /// <returns></returns>
        // GET: Medics/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Medics/Create
        
        /// <summary>
        /// medic - obiect pentru Clasa
        /// </summary>
        /// <param name="medic"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nume,Prenume,Email,Parola,CNP,Adresa,Telefon")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medic);
        }

        // GET: Medics/Edit/5
        /// <summary>
        /// Primeste id-ul de referinta a medicului
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        // POST: Medics/Edit/5
        /// <summary>
        /// medic -obiect
        /// </summary>
        /// <param name="medic"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nume,Prenume,Email,Parola,CNP,Adresa,Telefon")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medic);
        }

        // GET: Medics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        // POST: Medics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medic medic = db.Medics.Find(id);
            db.Medics.Remove(medic);
            db.SaveChanges();
            return RedirectToAction("Index");
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
