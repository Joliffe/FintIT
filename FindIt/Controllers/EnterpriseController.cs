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
            return View();
        }

        //Create enterprice
        [HttpPost]
        public ActionResult Create(empresa Newempresa,HttpPostedFileBase img)
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                //upload folder exist
                if (!Directory.Exists(Server.MapPath("~/App_Data/uploads")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/App_Data/uploads"));
                }
                //save image on local storage
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), img.FileName);
                img.SaveAs(path);
                Newempresa.imagen = path;
                Newempresa.propietario = Session["UserID"].ToString();



                //empresa exists
                var empresa = db.empresa.Where(x => x.idEmpresa == Newempresa.idEmpresa).FirstOrDefault();
                if (empresa == null)
                {
                    db.empresa.Add(Newempresa);
                    db.SaveChanges();
                }
            }


            return View();
        }
    }
}