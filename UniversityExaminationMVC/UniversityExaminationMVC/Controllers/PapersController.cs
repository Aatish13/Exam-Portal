using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityExaminationMVC.Models;

namespace UniversityExaminationMVC.Controllers
{
    public class PapersController : Controller
    {
        private DataModelContext db = new DataModelContext();

        // GET: Papers
        public ActionResult Index()
        {
            return View(db.Papers.ToList());
        }

        // GET: Papers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // GET: Papers/Create
        public ActionResult Create()
        {
            DataModelContext db = new DataModelContext();
            List<SelectListItem> Subject_Data = db.Subjects.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Subject = new SelectList(Subject_Data, "Value", "Text");
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,paperDate,Name,Description,isPublic,Subject_Id,Duration")] Paper paper,FormCollection form)
        {
            if (ModelState.IsValid)
            {
                paper.Faculty_Id = (int)Session["UserID"];
                paper.paperDate= paper.paperDate.AddHours(Double.Parse( form["timehours"]));
                paper.paperDate = paper.paperDate.AddMinutes(Double.Parse(form["timeminutes"]));
                db.Papers.Add(paper);
                db.SaveChanges();
                Session["id"] = paper.Id;
                return RedirectToAction("AddQuestion",new { sid = db.Subjects.Find(paper.Subject_Id).Id });
            }

            return View(paper);
        }
        [HttpGet]
        public ActionResult AddQuestion(int sid)
        {
            List<CheckModel> list = new List<CheckModel>();
            List<Question> Qns = db.Questions.Select(x => x).ToList();
            foreach(var i in Qns)
            {
                if(i.Subject_Id==sid)
                {
                    list.Add(new CheckModel { Name = i.Description, Id = i.QuestionId, check = false });
                }
            }
            return View(list);
            
        }

        [HttpPost]
        public ActionResult AddQuestion(List<CheckModel> list)
        {
            foreach(var i in list)
            {
                if(i.check==true)
                {
                    db.PaperQuestions.Add(new PaperQuestion { PaperId = (int)Session["id"], QuestionId = i.Id});
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Papers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,paperDate,Name,Description,isPublic")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paper);
        }

        // GET: Papers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paper paper = db.Papers.Find(id);
            if (paper == null)
            {
                return HttpNotFound();
            }
            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paper paper = db.Papers.Find(id);
            db.Papers.Remove(paper);
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
