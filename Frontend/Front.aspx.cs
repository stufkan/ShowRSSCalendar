using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using ShowRSSCalendar;
using HtmlAgilityPack;

namespace Frontend
{
    public partial class Front : System.Web.UI.Page
    {
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            password = Request.QueryString["password"];

            if (username == string.Empty || password == string.Empty)
                return;
            else
                Button1_Click(this, new EventArgs());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowRSSCalendar.Login login = new ShowRSSCalendar.Login();

            var showtimeline = login.GetEpisodeNodes(username, password);


            iCalendar ical = new iCalendar();

            foreach (var item in showtimeline)
            {
                ExtractNode.Extract(item).CreateEventFromEpisode(ical);
            }

            iCalendarSerializer serializer = new iCalendarSerializer();
            serializer.Serialize(ical, Server.MapPath("~/showRss.ics"));

            Response.WriteFile(Server.MapPath("~/showRss.ics"));
        }
    }
}