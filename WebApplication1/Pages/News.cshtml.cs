using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;

namespace WebApplication1
{
    public class NewsModel : PageModel
    {
        private readonly API apiSettings;
        private readonly IHttpClientFactory clientFactory;
        public APIResult apiresult;

        public NewsModel(IHttpClientFactory clientFactory, IOptionsSnapshot<API> apiSettings)
        {
            this.apiSettings = apiSettings.Value;
            this.clientFactory = clientFactory;
        }

        public void OnGet()
        {
            var client = clientFactory.CreateClient();

            var url = $"{apiSettings.Url}&apiKey={apiSettings.Key}";

            var response = client.GetAsync(url).Result; //This is an asynchronous call; but let's ignore that an make it synchronous code for now by calling .Result

            // we only want to parse the response if it's a sucessful one
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result; //This is an asynchronous call; but let's ignore that an make it synchronous code for now by calling .Result

                //The .Net Core framework now come with it's on JSON serializer/deserializer (System.Text.Json.JsonSerializer) since Newtonsoft.Json is less efficient
                apiresult = JsonSerializer.Deserialize<APIResult>(json);
            }
            else
            {
                apiresult = new APIResult { articles = new List<Article>() };
            }

        }
    }
}