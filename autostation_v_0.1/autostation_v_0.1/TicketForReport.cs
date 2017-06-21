using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace autostation_v_0._1
{
    public class TicketForReport
    {
       [XmlAttribute] public string numberticket;
       [XmlAttribute] public string whenitbuy;
       [XmlAttribute] public string rout;
       [XmlAttribute] public string from;
       [XmlAttribute] public string to;
       [XmlAttribute] public string dateleave;
       [XmlAttribute] public string dateartive;
       [XmlAttribute] public string numberofst;
       [XmlAttribute] public string numberofp;
       [XmlAttribute] public string totalgain;
        public TicketForReport(string n,string w,string r,string f,string t, string leave,string arr,string ns,string np,string tg)
        {
            numberticket = n;
            whenitbuy = w;
            rout = r;
            from = f;
            to = t;
            dateleave = leave;
            dateartive = arr;
            numberofst = ns;
            numberofp = np;
            totalgain = tg;
        }
        public TicketForReport()
        {

        }

    }
}
