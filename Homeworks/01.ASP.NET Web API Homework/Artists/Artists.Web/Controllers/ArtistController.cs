namespace Artists.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Artists.Data;
    using Artists.Models;
    using Artists.Web.Models;

    public class ArtistController : ApiController
    {
        private IRepository<Artist> artistData;
        private EfGenericRepository<Country> countryData;

        public ArtistController()
        {
            var db = new ArtistsDbContext();
            this.artistData = new EfGenericRepository<Artist>(db);
            this.countryData = new EfGenericRepository<Country>(db);
        }
        // GET: api/Producer
        public IHttpActionResult Get()
        {
            var allArtists = this.artistData.All()
                .Select(a => new ArtistRequestModel
                {                    
                    Name = a.Name,
                    BirthDate = a.BirthDate,
                    Country = a.Country.Name                    
                })
                .ToList<ArtistRequestModel>();

            return this.Ok(allArtists);
        }

        // GET: api/Producer/5
        public IHttpActionResult Get(int id)
        {
            var artistToReturn = this.artistData.All()
                .FirstOrDefault(a => a.ArtistId == id);

            if (artistToReturn == null)
            {
                return this.BadRequest(string.Format("Artist with id {0} not found!", id));
            }

            return this.Ok(artistToReturn);
        }

        // POST: api/ProducerArti
        public IHttpActionResult Post(ArtistRequestModel artist)
        {
            if (artist == null)
            {
                return this.BadRequest("Invalid producer!");
            }

            var artistToAdd = new Artist
            {
                Name = artist.Name,
                BirthDate = artist.BirthDate
            };

            var artistCountry = this.countryData.All()
                .FirstOrDefault(c => c.Name == artist.Country);

            if (artistCountry == null)
            {
                return this.BadRequest("Invalid country name!");
            }

            artistToAdd.Country = artistCountry;

            this.artistData.Add(artistToAdd);
            this.artistData.SaveChanges();

            return this.Ok("Artist added");
        }

        // PUT: api/Producer/5
        public IHttpActionResult Put(int id, ArtistRequestModel artist)
        {
            if (artist == null)
            {
                return this.BadRequest("Invalid producer!");
            }

            var artistToModify = this.artistData.All()
                .FirstOrDefault(a => a.ArtistId == id);

            var artistToAdd = new Artist
            {
                Name = artist.Name,
                BirthDate = artist.BirthDate
            };

            var artistCountry = this.countryData.All()
                .FirstOrDefault(c => c.Name == artist.Country);

            if (artistCountry == null)
            {
                return this.BadRequest("Invalid country name!");
            }

            artistToAdd.Country = artistCountry;

            artistToModify.Name = artistToAdd.Name;
            artistToModify.Country = artistToAdd.Country;
            artistToModify.BirthDate = artistToAdd.BirthDate;           
            this.artistData.SaveChanges();

            return this.Ok("Artist added");
        }

        // DELETE: api/Producer/5
        public IHttpActionResult Delete(int id)
        {
            var producerToDelete = this.artistData.All()
                .FirstOrDefault(p => p.ArtistId == id);

            if (producerToDelete == null)
            {
                return this.BadRequest(string.Format("Artist with id {0} not found!", id));
            }

            this.artistData.Delete(id);
            this.artistData.SaveChanges();
            return this.Ok();
        }
    }
}
