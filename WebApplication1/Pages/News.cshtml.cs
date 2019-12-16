using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1
{
    public class NewsStory
    {

        public string Headline;
        public string Body;
        public DateTime Published;
        public string Author;
    }
    public class NewsModel : PageModel
    {
        public List<NewsStory> Articles = new List<NewsStory>();
        public string FartNoises = "pfffft";

        public void OnGet()
        {
            var hello = "Hello";
            var dogStory = new NewsStory();

            dogStory.Headline = "Local dog saves man from dangerous stick. Bark Bark.";
            dogStory.Body = "Buddy saw a dangerous stick. Buddy is a good boy. Buddy deserves treats!";
            dogStory.Published = DateTime.Today;
            dogStory.Author = "Buddy";

            Articles.Add(dogStory);


            var santaStory = new NewsStory();

            santaStory.Headline = "Mall Santa robs jewlery store!";
            santaStory.Body = "This mall Santa is outrageous! Stealing stuff!";
            santaStory.Published = DateTime.Today.AddDays(-1.0);
            santaStory.Author = "Ed";

            Articles.Add(santaStory);
        }
    }
}   