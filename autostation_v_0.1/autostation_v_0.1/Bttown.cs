using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class Bttown
    {
        public int id_bt;
        public string t_name;
        public string distance;
        public Bttown(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                id_bt = Convert.ToInt32(val[0]);
                t_name = val[1];
                distance = val[2];

            }
        }
    }
}
