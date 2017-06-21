using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autostation_v_0._1
{
    public class Driver
    {
       public string FIO;
       public string passd;
       public string iden;
       public string number;
       public string Condition;
        public int id;
        public Driver(string infa)
        {
            if((infa!=null)&&(infa!=""))
                {
                  string[] val = infa.Split('|');
                FIO = val[0] + " " + val[1] + " " + val[2];
                passd = val[3];
                iden = val[4];
                number = val[5];
                Condition = val[6];
                id = Convert.ToInt32(val[7]);
                    
                }
        }
    }
}
