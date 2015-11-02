namespace StudentSystem.Web.Controllers
{
    using StudentSystem.Data;
    using System.Web.Http;
    using System.Linq;
    using StudentSystem.Models;

    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private IRepository<Test> testsData;

        public TestController()
        {
            var db = new StudentSystemDbContext();
            this.testsData = new EfGenericRepository<Test>(db);
        }

        [Route("all")]
        public object GetAll()
        {
            var allTests = this.testsData.All()
                .Select(t => new 
                { 
                    CourseName = t.Course.Name,
                    Students = t.Students.Select(s => s.FirstName + " " + s.LastName)
                })
                .ToList();

            return allTests;
        }
    }
}