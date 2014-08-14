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
        int offset;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            password = Request.QueryString["password"];
            bool offsetPresent = int.TryParse(Request.QueryString["offset"], out offset);

            if (!offsetPresent)
                offset = 33;

            if (username == string.Empty || password == string.Empty)
                return;
            else
                WriteCalendar(username, password, offset);
        }

        private void WriteCalendar(string username, string password, int offset)
        {
            ShowRSSCalendar.Login login = new ShowRSSCalendar.Login();

            var episodes = login.GetEpisodeNodes(username, password, ScheduleTypeEnum.upcoming);
            episodes.AddRange(login.GetEpisodeNodes(username, password, ScheduleTypeEnum.aired));


            iCalendar ical = new iCalendar();

            if (episodes != null)
                foreach (var item in episodes)
                {
                    ExtractNode.Extract(item).CreateEventFromEpisode(ical, offset);
                    Event evt = new Event();
                }

            iCalendarSerializer serializer = new iCalendarSerializer();
            Response.Write(serializer.SerializeToString(ical));

        }
    }
}