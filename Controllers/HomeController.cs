using GetSiteContent.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OpenQA.Selenium.Chrome;
using GetSiteContent.Helper;

namespace GetSiteContent.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContentScrape(string inputUrl)
        {
            var uri = new Uri(inputUrl);
            
            var options = new ChromeOptions()
            {
                BinaryLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            };

            options.AddArguments(new List<string>() { "headless", "disable-gpu" });
            var browser = new ChromeDriver(options);
            browser.Navigate().GoToUrl(inputUrl);

            var ConetentScrapped = new SiteContentVM();
            ConetentScrapped.Pictures = ScrapeHelpers.GetImages(browser, uri);
            ConetentScrapped.SiteWords = ScrapeHelpers.GetWords(browser, 10);
            return View(ConetentScrapped);
        }

    }
}