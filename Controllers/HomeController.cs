using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using System.Data.OleDb;
using System.Collections.Generic;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        string connectionString =
@"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\hp\OneDrive\Documents\Student.accdb";

        // 🔥 BURASI VACİBDİR
        static List<StudentCourse> list = new List<StudentCourse>();

        public IActionResult Index()
        {
            return View(list);
        }

        [HttpPost]
        public IActionResult Index(string studentName, string courseName)
        {
            StudentCourse model = new StudentCourse
            {
                StudentName = studentName,
                CourseName = courseName,
                CurrentCount = 1
            };

            if (courseName == "Csharp")
                model.Limit = 20;
            else if (courseName == "Riyaziyyat")
                model.Limit = 2;
            else
                model.Limit = 15;

            // 🔥 list-ə əlavə edirik
            list.Add(model);

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}