namespace Artists.Web.Controllers
{
    using Artists.Data;
    using Artists.Models;
    using Artists.Web.Models;
    using System.Linq;
    using System.Web.Http;

    public class SongController : ApiController
    {
        private IRepository<Song> songData;
        private IRepository<Genre> genreData;
        private IRepository<Artist> artistData;
        private IRepository<Album> albumData;

        public SongController()
        {
            var db = new ArtistsDbContext();
            this.songData = new EfGenericRepository<Song>(db);
            this.genreData = new EfGenericRepository<Genre>(db);
            this.artistData = new EfGenericRepository<Artist>(db);
            this.albumData = new EfGenericRepository<Album>(db);
        }
        // GET: api/Song
        public IHttpActionResult Get()
        {
            var allSongs = this.songData.All()
                .Select(s => new
                {
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    Artist = s.Artist
                })
                .ToList();

            return this.Ok(allSongs);
        }

        // GET: api/Song/5
        public IHttpActionResult Get(int id)
        {
            var songToReturn = this.songData.All()
               .FirstOrDefault(s => s.ArtistId == id);

            if (songToReturn == null)
            {
                return this.BadRequest(string.Format("Song with id {0} not found!", id));
            }

            return this.Ok(songToReturn);
        }

        // POST: api/Song
        public IHttpActionResult Post(SongRequestModel song)
        {
            var songToAdd = new Song
            {
                Title = song.Title,
                Year = song.Year
            };

            var genre = this.genreData.All()
                .FirstOrDefault(g => g.Name == song.Genre);
            if (genre == null)
            {
                return this.BadRequest("Invalid song genre!");
            }
            songToAdd.Genre = genre;

            var artist = this.artistData.All()
                .FirstOrDefault(a => a.Name == song.Artist);
            if (artist == null)
            {
                return this.BadRequest("Invalid song artist!");
            }
            songToAdd.Artist = artist;

            var album = this.albumData.All()
                .FirstOrDefault(a => a.Title == song.Album);
            if (album == null)
            {
                return this.BadRequest("Invalid album artist!");
            }
            songToAdd.Album = album;

            this.songData.Add(songToAdd);
            this.songData.SaveChanges();
            return this.Ok();
        }

        // PUT: api/Song/5
        public IHttpActionResult Put(int id, SongRequestModel songInfo)
        {
            if (songInfo == null)
            {
                return this.BadRequest("Invalid song info!");
            }

            var songToModify = this.songData.All()
                .FirstOrDefault(s => s.SongId == id);

            if (songToModify == null)
            {
                return this.BadRequest(string.Format("Song with id {0} not found!", id));
            }

            songToModify.Title = songInfo.Title;
            songToModify.Year = songInfo.Year;
            songToModify.Genre = this.genreData.All().FirstOrDefault(g => g.Name == songInfo.Genre);
            songToModify.Artist = this.artistData.All().FirstOrDefault(a => a.Name == songInfo.Artist);

            this.songData.SaveChanges();
            return this.Ok("Song modified!");
        }

        // DELETE: api/Song/5
        public IHttpActionResult Delete(int id)
        {
            var songToDelete = this.songData.All()
                .FirstOrDefault(s => s.SongId == id);

            if (songToDelete == null)
            {
                return this.BadRequest(string.Format("Song with id {0} not found!", id));
            }

            this.songData.Delete(songToDelete);
            this.songData.SaveChanges();

            return this.Ok(string.Format("Song with id {0} deleted!", id));
        }
    }
}
