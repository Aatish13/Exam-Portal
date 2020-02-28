using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityExaminationMVC.Models
{
    public class ExaminationController : Controller
    {
        // GET: Examination
        public ActionResult Index()
        {
            ViewBag.Student = Session["Student"];
            return View();
        }
    }
}