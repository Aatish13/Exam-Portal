using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityExaminationMVC.Models;
namespace UniversityExaminationMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(FormCollection form)
        {
            string dob = form["password"];
            string email = form["email"];
            if (dob != null && email != null)
            {
                DataModelContext db = new DataModelContext();
                Student s = db.Students.SingleOrDefault(x => x.DOB == dob && x.Email == email);
                if (s != null)
                {
                    Session.Add("Student", s);
                    Session.Add("User", "student");
                    Response.Redirect("/Examination");
                }
                else
                {
                    return Student();
                }

            }
            return View();
        }
        public ActionResult Faculty()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            if (Session["User"].ToString() == "student")
            {
                Session.Remove("Student");
            }
            Response.Redirect("Home");
            return View();
        }
    }
}