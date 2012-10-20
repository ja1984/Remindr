using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsQuery;

namespace IMNT.Models
{
    public interface IScrapeProvider
    {
        ScrapeResult Scrape(ScrapeRequest request);
    }
}