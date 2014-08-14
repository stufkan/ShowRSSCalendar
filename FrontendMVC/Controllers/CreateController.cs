using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;
using ShowRSSCalendar;

namespace FrontendMVC.Controllers
{
    public class CreateController : Controller
    {
        //
        // GET: /Create/

        public ActionResult Index()
        {
            return View();
        }

        public static string WriteCalendar(string username, string password)
        {
            ShowRSSCalendar.Login login = new ShowRSSCalendar.Login();

            var episodes = login.GetEpisodeNodes(username, password, ScheduleTypeEnum.upcoming);
            episodes.AddRange(login.GetEpisodeNodes(username, password, ScheduleTypeEnum.aired));


            iCalendar ical = new iCalendar();

            foreach (var item in episodes)
            {
                ExtractNode.Extract(item).CreateEventFromEpisode(ical);
                Event evt = new Event();
            }

            iCalendarSerializer serializer = new iCalendarSerializer();
            return (serializer.SerializeToString(ical));

        }
    }
}
