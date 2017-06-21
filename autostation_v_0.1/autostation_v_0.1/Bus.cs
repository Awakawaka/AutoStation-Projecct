using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
     public class Bus
    {
        public int id;
        public string model;
        public string number;
        public int quantity;
        public double averagespeed;
        public string condition;

            public Bus(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                id = Convert.ToInt32(val[0]);
                model = val[2];
                number = val[1];
                quantity = Convert.ToInt32(val[3]);
                averagespeed = Convert.ToDouble(val[4]);
                condition = val[5];
            }
        }
    }
}
