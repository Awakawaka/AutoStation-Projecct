using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class DriverCB
    {
        public int id_d;
       public string family;
       public string condition;
        public DriverCB(string infa)
        {
            if((infa!=null)&&(infa!=""))
            {
                string[] val = infa.Split('|');
                id_d = Convert.ToInt32(val[0]);
                family = val[1];
                condition = val[2];
            }
        }
    }
}
