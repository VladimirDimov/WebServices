using Artists.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artists.Web.Models
{
    public class AlbumRequestModel
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }
    }
}