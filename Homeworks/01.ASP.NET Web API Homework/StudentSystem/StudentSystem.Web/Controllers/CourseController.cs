namespace StudentSystem.Web.Controllers
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        private IRepository<Course> data;

        public CourseController()
        {
            this.data = new EfGenericRepository<Course>(new StudentSystemDbContext());
        }

        [HttpGet]
        [Route("all")]
        public object GetAllCourses()
        {
            var allCourses = this.data.All()
                .Select(c => new
                {
                    Name = c.Name,
                    Description = c.Description
                }).ToList();

            return allCourses;
        }
    }
}