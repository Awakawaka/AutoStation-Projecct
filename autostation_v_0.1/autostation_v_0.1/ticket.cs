using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class ticket
    {
        public int id;
        public DateTime pur_time;
        public int num_sttng;
        public double price;
        public string dateleave;
        public int id_r;
        public int id_t;
        public ticket(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                try
                {
                    id = Convert.ToInt32(val[0]);
                }
                catch { id = 1; }
               
                
                pur_time = DateTime.Parse(val[1]);
                
                num_sttng = Convert.ToInt32(val[2]);
                price = Convert.ToDouble(val[3]);
                dateleave = val[4];
                id_r = Convert.ToInt32(val[5]);
                id_t = Convert.ToInt32(val[6]);

            }
        }
     
     }

}

