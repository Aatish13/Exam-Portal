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
            return View();
        }
        [HttpGet]
        public ActionResult CreateExam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExam(string type,int sem,int brch,DateTime date)
        {
            int id;
            Exam_Work ew = new Exam_Work(type,sem.ToString(),brch,date);
            id=ew.Create_Exam();
            Session["eid"] = id;
            return RedirectToAction("DashBoard");
        }
        [HttpGet]
        public ActionResult Add_Paper()
        {
            DataModelContext db = new DataModelContext();
            List<CheckModelPaper> list = db.Papers.Select(x => new CheckModelPaper {Id=x.Id,Name=x.Name,Date=x.paperDate.ToString(), check=false }).ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Add_Paper(List<CheckModelPaper> list)
        {
            DataModelContext db = new DataModelContext();
            List<Paper> l = new List<Paper>();
            foreach (var i in list)
            {
                if (i.check == true)
                {
                  //  db.ExamPapers.Add(new ExamPaper { ExamId = (int)Session["eid"], PaperId = i.Id });
                }
            }
            db.SaveChanges();
            return RedirectToAction("DashBoard");
        }
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}