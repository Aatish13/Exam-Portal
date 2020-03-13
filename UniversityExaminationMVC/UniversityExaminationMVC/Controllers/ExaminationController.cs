using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityExaminationMVC.Models;

namespace UniversityExaminationMVC.Models
{
    public class ExaminationController : Controller
    {
        // GET: Examination
        public ActionResult Index()
        {
            ViewBag.Student = Session["Student"];
            DataModelContext db = new DataModelContext();
            Exam_Work ew = new Exam_Work("Internal","6");
            return View();
        }

        public ActionResult Navigation_Bar()
        {
            return PartialView();
        }
    }
}