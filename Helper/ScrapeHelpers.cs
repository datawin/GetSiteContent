using GetSiteContent.Models;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GetSiteContent.Helper
{
    public static class ScrapeHelpers
    {
        public static List<string> GetImages(ChromeDriver browser, Uri uri)
        {
            List<string> imgs = new List<string>();
            var imgList = browser.FindElementsByTagName("img").Where(i=>!i.Size.IsEmpty && !string.IsNullOrEmpty(i.GetAttribute("src")));
            var dns = uri.Scheme + "://" + uri.Host;
            foreach (var img in imgList)
            {
                var imgsrc = img.GetAttribute("src");
                    var imgUrl = imgsrc.StartsWith(dns) ? imgsrc : imgsrc.StartsWith("http") ? imgsrc : imgsrc.StartsWith("/") ? dns + imgsrc : dns + "/" + imgsrc;
                    imgs.Add(imgUrl);
            }
            return imgs;
        }

        public static List<WordCount> GetWords(ChromeDriver browser, int numRec)
        {
            string[] mainNodes = new string[] { "div", "a", "span", "p", "h1", "h2", "h3", "h4" };
            List<WordCount> wordsCountList = new List<WordCount>();

            foreach (var node in mainNodes)
            {
                var tagList = browser.FindElementsByTagName(node);
                foreach (var tag in tagList)
                {
                    var txtWords = GetCleanWordList(tag.Text);
                    foreach (var w in txtWords)
                    {
                        if (!wordsCountList.Any(n => n.word == w))
                        {
                            wordsCountList.Add(new WordCount { word = w, count = 1 });
                        }
                        else
                        {
                            wordsCountList.Where(t => t.word == w).Select(t => { t.count++; return t; }).ToList();
                        }
                    }
                }
            }
            return wordsCountList.OrderByDescending(w=>w.count).Take(numRec).ToList();
        }

        private static List<string> GetCleanWordList(string sentence)
        {
            var cleanSentence = sentence;
            var specialChar= new string[] { "\n", "\r", ",", ".", ":", "!", "(", ")" };

            foreach(var c in specialChar)
            {
                cleanSentence.Replace(c, "");
            }
            var splittedWords = cleanSentence.Trim().Split(' ');
            var txtWords = splittedWords
                .Where(x => !x.Contains("&nbsp;") && !string.IsNullOrEmpty(x.Trim()))
                .ToList();

            return txtWords;
        }
    }
}