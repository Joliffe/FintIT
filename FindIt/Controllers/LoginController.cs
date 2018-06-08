using FindIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindIt.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(FindIt.Models.persona userModel)
        {
            using (db_globalesEntities1 db  = new db_globalesEntities1())
            {
                var userDetails = db.persona.Where(x => x.usuario.Equals(userModel.usuario) && x.pass.Equals(userModel.pass)).FirstOrDefault();
                if (userDetails==null)
                {
                    userModel.LoginErrorMessage = "wrong user or password";
                    return View("Login",userModel);
                }
                else
                {
                    Session["UserID"] = userDetails.idPersona;
                    return RedirectToAction("Index", "Enterprise");
                }
            }
               
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "LoginErrorMessage")] persona user)
        {
            bool status =false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region//Cedula already exist
                var exists = isCedulaExist(user.idPersona.ToString());
                if (exists)
                {
                    ModelState.AddModelError("CedulaExist", "Cedula already exist");
                    return View("SingIn",user);
                }
                #endregion

                #region//Save to database
                using (db_globalesEntities1 db = new db_globalesEntities1())
                {
                    db.persona.Add(user);
                    db.SaveChanges();

                }

                #endregion

            }

            return View("Login");
        }

        public ActionResult Registrar()
        {
            return View("SingIn");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        public bool isCedulaExist(string cedula)
        {
            using (db_globalesEntities1 db = new db_globalesEntities1())
            {
                var v = db.persona.Where(x => x.idPersona.Equals(cedula)).FirstOrDefault();
                if (v==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}