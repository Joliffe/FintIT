using FindIt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindIt.Controllers
{
    public class EnterpriseController : Controller
    {
        // GET: Enterprise
        public ActionResult Index()
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                string idUser = Session["UserID"].ToString();
                var empresa = db.empresa.Where(x => x.propietario == idUser).FirstOrDefault();
                if (empresa == null)
                {
                    return View(new empresa());
                }
                else
                {
                    return View("Index", empresa);
                }
            }



        }

        //Create enterprice
        [HttpPost]
        public ActionResult Create(empresa Newempresa, HttpPostedFileBase img)
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                //upload folder exist
                if (!Directory.Exists(Server.MapPath("~/Images")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images"));
                }
                //save image on local storage
                var path = Path.Combine(Server.MapPath("~/Images"), img.FileName);
                img.SaveAs(path);
                Newempresa.imagen = img.FileName;
                Newempresa.propietario = Session["UserID"].ToString();



                //empresa exists
                var empresa = db.empresa.Where(x => x.idEmpresa == Newempresa.idEmpresa).FirstOrDefault();
                if (empresa == null)
                {
                    db.empresa.Add(Newempresa);
                    db.SaveChanges();
                }
            }


            return View("Index", "Home");
        }


        public ActionResult Events()
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                string idUser = Session["UserID"].ToString();
                var evento = db.eventos.Where(x => x.propietario == idUser).FirstOrDefault();
                if (evento == null)
                {
                    return View(new eventos());
                }
                else
                {
                    return View("Events", evento);
                }
            }

        }

        //Create enterprice
        [HttpPost]
        public ActionResult CreateEvent(eventos Newevent, HttpPostedFileBase img)
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                //upload folder exist
                if (!Directory.Exists(Server.MapPath("~/Images/Eventos")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/Eventos"));
                }
                //save image on local storage
                var path = Path.Combine(Server.MapPath("~/Images/Eventos"), img.FileName);
                img.SaveAs(path);
                Newevent.imagen = img.FileName;
                Newevent.propietario = Session["UserID"].ToString();



                //empresa exists
                var empresa = db.eventos.Where(x => x.id == Newevent.id).FirstOrDefault();
                if (empresa == null)
                {
                    db.eventos.Add(Newevent);
                    db.SaveChanges();
                }
            }


            return RedirectToAction("Index", "Home");
        }
    }
}