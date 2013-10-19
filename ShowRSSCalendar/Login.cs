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

        private string GetCookie(string url, string login, string scrape)
        {
            req = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookies = new CookieContainer();
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            req.CookieContainer = cookies;

            StreamWriter requestWriter = new StreamWriter(req.GetRequestStream());
            requestWriter.Write(login);
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

        public HtmlNodeCollection GetEpisodeNodes(string username, string password)
        {
            string url = @"http://showrss.info/?cs=login";
            string postdata = string.Format("username={0}&password={1}",username,password);
            string scrape = @"http://showrss.info/?cs=schedule&mode=std&print=std";

            HtmlDocument htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(GetCookie(url, postdata, scrape));

            HtmlNode node = htmldocument.DocumentNode;

            return node.SelectNodes("//div[@id='show_timeline']//div");
        }

    }
}
