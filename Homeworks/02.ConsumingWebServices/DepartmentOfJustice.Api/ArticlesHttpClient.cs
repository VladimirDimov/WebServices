namespace DepartmentOfJustice.Api
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class ArticlesHttpClient
    {
        private const string JsonHeader = "application/json";
        private const string BaseAddress = "http://jsonplaceholder.typicode.com";

        public ArticlesHttpClient()
        {
        }

        public HttpResponseMessage GetArticlesAsJsonString()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(BaseAddress);
            var response = httpClient.GetAsync("/photos").Result;

            return response;
        }
    }
}
