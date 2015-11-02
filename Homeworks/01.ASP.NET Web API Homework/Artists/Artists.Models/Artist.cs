namespace Artists.Models
{
    using System;

    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
