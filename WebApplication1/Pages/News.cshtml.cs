using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using Newtonsoft.Json;

namespace WebApplication1
{

    public class Source
    {

        public string id;
        public string name;

    }
    public class Article
    {
        public Source source;
        public string title;
        public string content;
        public string publishedAt;
        public string author;
        public string description;
        public string url;
        public string urlToImage;
        public DateTime publishDate
        {
            get
            {
                return DateTime.Today;
            }
        }
    }

    public class APIResult
    {
        public string status;
        public int totalResults;
        public List<Article> articles;
    }
    public class NewsModel : PageModel
    {
        public APIResult apiresult;

        public void OnGet()
        {


            var url = "https://newsapi.org/v2/top-headlines?" +
          "country=us&" +
          "apiKey=" + APIKey.Key;

            var json = new WebClient().DownloadString(url);

            apiresult = JsonConvert.DeserializeObject<APIResult>(json);

        }
    }
}   