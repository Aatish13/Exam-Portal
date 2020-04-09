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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            DataModelContext db = new DataModelContext();
            Student user = db.Students.SingleOrDefault(x => x.Email == email);
            if(user!=null && user.Password==password)
            {
                Session["UserType"] = "Student";
                Session["UserID"] = user.Id;
                Session["UserName"] = user.Name;
                return RedirectToAction("index", "Test");
            }
            else
            {
                Faculty user1 = db.Facultys.SingleOrDefault(x => x.Email == email);
                if (user1 != null && user1.Password == password)
                {
                    Session["UserType"] = "Faculty";
                    Session["UserID"] = user1.Id;
                    Session["UserName"] = user1.Name;
                    return RedirectToAction("DashBoard", "Examination");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(string email2,string password2,string optradio)
        {
            if(optradio== "Student")
            {
                Student_Work sw = new Student_Work();
                sw.Create_Student("", password2, "", 0, email2, "");
            }
            else
            {
                Faculty_Work fw = new Faculty_Work();
                fw.Add_Faculty("", "", "", email2, password2, "");
            }
            return RedirectToAction("Login");
        }
        public ActionResult Faculty()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("/Login");
            return View();
        }
    }
}