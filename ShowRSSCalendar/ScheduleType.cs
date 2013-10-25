using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRSSCalendar
{
    public enum ScheduleTypeEnum { aired, upcoming };
    public static class ScheduleType
    {

        public static string ScheduleTypeToString(this ScheduleTypeEnum s)
        {
            string str = "";
            switch (s)
            {
                case ScheduleTypeEnum.aired:
                    str = "aired";
                    break;
                case ScheduleTypeEnum.upcoming:
                    str = "std";
                    break;
                default:
                    break;
            }
            return str;
        }
    }
}
