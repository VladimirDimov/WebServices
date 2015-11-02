namespace Artists.Web.Models
{
    using System;

    public class ArtistRequestModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime BirthDate { get; set; }
    }
}