using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autostation_v_0._1
{
    public class MethodsFMT
    {
        fmt r;
        fm fm;
        int id;
        DialogResult dr;
        string date;
        ClassSetupProgram sp =  new ClassSetupProgram();
        ClassDataBase db = new ClassDataBase();
        public MethodsFMT(fmt t, fm i,int counter)
        {
            r = t;
            fm = i;
            id = counter; 
        }
        public MethodsFMT(fmt t, fm i, int counter, DialogResult resultfromForm, string d)
        {
            r = t;
            fm = i;
            id = counter;
            dr = resultfromForm;
            date = d;
        }
        public void ShowInfo()
        {
            r.tbwhn.Text = DateTime.Now.ToString();
            r.tbrout.Text = fm.list1[id].str_tw + "-" + fm.list1[id].end_tw;
            r.tbfrm.Text = fm.dgvm[1, fm.id].Value.ToString();
            r.tbto.Text = fm.dgvm[2, fm.id].Value.ToString();
            r.tbdatefrom.Text = date + " " + fm.dgvm[4, fm.id].Value.ToString();
            r.tbdtt.Text = date + " " + fm.dgvm[5, fm.id].Value.ToString();
            r.tbprice.Text = fm.dgvm[6, fm.id].Value.ToString();
            LoadSites();
            r.tbn.Text = Convert.ToInt32(NumberofTicket()).ToString();
            LoadPlatForm();
        }
        public void ShowInfo(int o)
        {
            r.tbwhn.Text = DateTime.Now.ToString();
            r.tbrout.Text = fm.list1[id].str_tw + "-" + fm.list1[id].end_tw;
            r.tbfrm.Text = fm.list1[id].str_tw;
            r.tbto.Text = fm.list1[id].end_tw;
            r.tbdatefrom.Text= date + " " + fm.dgvm[4, fm.id].Value.ToString();
            r.tbdtt.Text= date + " " + fm.dgvm[5, fm.id].Value.ToString();
            r.tbprice.Text = fm.list1[fm.id].price.ToString();
            r.tbn.Text = Convert.ToInt32(NumberofTicket()).ToString();
            LoadSites();
            LoadPlatForm();

        }
        public void LoadPlatForm()
        {
            fm.search1.Clear();
            db.Execute<Shearch>(ref sp, "select r.N_P from rout r where r.id_R='"+fm.list1[id].id+"'", ref fm.search1);
            r.tbnp.Text = fm.search1[0].id.ToString();
        }
        public void LoadSites()
        {
            db.Execute<Shearch>(ref sp, "SELECT l.QUANTITY_L from look l ,rout r, connectionr_d cd,bus b where r.ID_R=cd.id_r and b.ID_B=cd.ID_B and b.ID_L=l.ID_L and r.ID_R='" + fm.list1[id].id + "'", ref fm.search1);
            int countr = fm.search1[fm.search1.Count - 1].id;
            if ((r.tbfrm.Text==fm.list1[id].str_tw)&&(r.tbto.Text==fm.list1[id].end_tw))
            {
                r.forcase = 0;
                fm.search1.Clear();
                db.Execute<Shearch>(ref sp, "SELECT t.NS_T FROM ticket t, rout r where r.ID_R=t.ID_R and r.id_r='"+fm.list1[id].id+ "' and t.dataleave='"+ DateTime.Parse(r.tbdatefrom.Text).ToString("yyyy.MM.dd HH:mm:ss") + "'", ref fm.search1);
                bool trigger = false;
                if (fm.search1.Count != 0)
                { 
                    for (int i = 1; i <= countr; i++)
                    {
                        for (int j = 0; j <fm.search1.Count; j++)
                        {
                            if(fm.search1[j].id==i)
                            { trigger = true; }

                        }
                        if (trigger != true)
                        {
                            r.cbn_sts.Items.Add(i);
                            trigger = false;
                        }
                        else trigger = false;

                    }
                }
                else
                {
                    for (int i = 1; i < countr; i++)
                    {
                        r.cbn_sts.Items.Add(i);
                    }
                }
                fm.search1.Clear();
            }
            if((r.tbfrm.Text == fm.list1[id].str_tw) && (r.tbto.Text != fm.list1[id].end_tw))
            {
                r.forcase = 1;
                int start = 0;
                int end = 0;
                SearchTown(r.tbfrm.Text);
                start = fm.search1[0].id;
                SearchTown(r.tbto.Text);
                end = fm.search1[0].id;
                fm.search1.Clear();
                List<int> s = new List<int>();
                db.Execute<Shearch>(ref sp, "SELECT t.NS_T FROM ticket t, rout r where r.ID_R=t.ID_R and t.id_St='"+start+"' and r.id_r'="+fm.list1[id].id+ "' and t.dataleave='" + DateTime.Parse(r.tbdatefrom.Text).ToString("yyyy.MM.dd HH: mm:ss") + "'", ref fm.search1);
                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F,s.ID_R,s.id_t,s.Number_S,s.QUANTITY_F from free_s s ,rout r,datefors ds where s.ID_R=r.id_R and r.ID_R='" + fm.list1[id].id + "' and s.id_t='" + end + "' and ds.id_d='"+fm.iddate+ "' and s.id_D=ds.id_d", ref fm.forsearch);
                for (int i = 0; i < fm.forsearch[0].frees.Length; i++)
                {
                    if (fm.forsearch[0].frees[i] != "")
                    {
                        s.Add(Convert.ToInt32(fm.forsearch[0].frees[i]));
                    }
                }
                fm.forsearch.Clear();
                for (int i = 0; i < fm.search1.Count; i++)
                {
                    s.Add(Convert.ToInt32(fm.search1[i].id));
                }
                
                bool trigger = false;
                if (s.Count != 0)
                {
                    for (int i = 1; i <= countr; i++)
                    {
                        for (int j = 0; j < s.Count; j++)
                        {
                            if (s[j] == i)
                            { trigger = true; }

                        }
                        if (trigger != true)
                        {
                            r.cbn_sts.Items.Add(i);
                            trigger = false;
                        }
                        else trigger = false;

                    }
                    
                }
                s.Clear();

            }
            else if((r.tbfrm.Text != fm.list1[id].str_tw) && (r.tbto.Text != fm.list1[id].end_tw))
            {
                r.forcase = 2;
                SearchTown(r.tbto.Text);
                int end = fm.search1[0].id;
                fm.search1.Clear();
                List<int> s = new List<int>();
                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F,s.ID_R,s.id_t,s.Number_S,s.QUANTITY_F from free_s s ,rout r,datefors ds where s.ID_R=r.id_R and r.ID_R='" + fm.list1[id].id + "' and s.id_t='"+end+ "' and ds.id_d='" + fm.iddate + "' and s.id_D=ds.id_d", ref fm.forsearch);
                for (int i = 0; i < fm.forsearch[0].frees.Length; i++)
                {
                    if (fm.forsearch[0].frees[i] != "")
                    {
                        s.Add(Convert.ToInt32(fm.forsearch[0].frees[i]));

                    }
                }
                bool trigger = false;
                if (s.Count != 0)
                {
                    for (int i = 1; i <= countr; i++)
                    {
                        for (int j = 0; j < s.Count; j++)
                        {
                            if (s[j] == i)
                            { trigger = true; }

                        }
                        if (trigger != true)
                        {
                            r.cbn_sts.Items.Add(i);
                            trigger = false;
                        }
                        else trigger = false;

                    }
                }
                s.Clear();
                fm.forsearch.Clear();
            }
            else if((r.tbfrm.Text != fm.list1[id].str_tw) && (r.tbto.Text == fm.list1[id].end_tw))
            {
                r.forcase = 3;
                SearchTown(r.tbto.Text);
                int end = fm.search1[0].id;
                fm.search1.Clear();
                List<int> s = new List<int>();
                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F,s.ID_R,s.id_t,s.Number_S,s.QUANTITY_F from free_s s ,rout r,datefors ds where s.ID_R=r.id_R and r.ID_R='" + fm.list1[id].id + "' and s.id_t='" + end + "' and ds.id_d='" + fm.iddate + "' and s.id_D=ds.id_d", ref fm.forsearch);
                for (int i = 0; i < fm.forsearch[0].frees.Length; i++)
                {
                    if (fm.forsearch[0].frees[i] != "")
                    {
                        s.Add(Convert.ToInt32(fm.forsearch[0].frees[i]));

                    }
                }
                bool trigger = false;
                if (s.Count != 0)
                {
                    for (int i = 1; i <= countr; i++)
                    {
                        for (int j = 0; j < s.Count; j++)
                        {
                            if (s[j] == i)
                            { trigger = true; }

                        }
                        if (trigger != true)
                        {
                            r.cbn_sts.Items.Add(i);
                            trigger = false;
                        }
                        else trigger = false;

                    }
                }
                s.Clear();
                fm.forsearch.Clear();
            }
        }
        public int NumberofTicket()
        {
            Random r=new Random();
            int idd = 0;
            fm.search1.Clear();
            do
            {
                 idd = r.Next(10000, 99999);
                db.Execute<Shearch>(ref sp, "select t.ID_T from ticket t where t.NS_T='" + idd + "'", ref fm.search1);

            } while (fm.search1.Count != 0);
            return idd;
        }
        public void SearchTown(string s)
        {
            fm.search1.Clear();
            db.Execute<Shearch>(ref sp, "Select t.id_t from town t where t.name_t='" + s + "'",ref fm.search1);
        }
        public void InsertTicket()
        {
            SearchTown(r.tbfrm.Text);
            int start = fm.search1[0].id;
            SearchTown(r.tbto.Text);
            int end = fm.search1[0].id;
            string [] val = r.tbprice.Text.Split(',');
            string doub = "";
            if (val.Length!=1)
            {
                doub = val[0] + "." + val[1];
            }
            else doub = val[0];
            int id_ticket = 0;
            fm.search1.Clear();
            db.Execute<Shearch>(ref sp, "select t.id_t from ticket t group by t.id_t", ref fm.search1);
            if (fm.search1.Count != 0)
            {
                id_ticket = fm.search1[fm.search1.Count - 1].id + 1;
            }
            else id_ticket = 1;
            fm.search1.Clear();
            if (r.cbn_sts.Text != "")
            {
                string part1 = "'" + id_ticket + "', '" + r.tbn.Text + "', '" + start + "', '" + end + "', '";
                string part2 = DateTime.Parse(r.tbwhn.Text).ToString("yyyy.MM.dd HH:mm:ss") + "', '" + r.cbn_sts.Text + "', '" + fm.list1[id].id + "', '" + doub + "', '" + DateTime.Parse(r.tbdatefrom.Text).ToString("yyyy.MM.dd HH:mm:ss") + "')";
                string command = part1 + part2;
               int n=db.ExecuteNonQuery(ref sp, "insert into ticket values(" + command, 0);
                if(n==1)
                {
                    int str = 0;
                    int endd = 0;
                    fm.forsearch.Clear();
                    db.Execute<FreeSites>(ref sp, "SELECT s.ID_F, s.ID_R, s.id_t, s.Number_S, s.QUANTITY_F from free_s s , rout r,datefors ds where s.ID_R = r.id_R and r.ID_R = '" + fm.list1[id].id + "' and s.id_d=ds.id_d and ds.id_d='" + fm.iddate + "' ", ref fm.forsearch);
                    for (int i = 0; i < fm.forsearch.Count; i++)
                    {
                        if(start==fm.forsearch[i].id_town)
                        {
                            str = i;
                        }
                        if (end == fm.forsearch[i].id_town)
                        {
                            endd = i;
                        }
                    }
                    int n1=0;
                    string s = "";
                    switch (r.forcase)
                    {
                        case 0:
                            s = r.cbn_sts.Text;
                            n1 = db.ExecuteNonQuery(ref sp, "update free_s f set f.number_s=insert(f.number_s,length(f.number_s)+1,length('" + s + "!'),'" + s + "!'),f.quantity_f=quantity_f-1  where f.ID_F between'" + fm.forsearch[str].id_fs + "' and '" + fm.forsearch[endd].id_fs + "'", 0);
                            break;
                        case 1:
                            s = r.cbn_sts.Text;
                            n1 = db.ExecuteNonQuery(ref sp, "update free_s f set f.number_s=insert(f.number_s,length(f.number_s)+1,length('" + s + "!'),'" + s + "!'),f.quantity_f=quantity_f-1  where f.ID_F between'" + fm.forsearch[str].id_fs + "' and '" + fm.forsearch[endd].id_fs + "'", 0);
                            break;
                        case 2:
                            s = r.cbn_sts.Text;
                            n1= db.ExecuteNonQuery(ref sp, "update free_s f set f.number_s=insert(f.number_s,length(f.number_s)+1,length('" + s + "!'),'" + s + "!'),f.quantity_f=quantity_f-1  where f.ID_F between'" + fm.forsearch[str].id_fs + "' and '" + fm.forsearch[endd].id_fs + "'", 0);
                            s = "";
                            if (n1 > 0)
                            {
                                for (int i = 0; i < fm.forsearch[str].frees.Length; i++)
                                {
                                    s += fm.forsearch[str].frees[i] + "!";
                                }
                                n1 = db.ExecuteNonQuery(ref sp, " update  free_s f set  f.number_s = '" + s + "' where  f.id_f = '" + fm.forsearch[str].id_fs + "'", 0);
                            }
                            else n1 = 0;
                        
                            break;
                        case 3:
                            s = r.cbn_sts.Text;
                            n1 = db.ExecuteNonQuery(ref sp, "update free_s f set f.number_s=insert(f.number_s,length(f.number_s)+1,length('" + s + "!'),'" + s + "!'),f.quantity_f=quantity_f-1  where f.ID_F between'" + fm.forsearch[str].id_fs + "' and '" + fm.forsearch[endd].id_fs + "'", 0);
                            s = "";
                            if (n1 > 1)
                            {
                                for (int i = 0; i < fm.forsearch[str].frees.Length; i++)
                                {
                                    s += fm.forsearch[str].frees[i] + "!";
                                }
                                n1 = db.ExecuteNonQuery(ref sp, " update  free_s f set  f.number_s = '" + s + "' where  f.id_f = '" + fm.forsearch[str].id_fs + "'", 0);
                            }
                            else n1 = 0;

                            break;
                    }
                    if((n==1)&&(n1>0))
                    {

                        r.inf.ticket.Add(new TicketForReport(r.tbn.Text, r.tbwhn.Text, r.tbrout.Text, r.tbfrm.Text, r.tbto.Text, r.tbdatefrom.Text, r.tbdtt.Text, r.cbn_sts.Text, r.tbnp.Text, r.tbprice.Text));
                        MessageBox.Show("Билет успешно добавлен");
                        fm.forsearch.Clear();
                        fm.search1.Clear();
                        r.cbn_sts.Text = "";
                        r.tbn.Text = Convert.ToInt32(NumberofTicket()).ToString();
                        r.tbwhn.Text = DateTime.Now.ToString();
                        r.cbn_sts.Items.Clear();
                        LoadSites();
                       


                    }
                    else
                    {
                        MessageBox.Show("Что-то не так");
                    }

                }
                else MessageBox.Show("Что-то не так");
            }
            else
            {
                MessageBox.Show("Выберете место!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
