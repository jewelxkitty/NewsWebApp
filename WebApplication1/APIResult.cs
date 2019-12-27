using System.Collections.Generic;

namespace WebApplication1
{
    public class APIResult
    {
        //converted from public field to public properties (get|set)
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}   