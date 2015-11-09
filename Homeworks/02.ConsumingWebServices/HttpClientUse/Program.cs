using DepartmentOfJustice.Api;
using DepartmentOfJustice.Api.Models;
using HttpClientUse.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HttpClientUse
{
    class Program
    {
        private const int PageSize = 30;

        static void Main()
        {
            var client = new ArticlesHttpClient();

            Console.WriteLine("Loading...");

            HttpResponseMessage response = client.GetArticlesAsJsonString();

            string articlesJsonString = null;
            if (response.IsSuccessStatusCode)
            {
                articlesJsonString = response.Content.ReadAsStringAsync().Result;
            }

            var albumsCollection = JsonConvert.DeserializeObject<List<Album>>(articlesJsonString);

            int page = 0;
            List<Album> pageAlbums = null;
            do
            {
                pageAlbums = albumsCollection
                    .Skip(page * PageSize)
                    .Take(PageSize)
                    .ToList();

                page++;

                var pageView = pageAlbums.Select(a => new AlbumView
                {
                    Title = a.title,
                    Url = a.url
                });

                Console.Clear();
                Console.WriteLine("Page: {0}/{1}", page, albumsCollection.Count/PageSize + 1);
                Console.WriteLine(string.Join(Environment.NewLine, pageView));
                Console.WriteLine("Press ENTER to view next page");
                Console.ReadLine();
            } while (pageAlbums.Count != 0);
        }
    }
}
