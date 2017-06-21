using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
   public  class Sales
    {
        public int id_r;
        public int quantity;
        public double commonsum;
        public Sales(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                id_r = Convert.ToInt32(val[0]);
                quantity = Convert.ToInt32(val[1]);
                commonsum= Math.Round(Convert.ToDouble(val[2]), 2);
            }
        }
    }
}
