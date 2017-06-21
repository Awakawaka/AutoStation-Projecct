using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class SalesBT
    {
        public string to;
        public string from;
        public int quantity;
        public double price;
        public SalesBT(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                to = val[0];
                from = val[1];
                quantity = Convert.ToInt32(val[2]);
                price = Convert.ToDouble(val[3]);
            }
        }

    }

}
