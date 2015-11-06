namespace CookiesSystem.Web.Models.Cookie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CookieSaveRequestModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }
    }
}