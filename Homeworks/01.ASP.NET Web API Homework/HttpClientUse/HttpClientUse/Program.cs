namespace HttpClientUse
{
    using HttpClientUse.Models;
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    class Program
    {
        private const string GetAllCountriesUrl = "http://localhost:60039/api/country";
        private const string JsonHeader = "application/json";
        private const string XmlHeader = "text/xml";

        static void Main()
        {
            GetAllAlbumsJson();
            GetAllCountriesXml();
            PostCountry();
            UpadteGenre();
            DeleteGenre(5);
        }        

        private static void PostCountry()
        {
            Console.WriteLine("Post album");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var album = new CountryRequestModel()
                {
                    Name = "Country1"
                };

                var postContent = new StringContent(JsonConvert.SerializeObject(album));
                postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync("api/country", postContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post succsessful");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static void GetAllAlbumsJson()
        {
            Console.WriteLine("All albums");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/album").Result;

                if (response.IsSuccessStatusCode)
                {
                    var albums = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(albums);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static void GetAllCountriesXml()
        {
            Console.WriteLine("All Countries");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                HttpResponseMessage response = client.GetAsync("api/country").Result;

                if (response.IsSuccessStatusCode)
                {
                    var countries = response.Content.ReadAsStringAsync().Result;

                    Console.WriteLine(countries);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static void UpadteGenre()
        {
            Console.WriteLine("Put Producer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var album = new GenreRequestModel()
                {
                    Name = "Updated"
                };

                var postContent = new StringContent(JsonConvert.SerializeObject(album));
                postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PutAsync("api/genre/2", postContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Put succsessful");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static void DeleteGenre(int Id)
        {
            Console.WriteLine("Delete genre");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60039/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync("api/genre/" + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Delete succsessful");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}
