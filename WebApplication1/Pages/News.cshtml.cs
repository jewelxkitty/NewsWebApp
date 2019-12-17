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

            /*            apiresult = new APIResult();
                        apiresult.articles = new List<Article>();
                        var dogStory = new Article();

                        dogStory.title = "Local dog saves man from dangerous stick. Bark Bark.";
                        dogStory.content = "Buddy saw a dangerous stick. Buddy is a good boy. Buddy deserves treats!";
                        dogStory.publishedAt = DateTime.Today.ToShortDateString();
                        dogStory.author = "Buddy";

                        apiresult.articles.Add(dogStory);


                        var santaStory = new Article();

                        santaStory.title = "Mall Santa robs jewlery store!";
                        santaStory.content = "This mall Santa is outrageous! Stealing stuff!";
                        santaStory.publishedAt = DateTime.Today.AddDays(-1.0).ToShortDateString();
                        santaStory.author = "Ed";

                        apiresult.articles.Add(santaStory);*/

            var url = "https://newsapi.org/v2/top-headlines?" +
          "country=us&" +
          "apiKey=" + APIKey.Key;

            var json = new WebClient().DownloadString(url);

            apiresult = JsonConvert.DeserializeObject<APIResult>(json);

        }
    }
}   