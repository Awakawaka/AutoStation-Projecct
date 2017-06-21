using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
   public  class towns
    {
        public int id;
        public string name_t;
  
        public towns(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                try
                {
                    id = Convert.ToInt32(val[0]);
                }
                catch { id = 1; }
                name_t = val[1];
              


            }
        }
    }
}
