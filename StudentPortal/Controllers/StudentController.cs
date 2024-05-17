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
    [Authorize]
    public class StudentController : Controller
    {
        StudentDBLayer studentDBLayer = new StudentDBLayer();
        public ActionResult Index(int studentId)
        {
            Student modalStudentData = studentDBLayer.GetAllStudents().Find(x => x.Id == studentId);
            Session["studentData"] = modalStudentData;
            return RedirectToAction("Home");
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult StudentProfile()
        {
            return View();
        }
        public ActionResult Edit()
        {
            Student data = (Student)Session["studentData"];
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                studentDBLayer.EditStudent(model);
                return RedirectToAction("StudentProfile");
            }
            return RedirectToAction("Edit");
        }
    }
}