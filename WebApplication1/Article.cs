using System;

namespace WebApplication1
{
    public class Article
    {
        //converted from public field to public properties (get|set)
        public Source source { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string publishedAt { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public DateTime publishDate { get; set; } = DateTime.Today;
    }

    public class Source
    {

        public string id;
        public string name;

    }
}   