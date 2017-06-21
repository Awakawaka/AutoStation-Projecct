using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace autostation_v_0._1
{
     public class DGVforReport
    {
       [XmlAttribute]   public string rout;
       [XmlAttribute]   public int soldtiockets;
       [XmlAttribute]   public double gain;
        public DGVforReport()
        {

        }
       public DGVforReport(string r,int s,double g)
        {
            rout = r;
            soldtiockets = s;
            gain = g;
        }
       

    }
}
