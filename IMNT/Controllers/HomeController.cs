using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using IMNT.Models;
using IMNT.Models.Models;

namespace IMNT.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string userName = null)
        {

            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Index", new { userName = GenerateUserName() });

            var list = GetUserList(userName);

            return View(list);
        }

        public JsonResult Scrape(string url, string userName)
        {
            var scraper = ProviderHandler.GetProvider(ProviderHandler.ScrapeProvider.opengraph);
            var result = scraper.Scrape(new ScrapeRequest { Url = url });


            using (var session = DataDocumentStore.Instance.OpenSession())
            {

                var list = session.Query<RememberList>().FirstOrDefault(x => x.UserName == userName) ?? new RememberList() { UserName = userName, Posts = new List<Post>() };


                list.Posts.Add(new Post()
                                   {
                                       Description = result.Description,
                                       Image = result.Image,
                                       Name = result.Name,
                                       Title = result.Title,
                                       Type = result.Type,
                                       Url = result.Url
                                   });

                if (list.Id == 0)
                    session.Store(list);

                session.SaveChanges();

            }

            return Json(result);
        }


        private RememberList GetUserList(string userName)
        {

            using (var session = DataDocumentStore.Instance.OpenSession())
            {
                return session.Query<RememberList>().FirstOrDefault(x => x.UserName == userName) ?? new RememberList() { UserName = userName, Posts = new List<Post>() };
            }
        }

        private string GenerateUserName()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

    }
}
