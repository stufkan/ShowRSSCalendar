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

        /// <summary>
        /// Appends the episode to an iCalendar calendar
        /// </summary>
        /// <param name="ical">The iCalendar to append to</param>
        public void CreateEventFromEpisode(iCalendar ical, int offset)
        {
            Event e = ical.Create<Event>();

            iCalDateTime offsetDate = (iCalDateTime)date.AddHours(offset);

            e.Start = offsetDate;
            e.End = offsetDate.AddHours(1);
            e.Summary = seriesTitle;
            e.Description = episodeTitle;
        }

       
        public override string ToString()
        {
            return seriesTitle + " | " + episodeTitle + " | " + date;
        }
    }
}
