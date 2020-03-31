using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SanghaMVC.Controllers
{
    public class WebScrapingController : Controller
    {
        // GET: WebScraping
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetUrlSource(string url)
        {
            url = url.Substring(0, 4) != "http" ? "http://" + url : url;
            string htmlCode = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    htmlCode = client.DownloadString(url);
                }
                catch (Exception ex)
                {

                }
            }
            return htmlCode;
        }
    }
}