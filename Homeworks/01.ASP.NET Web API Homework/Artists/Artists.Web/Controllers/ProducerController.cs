namespace Artists.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Artists.Data;
    using Artists.Models;
    using Artists.Web.Models;

    public class ProducerController : ApiController
    {
        private IRepository<Producer> producerData;

        public ProducerController()
        {
            var db = new ArtistsDbContext();
            this.producerData = new EfGenericRepository<Producer>(db);
        }
        // GET: api/Producer
        public IHttpActionResult Get()
        {
            var allProducers = this.producerData.All()
                .Select(p => new
                {
                    Id = p.ProducerId,
                    Name = p.Name
                })
                .ToList();

            return this.Ok(allProducers);
        }

        // GET: api/Producer/5
        public IHttpActionResult Get(int id)
        {
            var producerToReturn = this.producerData.All()
                .FirstOrDefault(p => p.ProducerId == id);

            if (producerToReturn == null)
            {
                return this.BadRequest(string.Format("User with id {0} not found!", id));
            }

            return this.Ok(producerToReturn);
        }

        // POST: api/Producer
        public IHttpActionResult Post(ProducerRequestModel producer)
        {
            if (producer == null)
            {
                return this.BadRequest("Invalid producer!");
            }

            this.producerData.Add(new Producer { Name = producer.Name });
            this.producerData.SaveChanges();

            return this.Ok("Priducer added");
        }

        // PUT: api/Producer/5
        public IHttpActionResult Put(int id, string name)
        {
            try
            {
                var producerToModify = this.producerData.All()
                    .FirstOrDefault(p => p.ProducerId == id);

                if (producerToModify == null)
                {
                    return this.BadRequest(string.Format("Producer with id {0} not found!", id));
                }

                producerToModify.Name = name;
                this.producerData.SaveChanges();
            }
            catch (Exception)
            {
                return this.StatusCode(HttpStatusCode.BadRequest);
            }

            return this.StatusCode(HttpStatusCode.Created);
        }

        // DELETE: api/Producer/5
        public IHttpActionResult Delete(int id)
        {
            var producerToDelete = this.producerData.All()
                .FirstOrDefault(p => p.ProducerId == id);

            if (producerToDelete == null)
            {
                return this.BadRequest(string.Format("Producer with id {0} not found!", id));
            }

            this.producerData.Delete(id);
            this.producerData.SaveChanges();
            return this.Ok();
        }
    }
}
