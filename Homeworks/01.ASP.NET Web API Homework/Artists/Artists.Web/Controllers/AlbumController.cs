namespace Artists.Web.Controllers
{
    using Artists.Data;
    using Artists.Models;
    using Artists.Web.Models;
    using System.Linq;
    using System.Web.Http;

    public class AlbumController : ApiController
    {
        private IRepository<Album> albumData;
        private IRepository<Producer> producerData;

        public AlbumController()
        {
            var db = new ArtistsDbContext();
            this.albumData = new EfGenericRepository<Album>(db);
            this.producerData = new EfGenericRepository<Producer>(db);
        }

        // GET: api/Album
        public IHttpActionResult Get()
        {
            var allAlbums = this.albumData.All()
                .Select(a => new
                {
                    Title = a.Title,
                    Producer = a.Producer,
                    Year = a.Year,
                    Artists = a.Artists.Select(art => new { art.Name}),
                    Songs = a.Songs.Select(s => new { Title = s.Title })
                })
                .ToList();

            return this.Ok(allAlbums);
        }

        // GET: api/Album/5
        public IHttpActionResult Get(int id)
        {
            var albumToReturn = this.albumData.All()
                .FirstOrDefault(a => a.AlbumId == id);

            return this.Ok(albumToReturn);
        }

        // POST: api/Album
        public IHttpActionResult Post(AlbumRequestModel albumInfo)
        {
            if (albumInfo == null)
            {
                return this.BadRequest();
            }

            var albumToAdd = new Album
            {
                Title = albumInfo.Title,
                Year = albumInfo.Year,
            };

            albumToAdd.Producer = this.producerData.All().FirstOrDefault(p => p.Name == albumInfo.Producer);

            this.albumData.Add(albumToAdd);
            this.albumData.SaveChanges();

            return this.Ok();
        }

        // PUT: api/Album/5
        public IHttpActionResult Put(int id, AlbumRequestModel albumInfo)
        {
            if (albumInfo == null)
            {
                return this.BadRequest();
            }

            var albumToModify = this.albumData.All()
                .FirstOrDefault(a => a.AlbumId == id);

            if (albumToModify == null)
            {
                return this.BadRequest(string.Format("Album with id {0} not found!", id));
            }

            albumToModify.Title = albumInfo.Title;
            albumToModify.Year = albumInfo.Year;
            albumToModify.Producer = this.producerData.All().FirstOrDefault(p => p.Name == albumInfo.Producer);

            this.albumData.SaveChanges();

            return this.Ok();
        }

        // DELETE: api/Album/5
        public IHttpActionResult Delete(int id)
        {
            var albumToRemove = this.albumData.All()
                .FirstOrDefault(a => a.AlbumId == id);

            this.albumData.Delete(albumToRemove);
            this.albumData.SaveChanges();

            return this.Ok("Album removed!");
        }
    }
}
