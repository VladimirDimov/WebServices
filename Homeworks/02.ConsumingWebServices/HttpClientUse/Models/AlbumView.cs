namespace HttpClientUse.Models
{
    class AlbumView
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, Url: {1}", this.Title, this.Url);
        }
    }
}
