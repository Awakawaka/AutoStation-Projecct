using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class SearchDouble
    {
        public double id;
        public SearchDouble(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                try
                {
                    id = Convert.ToDouble(val[0]);
                }
                catch { id = 1; }



            }
        }
    }
}
