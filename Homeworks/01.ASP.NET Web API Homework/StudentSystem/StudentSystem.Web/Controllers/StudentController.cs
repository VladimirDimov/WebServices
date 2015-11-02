namespace StudentSystem.Web.Controllers
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;

    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        private IRepository<Student> studentsData;

        public StudentController()
        {
            var db = new StudentSystemDbContext();
            this.studentsData = new EfGenericRepository<Student>(db);
        }

        [HttpGet]
        [Route("all")]
        public object GetAllStudents()
        {
            var allStudents = this.studentsData.All()
                .Select(s => new
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }).ToList();

            return allStudents;
        }

        [HttpPost]
        [Route("create")]
        public HttpContent Create(string firstName, string lastName, int level)
        {
            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Level = level
            };

            this.studentsData.Add(student);
            this.studentsData.SaveChanges();

            return this.Request.Content;
        }
    }
}