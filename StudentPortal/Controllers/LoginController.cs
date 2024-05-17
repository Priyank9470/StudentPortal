using StudentPortal.DataAccessLayer;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentPortal.Controllers
{
    public class LoginController : Controller
    {
        StudentDBLayer studentDBLayer = new StudentDBLayer();
        public ActionResult Home()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        public ActionResult Index()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Login(Student student)
        {
            if (student.Email == "admin@gmail.com" && student.Password == "Admin@1234")
            {
                FormsAuthentication.SetAuthCookie("admin@gmail.com", false);
                return RedirectToAction("Index", "Admin");
            }
            else if (studentDBLayer.GetAllStudents().Any(m => m.Email == student.Email && m.Password == student.Password))
            {
                FormsAuthentication.SetAuthCookie(student.Email, false);
                Student studentData = studentDBLayer.GetAllStudents().Find(d => d.Email == student.Email);
                return RedirectToAction("Index", "Student", new { studentId = studentData.Id });
            }
            else
            {
                TempData["ErrorMsg"] = "Invalid UserName or Password";
                return RedirectToAction("index");
            }
        }
    }
}