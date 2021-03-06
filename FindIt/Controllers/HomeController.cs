﻿using FindIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                var empresaList = db.empresa.ToList();
                return View(empresaList);
            }

               
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Events()
        {
            using (db_globalesEntities2 db = new db_globalesEntities2())
            {
                var eventlist = db.eventos.ToList();
                return View("Index", eventlist);
            }

                
        }

        public ActionResult Login()
        {
            ViewBag.message = "Login Page";

            return View();
        }
    }
}