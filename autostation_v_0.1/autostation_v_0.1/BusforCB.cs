using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
   public  class BusforCB
    {
        public int id;
        public string model;
        public string number;
        public int quantity;
        public BusforCB(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                id= Convert.ToInt32(val[0]);
                model = val[1];
                number = val[2];
                quantity = Convert.ToInt32(val[3]);
            }
        }
    }
}
