using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using CsQuery;
using OpenGraph_Net;

namespace IMNT.Models.Models
{
    public class OpenGraphProvider : IScrapeProvider
    {
        public virtual ScrapeResult Scrape(ScrapeRequest request)
        {
            OpenGraph graph = OpenGraph.ParseUrl(request.Url);

            var result = new ScrapeResult
            {
                Image = graph.Image.ToString(),
                Type = graph.Type,
                Title = graph.Title,
                Url = graph.Url.ToString(),
                Description = graph["description"]
            };

            return result;
        }


    }
}