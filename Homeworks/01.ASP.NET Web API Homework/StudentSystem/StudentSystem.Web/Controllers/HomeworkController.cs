namespace StudentSystem.Web.Controllers
{
    using StudentSystem.Data;
    using System.Web.Http;
    using System.Linq;
    using StudentSystem.Models;
    using System;

    [RoutePrefix("api/homework")]
    public class HomeworkController : ApiController
    {
        private IRepository<Homework> homeworkData;
        private IRepository<Course> courseData;

        public HomeworkController()
        {
            var db = new StudentSystemDbContext();
            this.homeworkData = new EfGenericRepository<Homework>(db);
            this.courseData = new EfGenericRepository<Course>(db);
        }

        [HttpGet]
        [Route("all")]
        public object GetAll()
        {
            var allHomeworks = this.homeworkData.All()
                .Select(h => new {
                    CourseName = h.Course.Name,
                    TimeSent = h.TimeSent,
                    FileUrl = h.FileUrl
                }).ToList();

            return allHomeworks;
        }

        [HttpPost]
        [Route("create")]
        public object Create(string courseName, string fileUrl, int studentId)
        {
            //http://localhost:2583/api/homework/create?courseName=Seeded%20course&fileUrl=someurl.com&studentId=10

            var homework = new Homework()
            {
                Course = this.courseData.All().First(c => c.Name == courseName),
                FileUrl = fileUrl,
                StudentIdentification = studentId,
                TimeSent = DateTime.Now                
            };

            this.homeworkData.Add(homework);
            this.homeworkData.SaveChanges();
            return this.Ok();
        }
    }
}