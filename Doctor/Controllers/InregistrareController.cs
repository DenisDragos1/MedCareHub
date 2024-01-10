using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Doctor.Models;
namespace Doctor.Controllers
{
    public class InregistrareController : Controller
    {
        private DoctorEntities db = new DoctorEntities();
        private Inregistrare ob = new Inregistrare();

        public ActionResult Inregistrare()
        {
            return View();
        }
        #region Verificare daca emailul se gaseste in baza de date
        public bool IsEmailExists(string eMail)
        {
            var IsCheck = db.Medics.Where(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        /// <summary>
        /// creeam un obiect medic aferent clasei Medic
        /// si facem inregistararea
        /// </summary>
        /// <param name="medic"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inregistrare(Medic medic)
        {

            var IsExists = IsEmailExists(medic.Email);//verificare daca emailul introdus se afla in baza de date
            if (IsExists)//da acesta se afla in baza de date 
            {
                //se afiseaza
                ModelState.AddModelError("EmailExists", "Email Already Exists");
                return View();
                
            }
            else
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);//adaugam o noua inregistrare in db
                db.SaveChanges();//o salvam
                return RedirectToAction("Index", "Home");//dupa care ne intorcem pe pagina principala
            }
            
                return View(medic);
            
        }
        


       
       
         
       
        #region User Login
        public ActionResult Conectare()
        {
            return View();
        }
        /// <summary>
        /// adaugam un obiect con aferent clasei conectare din Models
        /// si un obiect medic aferent clasei Medic pentru a putea aceesa datele din clasa
        /// </summary>
        /// <param name="con"></param>
        /// <param name="medic"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Conectare(Conectare con, Medic medic)
        {
            var _passWord = medic.Parola;
            bool Isvalid = db.Medics.Any(x => x.Email == con.Email  &&
            x.Parola == _passWord);
            if (Isvalid)
            {

                int timeout = con.Rememberme ? 60 : 5; // Timeout in minutes, 60 = 1 hour.  
                var ticket = new FormsAuthenticationTicket(con.Email, false, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                
                var userDetail = db.Medics.Where(x => x.Email == con.Email  && x.Parola == _passWord).FirstOrDefault();

                FormsAuthentication.SetAuthCookie(medic.ID.ToString(), false);
                Session["ID"] = userDetail.ID;
                Session["Prenume"] = userDetail.Prenume;



                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Invalid Information... Please try again!");
            }
            return View();
        }
        #endregion
        [HttpGet]
        public ActionResult Deconectare()
        {
            Session.Remove("Prenume");
            Session.Remove("ID");
            return RedirectToAction("Index","Home");
        }




    }
}




    

