using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Doctor.Models;

namespace Doctor.Controllers
{
    public class AdaugarePacientController : Controller
    {
        // GET: AdaugarePacient
        DoctorEntities db = new DoctorEntities();
        public ActionResult Adaugare()
        {
            return View();
        }
        /// <summary>
        /// Obiecte aferente claselor AdPacient si Pacient pentru a putea adauga un pacient
        /// </summary>
        /// <param name="pacient1"></param>
        /// <param name="pacient"></param>
        /// <returns>string</returns>
        [HttpPost]
        public ActionResult Adaugare(AdPacient pacient1,Pacient pacient)
        {
            
            if (ModelState.IsValid)
            {
                pacient.Data = DateTime.Now;
                pacient.MedicPId = (int)Session["ID"];
                db.Pacients.Add(pacient);//adaugam o noua inregistrare in db
                db.SaveChanges();//o salvam
                return RedirectToAction("Index", "Pacients");//dupa care ne intorcem pe pagina principala
            }
            return View(pacient);
           
        }
    }
}