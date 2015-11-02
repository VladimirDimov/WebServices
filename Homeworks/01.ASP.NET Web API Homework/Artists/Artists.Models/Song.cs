namespace Artists.Models
{
    using System;

    public class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
