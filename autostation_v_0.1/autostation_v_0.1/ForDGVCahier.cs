using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace autostation_v_0._1
{
   public class ForDGVCahier
    {
       [XmlAttribute] public string routnumber;
       [XmlAttribute] public string rout;
       [XmlAttribute] public string numberoftickets;
       [XmlAttribute] public string numberofreturntickets;
       [XmlAttribute] public string totalgain;
        public ForDGVCahier(string rn,string r, string nt,string nrt, string tg)
        {
            routnumber = rn;
            rout = r;
            numberoftickets = nt;
            numberofreturntickets = nrt;
            totalgain = tg;
        }
        public ForDGVCahier()
        {

        }
    }
}
