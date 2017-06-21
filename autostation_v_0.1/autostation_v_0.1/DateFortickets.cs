using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class DistanceBT
    {
      public double distance;
      public double speed;
        public DistanceBT(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val= infa.Split('|');
                distance = Convert.ToDouble(val[0]);
                speed = Convert.ToDouble(val[1]);
            }
        }
    }
}
