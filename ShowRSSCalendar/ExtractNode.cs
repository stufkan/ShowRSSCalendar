using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRSSCalendar
{
    public static class ExtractNode
    {
        /// <summary>
        /// Extracts the episode information out of a episode node from ShowRSS.info
        /// </summary>
        /// <param name="node">The node containing the episode</param>
        /// <returns>An <see cref="Episode"/> with the information from the html node</returns>
        public static Episode Extract(HtmlAgilityPack.HtmlNode node)
        {

            string seriestitle = node.ChildNodes[0].ChildNodes[0].InnerHtml;

            string episodetitle = node.ChildNodes[0].ChildNodes[1].InnerHtml;
            
            string datestring = node.ParentNode.PreviousSibling.InnerHtml;
            string datestringcrop = datestring.Substring(0, datestring.Length - 1);
            DateTime date = DateTime.Parse(datestringcrop);

            
            return new Episode(seriestitle,episodetitle,date);
        }
    }
}
