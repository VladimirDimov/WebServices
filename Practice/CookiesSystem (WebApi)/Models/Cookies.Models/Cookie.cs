﻿namespace Cookies.Models
{
    public class Cookie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
