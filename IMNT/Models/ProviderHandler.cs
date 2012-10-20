using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMNT.Models.Models;

namespace IMNT.Models
{
    public static class ProviderHandler
    {

        public static IScrapeProvider GetProvider(ScrapeProvider type)
        {
            switch (type)
            {
                case ScrapeProvider.opengraph:
                    return new OpenGraphProvider();
                default:
                    return new OpenGraphProvider();
            }
        }

        public enum ScrapeProvider
        {
            opengraph,
            defaultprovider
        }

    }
}