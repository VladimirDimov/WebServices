namespace Artists.Models
{
    using System.Collections.Generic;

    public class Genre
    {
        private ICollection<Song> songs;

        public Genre()
        {
            this.songs = new HashSet<Song>();
        }

        public int GenreId { get; set; }

        public string Name { get; set; }

        public ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }
    }
}
