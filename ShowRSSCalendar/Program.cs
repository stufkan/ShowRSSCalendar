using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using DDay.iCal;
using DDay.iCal.Serialization.iCalendar;

namespace ShowRSSCalendar
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Login login = new Login();

            var showtimeline = login.GetEpisodeNodes("stufkan", "stufkan");

            iCalendar ical = new iCalendar();

            foreach (var item in showtimeline)
            {
                ExtractNode.Extract(item).CreateEventFromEpisode(ical);
            }

            iCalendarSerializer serializer = new iCalendarSerializer();
            serializer.Serialize(ical, @"showRss.ics");
            

            Console.WriteLine("Done");
            Console.ReadKey();

        }

        
    }
}
