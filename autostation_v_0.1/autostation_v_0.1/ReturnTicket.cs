using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class ReturnTicket
    {
        public int quantity;
        public double sum;
        public ReturnTicket(string infa)
        {
            if((infa!=null)&&(infa!=""))

                    {
                string[] val = infa.Split('|');
                quantity = Convert.ToInt32(val[0]);
                sum = Convert.ToDouble(val[1]);
            }
        }
    }
}
