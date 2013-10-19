using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRSSCalendar
{
    class Date
    {
        List<Episode> episodes;

        public Date()
        {
            episodes = new List<Episode>();
        }

        public void Add(Episode e)
        {
            episodes.Add(e);
        }

        public void CreateCalendarEvents()
        { 
            
        }
    }
}
