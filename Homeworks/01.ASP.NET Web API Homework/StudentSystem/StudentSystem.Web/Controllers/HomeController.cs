using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.Controllers
{
    public class HomeController
    {
        public static object Get()
        {
            return new
            {
                GetAllCourses = "api/course/all",
                GetAllStudents = "api/student/all",
                CreateNewStudent = "api/student/create?firstName=...&lastName=...&level=...",
                GetAllTests = "api/test/all",
                GetAllHomeworks = "api/homework/all",
                CreateNewHomework = "api/student/create?courseName=...&fileUrl=...&studentId=..."
            };
        }
    }
}