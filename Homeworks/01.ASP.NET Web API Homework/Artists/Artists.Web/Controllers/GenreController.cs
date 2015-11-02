namespace Artists.Web.Controllers
{
    using Artists.Data;
    using Artists.Models;
    using Artists.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class GenreController : ApiController
    {
        private IRepository<Genre> genreData;

        public GenreController()
        {
            var db = new ArtistsDbContext();
            this.genreData = new EfGenericRepository<Genre>(db);
        }

        // GET: api/Genre
        public IHttpActionResult Get()
        {
            var allGenres = this.genreData.All()
                .Select(g => new GenreRequestModel{ Name = g.Name})
                .ToList();

            return this.Ok(allGenres);
        }

        // GET: api/Genre/5
        public IHttpActionResult Get(int id)
        {
            var genreToReturn = this.genreData.All()
                .FirstOrDefault(g => g.GenreId == id);

            if (genreToReturn == null)
            {
                return this.BadRequest(string.Format("Genre with id {0} not found!", id));
            }

            return this.Ok(genreToReturn);
        }

        // POST: api/Genre
        public IHttpActionResult Post(GenreRequestModel genreInfo)
        {
            if (genreInfo == null)
            {
                return this.BadRequest("Invalid gernre format!");
            }

            this.genreData.Add(new Genre { Name = genreInfo.Name });
            this.genreData.SaveChanges();
            return this.Ok("Genre added!");
        }

        // PUT: api/Genre/5
        public IHttpActionResult Put(int id, GenreRequestModel genreInfo)
        {
            if (genreInfo == null)
            {
                return this.BadRequest("Invalid genre format!");
            }
            var genreToModify = this.genreData.All()
                .FirstOrDefault(g => g.GenreId == id);

            if (genreToModify == null)
            {
                return this.BadRequest("Invalid gernre id");
            }

            genreToModify.Name = genreInfo.Name;
            this.genreData.SaveChanges();

            return this.Ok("Genre modified!");
        }

        // DELETE: api/Genre/5
        public IHttpActionResult Delete(int id)
        {
            var genreToDelete = this.genreData.All()
                .FirstOrDefault(g => g.GenreId == id);

            if (genreToDelete == null)
            {
                return this.BadRequest("Invalid gernre id");
            }

            this.genreData.Delete(genreToDelete);
            this.genreData.SaveChanges();
            return this.Ok("Genre deleted!");
        }
    }
}
