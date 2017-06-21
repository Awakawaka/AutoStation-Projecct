using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace autostation_v_0._1
{
   public class InformationforCheck
    {
     [XmlElement] public  List<TicketForReport> ticket = new List<TicketForReport>();
         public InformationforCheck()
        {

        }
    }
}
