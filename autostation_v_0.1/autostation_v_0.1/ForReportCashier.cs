using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace autostation_v_0._1
{
    public class ForReportCashier
    {
       [XmlAttribute] public string routs;
        [XmlAttribute] public string dateofmaking;
        [XmlAttribute] public string period;
        [XmlElement] public List<ForDGVCahier> dg = new List<ForDGVCahier>();
        public ForReportCashier()
        {

        }
    }
}
