using StudentPortal.DataAccessLayer;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class SignUpController : Controller
    {
        StudentDBLayer studentDBLayer = new StudentDBLayer();
        // GET: SignUp
        public ActionResult SignUp()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult SendStudentData(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentDBLayer.AddStudent(student);
                    return RedirectToAction("Index", "login");
                }
                return RedirectToAction("SignUp");
            }
            catch (SqlException)
            {
                return RedirectToAction("SqlError");
            }
        }
        public ActionResult SqlError()
        {
            return View();
        }
    }
}