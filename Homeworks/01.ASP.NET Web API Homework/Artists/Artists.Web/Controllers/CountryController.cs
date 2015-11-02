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

    public class CountryController : ApiController
    {
        private IRepository<Country> countryData;

        public CountryController()
        {
            var db = new ArtistsDbContext();
            this.countryData = new EfGenericRepository<Country>(db);
        }

        public IHttpActionResult Get()
        {
            var allCountries = countryData.All().ToList();

            return this.Ok(allCountries);
        }

        public IHttpActionResult Post(CountryRequestModel country)
        {
            if (country == null)
            {
                return this.BadRequest();
            }
            countryData.Add(new Country()
            {
                Name = country.Name
            });

            countryData.SaveChanges();

            return this.Ok();
        }
    }
}
