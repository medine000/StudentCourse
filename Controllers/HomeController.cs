using System.Data.OleDb;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        string connectionString =
@"Provider=Microsoft.ACE.OLEDB.12.0;
Data Source=C:\Users\hp\OneDrive\Documents\Student.accdb";

        public IActionResult Index()
        {
            List<StudentCourse> list = new List<StudentCourse>();

            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(
                    "SELECT * FROM Student", con);

                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new StudentCourse
                    {
                        StudentName = dr["StudentName"].ToString(),
                        CourseName = dr["CourseName"].ToString(),
                        CurrentCount = 1,
                        Limit = 0
                    });
                }
            }

            return View(list);
        }

        [HttpPost]
        public IActionResult Index(string studentName, string courseName)
        {
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                con.Open();

                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO Student (StudentName, CourseName) VALUES (?, ?)", con);

                cmd.Parameters.AddWithValue("@p1", studentName);
                cmd.Parameters.AddWithValue("@p2", courseName);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}