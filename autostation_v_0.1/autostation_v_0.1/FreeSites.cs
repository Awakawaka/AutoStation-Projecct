using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class FreeSites
    {
        public int id_fs;
        public int id_r;
        public int id_town;
        public int quantity;
        public string [] frees;
        public FreeSites(string infa)
        {
            if ((infa != null) && (infa != ""))
            {
                string[] val = infa.Split('|');
                id_fs = Convert.ToInt32(val[0]);
                id_r = Convert.ToInt32(val[1]);
                id_town = Convert.ToInt32(val[2]);
                if (val[3].Count() > 2) val[3] = val[3].Remove(val[3].Count() - 1);
                if ((val[3] != null)&&(val[3]!=""))
                {
                    frees = val[3].Split('!');
                }
                
            }
        }
    }
}
