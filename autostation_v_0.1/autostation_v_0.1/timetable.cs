using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class timetable
    {
        public int id;
        public string str_tw;
        public string end_tw;
        public string day; 
        public string date_str;
        public string date_end;
        public double price;
        public double id_price;
        public double distation;
         public timetable(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                try
                {
                    id = Convert.ToInt32(val[0]);
                }
                catch { id = 1; }
                str_tw = val[1];
                end_tw = val[2];
                day = val[3];
                date_str = val[4];
                date_end = val[5];
                price = Math.Round( Convert.ToDouble(val[6]),2);
                id_price = Convert.ToDouble(val[7]);
                distation = Convert.ToDouble(val[8]);
              

            }
        }
    }
}
