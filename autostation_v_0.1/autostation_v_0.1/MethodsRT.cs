using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autostation_v_0._1
{
    public class MethodsRT
    {
        ClassDataBase db = new ClassDataBase();
        ClassSetupProgram sp = new ClassSetupProgram();
        rt r = new rt();
        public MethodsRT(rt t)
        {
            r = t;
        }
        public void Search()
        {
            r.tick.Clear();
            db.Execute<ticket>(ref sp, "SELECT t.TicketNumber,t.Date_Purchase, t.NS_T,t.price,t.dataleave,r.id_r,t.id_t from ticket t,rout r where t.TicketNumber='" + r.tBS.Text+"' and r.id_r=t.id_r", ref r.tick);
            if (r.tick.Count != 0)
            {
                DateTime now = DateTime.Now;
                now.ToLocalTime();
                r.dgrt.Rows.Clear();
                r.dgrt.Rows.Add(r.tick[0].id, r.tick[0].pur_time, r.tick[0].num_sttng, r.tick[0].price);
                if(DateTime.Parse(r.tick[0].dateleave)<now)
                {
                    MessageBox.Show("Ворзврат билета не возможен");
                    r.btnrt.Enabled = false;
                }
                else
                {
                    
                    if(DateTime.Parse(r.tick[0].dateleave).Day - now.Day >= 1)
                    {
                        r.tbrt.Text = (r.tick[0].price / 100 * 80).ToString();
                        r.btnrt.Enabled = true;
                    }
                    else if(DateTime.Parse(r.tick[0].dateleave).Day- now.Day < 1)
                    {
                        
                        if(DateTime.Parse(r.tick[0].dateleave).Hour-now.Hour>=2)
                        {
                            r.tbrt.Text = (r.tick[0].price / 100 * 50).ToString();
                            r.btnrt.Enabled = true;
                        }
                        else if((DateTime.Parse(r.tick[0].dateleave).Hour - now.Hour < 2)&&(DateTime.Parse(r.tick[0].dateleave).Minute - now.Minute >= 20))
                        {
                            r.tbrt.Text = (r.tick[0].price / 100 * 50).ToString();
                            r.btnrt.Enabled = true;
                        }
                        else if(DateTime.Parse(r.tick[0].dateleave).Minute - now.Minute < 20)
                        {
                            MessageBox.Show("Билет вернуть невозможно");
                            r.btnrt.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                r.dgrt.Rows.Clear();
                MessageBox.Show("Нет билета с таким номером");
            }
            
        }
        public void deletesites()
        {
            int n=0, n1 = 0;
            db.Execute<towns>(ref sp, "select t.id_st,tw.name_t from ticket t,town tw where t.id_st=tw.id_t and t.id_t='" + r.tick[0].id_t + "'",ref r.town);
            int start = r.town[0].id;
            string startt = r.town[0].name_t;
            r.town.Clear();
            db.Execute<towns>(ref sp, "select t.id_end,tw.name_t from ticket t,town tw where t.id_end=tw.id_t and t.id_t='" + r.tick[0].id_t + "'", ref r.town);
            int end = r.town[0].id;
            string endt = r.town[0].name_t;
            r.town.Clear();
            db.Execute<towns>(ref sp, "select r.ID_ST,tw.name_t from rout r,town tw where r.id_st=tw.id_t and r.id_r='" + r.tick[0].id_r + "'", ref r.town);
            int startr = r.town[0].id;
            string starttr=r.town[0].name_t;
            r.town.Clear();
            db.Execute<towns>(ref sp, "select r.ID_END,tw.name_t from rout r,town tw where r.id_end=tw.id_t and r.id_r='" + r.tick[0].id_r + "'", ref r.town);
            int endr = r.town[0].id;
            string endtr = r.town[0].name_t;
            r.town.Clear();
            if((startt==starttr)&&(endt==endtr))
            {
                r.forsearch.Clear();

                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F, s.ID_R, s.id_t, s.Number_S, s.QUANTITY_F from free_s s , rout r where s.ID_R = r.id_R and r.ID_R = '" + r.tick[0].id_r + "' ",ref r.forsearch);
                for (int j = 0; j < r.forsearch.Count; j++)
                {

                    string s = "";
                    for (int i = 0; i < r.forsearch[j].frees.Length; i++)
                    {
                        if(Convert.ToInt32(r.forsearch[j].frees[i])!=r.tick[0].num_sttng)
                        {
                            s += r.forsearch[j].frees[i] + '!';
                        }
                      n = db.ExecuteNonQuery(ref sp, " update  free_s f, rout r set  f.number_s = '" + s + "' where  f.id_f = '" + r.forsearch[j].id_fs + "' and r.id_r='" + r.tick[0].id_r + "'", 0);

                    }
                }
            }
            if((startt == starttr)&& (endt != endtr))
                {
                r.forsearch.Clear();

                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F, s.ID_R, s.id_t, s.Number_S, s.QUANTITY_F from free_s s , rout r where s.ID_R = r.id_R and r.ID_R = '" + r.tick[0].id_r + "'and s.id_t between '"+startr+"' and '"+end+ "'", ref r.forsearch);
                for (int j = 0; j < r.forsearch.Count; j++)
                {

                    string s = "";
                    for (int i = 0; i < r.forsearch[j].frees.Length; i++)
                    {
                        
                        if (Convert.ToInt32(r.forsearch[j].frees[i]) != r.tick[0].num_sttng)
                        {
                            s += r.forsearch[j].frees[i] + '!';
                        }
                        n = db.ExecuteNonQuery(ref sp, " update  free_s f, rout r set  f.number_s = '" + s + "' where  f.id_f = '" + r.forsearch[j].id_fs + "' and r.id_r='" + r.tick[0].id_r + "'", 0);

                    }
                }

            }
            if((startt != starttr) && (endt != endtr))
            {
                r.forsearch.Clear();
                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F, s.ID_R, s.id_t, s.Number_S, s.QUANTITY_F from free_s s , rout r where s.ID_R = r.id_R and r.ID_R = '" + r.tick[0].id_r + "'and s.id_t between '" + start + "' and '" + end + "'", ref r.forsearch);
                for (int j = 0; j < r.forsearch.Count; j++)
                {

                    string s = "";
                    for (int i = 0; i < r.forsearch[j].frees.Length; i++)
                    {

                        if (Convert.ToInt32(r.forsearch[j].frees[i]) != r.tick[0].num_sttng)
                        {
                            s += r.forsearch[j].frees[i] + '!';
                        }
                        n = db.ExecuteNonQuery(ref sp, " update  free_s f, rout r set  f.number_s = '" + s + "' where  f.id_f = '" + r.forsearch[j].id_fs + "' and r.id_r='" + r.tick[0].id_r + "'", 0);

                    }
                }

            }
            if((startt != starttr) && (endt == endtr))
            {
                r.forsearch.Clear();
                db.Execute<FreeSites>(ref sp, "SELECT s.ID_F, s.ID_R, s.id_t, s.Number_S, s.QUANTITY_F from free_s s , rout r where s.ID_R = r.id_R and r.ID_R = '" + r.tick[0].id_r + "'and s.id_t between '" + start + "' and '" + endr + "'", ref r.forsearch);
                for (int j = 0; j < r.forsearch.Count; j++)
                {

                    string s = "";
                    for (int i = 0; i < r.forsearch[j].frees.Length; i++)
                    {

                        if (Convert.ToInt32(r.forsearch[j].frees[i]) != r.tick[0].num_sttng)
                        {
                            s += r.forsearch[j].frees[i] + '!';
                        }
                        n = db.ExecuteNonQuery(ref sp, " update  free_s f, rout r set  f.number_s = '" + s + "' where  f.id_f = '" + r.forsearch[j].id_fs + "' and r.id_r='" + r.tick[0].id_r + "'", 0);

                    }
                }
            }
            if(n>0)
            {
                n1 = db.ExecuteNonQuery(ref sp, "delete   from ticket  where ticket.ID_T='" + r.tick[0].id_t + "'", 0);
                if(n1>0)
                {
                    string left = (r.tick[0].price - Convert.ToDouble(r.tbrt.Text)).ToString();
                    string[] val = left.Split(',');
                    string doub = "";
                    if (val.Length != 1)
                    {
                        left = val[0] + "." + val[1];
                    }
                    else left = val[0];
                    n1 = db.ExecuteNonQuery(ref sp, "insert into return_t value('"+r.tick[0].id_r +"', '"+left+ "', '"+DateTime.Now.ToLocalTime().ToString("yyyy.MM.dd HH:mm:ss") + "')", 0);
                    if(n1>0)
                    {
                        MessageBox.Show("Билет возвращен!");
                        r.tick.Clear();
                        r.tBS.Text = "";
                        r.tbrt.Text = "";
                        r.dgrt.Rows.Clear();
                    }
                }


            }
        }
    }
}
