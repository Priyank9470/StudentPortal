using StudentPortal.DataAccessLayer;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    [Authorize(Users = "admin@gmail.com")]
    public class AdminController : Controller
    {
        StudentDBLayer studentDBLayer = new StudentDBLayer();
        public ActionResult Index()
        {
            List<Student> data = studentDBLayer.GetAllStudents();
            return View(data);
        }

        public ActionResult CreateStudent()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult SendNewStudentData(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDBLayer.AddStudent(student);
                return RedirectToAction("AllStudents");
            }
            return RedirectToAction("CreateStudent");
        }

        public int pageSize = 10;
        public ActionResult AllStudents(FormCollection formCollection, int page = 1)
        {
            Student model = new Student();

            //string userPageSize = formCollection["test"];
            //if (userPageSize != null)
            //{
            //    pageSize = Convert.ToInt32(userPageSize);
            //}

            string searchParam;

            if (formCollection["search-by"] != null)
            {
                searchParam = formCollection["search-by"];
            }
            else
            {
                searchParam = "";
            }

            if (page <= 0)
            {
                page = 1;
            }

            int totalDataCount = studentDBLayer.GetAllStudents().Count();

            int skipRecord = (page - 1) * pageSize;

            if (searchParam != "")
            {
                model.oldStudents = studentDBLayer.GetStudentsWithSearch(searchParam).Skip(skipRecord).Take(pageSize).ToList();
                totalDataCount = studentDBLayer.GetStudentsWithSearch(searchParam).Count();
            }
            else
            {
                model.oldStudents = studentDBLayer.GetAllStudents().Skip(skipRecord).Take(pageSize).ToList();
            }

            Pager pager = new Pager(totalDataCount, page, pageSize);

            ViewBag.Pager = pager;

            return View(model);
        }
        public ActionResult Edit(int Id)
        {
            Student students = studentDBLayer.GetAllStudents().FirstOrDefault(a => a.Id == Id);
            switch (students.Gender.ToUpper())
            {
                case "MALE":
                    students.Gender = "M";
                    break;
                case "FEMALE":
                    students.Gender = "F";
                    break;
            }
            switch (students.Course.ToUpper())
            {
                case "HTML + CSS":
                    students.Course = "1";
                    break;
                case "JAVASCRIPT":
                    students.Course = "2";
                    break;
                case "JQUERY":
                    students.Course = "3";
                    break;
                case "C#":
                    students.Course = "4";
                    break;
                case "ASP.NET":
                    students.Course = "5";
                    break;
            }
            return View(students);
        }

        [HttpPost]
        public ActionResult EditStudentDataAdmin(Student student)
        {
            if (ModelState.IsValid)
            {
                studentDBLayer.EditStudent(student);
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }
        public ActionResult Delete(int Id)
        {
            studentDBLayer.DeleteStudent(Id);
            return RedirectToAction("AllStudents");
        }
    }
}