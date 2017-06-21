using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class DriverBus
    {
        public string busname;
        public string busnumber;
        public string quantity;
        public string driversur;
        
        public DriverBus(string infa)
        {
            if((infa!=null)&&(infa!=""))
            {
                string[] val=infa.Split('|');
                busname = val[0];
                busnumber = val[1];
                quantity = val[2];
                driversur = val[3];
            }
        }
    }
}
