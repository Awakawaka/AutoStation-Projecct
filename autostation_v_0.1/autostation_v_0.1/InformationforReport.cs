using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace autostation_v_0._1
{
    public class InformationforReport
    {
      [XmlAttribute]  public string rout;
      [XmlAttribute]  public int quantitysoldticket;
      [XmlAttribute]  public int quantityreturnticket;
      [XmlAttribute]  public string fromdate;
      [XmlAttribute]  public string todate;
      [XmlAttribute]  public double gain;
      [XmlElement]  public List<DGVforReport> a=new List<DGVforReport>();
        public InformationforReport()
        {

        }
       
    }
}
