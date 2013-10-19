using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDay.iCal;
using DDay.Collections;

namespace ShowRSSCalendar
{
    public class Episode
    {
        string seriesTitle;
        string episodeTitle;
        iCalDateTime date;

        public Episode(string seriesTitle, string episodeTitle, iCalDateTime date)
        {
            this.seriesTitle = seriesTitle;
            this.episodeTitle = episodeTitle;
            this.date = date;
        }

        public void CreateEventFromEpisode(iCalendar ical)
        {
            Event e = ical.Create<Event>();
            e.Start = date.AddDays(1).AddHours(7); ;
            e.End = date.AddDays(1).AddHours(8);
            e.Summary = seriesTitle;
            e.Description = episodeTitle;
        }

        public override string ToString()
        {
            return seriesTitle + " | " + episodeTitle + " | " + date;
        }
    }
}
