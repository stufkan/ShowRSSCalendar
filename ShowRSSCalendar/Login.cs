using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ShowRSSCalendar
{
    public class Login
    {
        CookieContainer cookies;
        HttpWebRequest req;

        public Login()
        {
            cookies = new CookieContainer();
        }

        /// <summary>
        /// Fetches the <see cref="scrape"/> after logging into the <see cref="url"/> with the specified <see cref="postdata"/>
        /// </summary>
        /// <param name="url">The URL to login at </param>
        /// <param name="postdata">The postdata to login with.</param>
        /// <param name="scrape">The page to scrape.</param>
        /// <returns>The fetched page</returns>
        private string GetPage(string url, string postdata, string scrape)
        {
            req = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookies = new CookieContainer();
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.CookieContainer = cookies;

            StreamWriter requestWriter = new StreamWriter(req.GetRequestStream());
            requestWriter.Write(postdata);
            requestWriter.Close();

            req.GetResponse();
            cookies = req.CookieContainer;

            req = WebRequest.Create(scrape) as HttpWebRequest;
            req.CookieContainer = cookies;

            StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream());

            string response = responseReader.ReadToEnd();
            responseReader.Close();

            return response;
        }


        /// <summary>
        /// Gets the episode nodes from the ShowRss.info page with the specified login
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public HtmlNodeCollection GetEpisodeNodes(string username, string password)
        {
            string url = @"http://showrss.info/?cs=login";
            string postdata = string.Format("username={0}&password={1}",username,password);
            string scrape = @"http://showrss.info/?cs=schedule&mode=std&print=std";

            HtmlDocument htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(GetPage(url, postdata, scrape));

            HtmlNode node = htmldocument.DocumentNode;

            return node.SelectNodes("//div[@id='show_timeline']//div");
        }

    }
}
