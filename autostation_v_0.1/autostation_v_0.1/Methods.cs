using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autostation_v_0._1
{
    public class Methods
    {
        fm r;
        fmt t;
        
       public Methods(fm t)
        { r = t;
          
        }
       
     
       
        ClassSetupProgram sp = new ClassSetupProgram();
        ClassDataBase db = new ClassDataBase();
        List<towns> town = new List<towns>();
        List<DistanceBT> distancer = new List<DistanceBT>();
        public void LoadData()
        {

            ClassDataBase db = new ClassDataBase();
            string a = "select id_r, t.name_t,(select t1.name_t from town t1,rout r1, price pr1 where r1.id_end=t1.id_t and pr1.ID_PR=r1.ID_PR and r1.ID_R=r.ID_R ) as end_r,";
            string b = "r.DAY_R, strdate_r,enddate_r,DISTANCE_R*pr.PRICE, pr.Price, DISTANCE_R from rout r, town t, price pr where r.id_st = t.id_t and pr.ID_PR=r.ID_PR";
            string d = a + b;
            db.Execute<timetable>(ref sp, d, ref r.list1);
        }
        public void ShowDate()
        {

            r.dgvm.Rows.Clear();
            r.list1.Sort(delegate(timetable us1, timetable us2) { return us1.id.CompareTo(us2.id); });
            for (int i = 0; i < r.list1.Count; i++)
            {

               r.dgvm.Rows.Add(r.list1[i].id, r.list1[i].str_tw, r.list1[i].end_tw,r.list1[i].day, r.list1[i].date_str, r.list1[i].date_end,
                    r.list1[i].price);
                if(r.list1[i].day.IndexOf(r.was.ToString("ddd"))!=-1)
                {
                   r.dgvm.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
              
            }
            r.dgvm.Columns[0].Visible = false;
        }
        public void LoadDataCB()
        {
            ClassDataBase db = new ClassDataBase();
            db.Execute<towns>(ref sp, "Select id_t,name_t from town", ref r.ttowns);
        }
        public void ShowDataCB()
        {
            for (int i = 0; i < r.ttowns.Count; i++)
            {
                r.cbt.Items.Add(r.ttowns[i].name_t);
                r.cbxf.Items.Add(r.ttowns[i].name_t);
            }       
           

        }
        //public void InfaTickat(int counter)
        //{


        //    t.tbfrm.Text = r.list1[counter - 1].str_tw;
        //    t.tbto.Text = r.list1[counter - 1].end_tw;
        //    t.tbdtt.Text = r.list1[counter - 1].date_end;
        //    t.u = counter;
        //   t.id = r.list1[counter - 1].id.ToString();


        //    t.Show();
        //}
        #region
        public void Search(string a, string b)
        {
            
            string command1 = "SELECT r.id_r from rout r,town t, btown bt where (r.ID_ST=t.ID_T or (bt.ID_T=t.ID_T and bt.ID_R=r.ID_R))and instr(r.DAY_R,'"+r.dtpm.Value.ToString("ddd")+"')!=0 and t.NAME_T like'" + a+"'and r.ID_R=(select r2.id_r from rout r2, btown bt2, town t2 where";
            string command2 = "(r2.ID_END=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R and bt2.ID_BT>=bt.ID_BT)) and t2.NAME_T like '" + b+"'  and r2.ID_R=r.ID_R   group by r2.ID_R) group by r.ID_R";
            string command = command1 + command2;
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();
        }
        public void Search(string a,int forfunction)
        {
            
            string command = "select r2.id_r from rout r2, btown bt2, town t2 where  (r2.ID_END=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R)) and t2.NAME_T like '"+a+"'    group by r2.ID_R";
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();

        }
        public void SearchFromTo(string a,string b)
        {
            string command1 = "SELECT r.id_r from rout r,town t, btown bt where (r.ID_ST=t.ID_T or (bt.ID_T=t.ID_T and bt.ID_R=r.ID_R))and t.NAME_T like'" + a + "'and r.ID_R=(select r2.id_r from rout r2, btown bt2, town t2 where";
            string command2 = "(r2.ID_END=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R and bt2.ID_BT>=bt.ID_BT)) and t2.NAME_T like '" + b + "'  and r2.ID_R=r.ID_R   group by r2.ID_R) group by r.ID_R";
            string command = command1 + command2;
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();
        }
        public void SearchDate(string a)
        {
           
            string command = "select r2.id_r from rout r2, btown bt2, town t2 where  (r2.ID_END=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R)) and t2.NAME_T like '"+a+ "' and instr(r2.DAY_R,'" + r.dtpm.Value.ToString("ddd") + "')!=0    group by r2.ID_R";
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();
        }
        public void SearchFrom(string a)
        {
            string command = "select r2.id_r from rout r2, btown bt2, town t2 where  (r2.ID_ST=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R)) and t2.NAME_T like '" + a + "'    group by r2.ID_R";
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();
        }
        public void SearchFrom(string a,string data)
        {
            string command = "select r2.id_r from rout r2, btown bt2, town t2 where  (r2.ID_ST=t2.ID_T or (bt2.ID_T=t2.ID_T and bt2.ID_R=r2.ID_R)) and t2.NAME_T like '" + a + "' and instr(r2.DAY_R,'" + r.dtpm.Value.ToString("ddd") + "')!=0   group by r2.ID_R";
            ClassDataBase db = new ClassDataBase();
            db.Execute<Shearch>(ref sp, command, ref r.search1);
            SortDataGrid();
            r.Answear();
            r.search1.Clear();
        }
        #endregion
        public string Insertdata(string a)
        {
            string c="";
            string[] val = a.Split('.');
            c = val[2] + "." + val[1] + "." + val[0];
            return c;
        }
        public void SortDataGrid()
        {
            double numberof = 0;
            r.dgvm.Rows.Clear();

            if (r.search1 != null)
            {
                for (int i = 0; i < r.search1.Count; i++)
                {

                    numberof = r.search1[i].id;
                    for (int j = 0; j < r.list1.Count; j++)
                    {
                        if (numberof == r.list1[j].id)
                        {
                            if ((r.cbf.Checked == true) && (r.cb2.Checked == true))
                            {
                                if ((r.cbxf.Text == r.list1[j].str_tw) && (r.cbt.Text == r.list1[j].end_tw))
                                {
                                    r.dgvm.Rows.Add(r.list1[j].id, r.list1[j].str_tw, r.list1[j].end_tw, r.list1[j].day, r.list1[j].date_str, r.list1[j].date_end,
                                    r.list1[j].price);
                                }
                                else if ((r.cbxf.Text == r.list1[j].str_tw) && (r.cbt.Text != r.list1[j].end_tw))
                                {
                                    //db.Execute<towns>(ref sp, "Select bt.id_bt,name_t from town, btown bt rout r where r.id_r=bt.id_r and bt.id_t=t.id_t and t.name_t='"+r.cbt.Text+"'", ref town);
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='"+r.list1[j].id+"' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                    double hours = distancer[0].distance / distancer[0].speed;
                                    DateTime date = new DateTime();
                                    date = DateTime.Parse(r.list1[j].date_str);
                                    distancer.Clear();
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, p.price  from btown bt, price p, rout r,town t where bt.ID_R=r.ID_R and r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                    double price = distancer[0].distance * distancer[0].speed;
                                    r.dgvm.Rows.Add(r.list1[j].id, r.list1[j].str_tw, r.cbt.Text, r.list1[j].day, r.list1[j].date_str, date.AddHours(hours).ToShortTimeString(),
                                    price);
                                    distancer.Clear();
                                }
                                else if ((r.cbxf.Text != r.list1[j].str_tw) && (r.cbt.Text != r.list1[j].end_tw))
                                {
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbxf.Text + "'", ref distancer);
                                    double dst = distancer[0].distance;
                                    double hours = distancer[0].distance / distancer[0].speed;


                                    DateTime date = DateTime.Now;
                                    date = date.ToLocalTime();
                                    int day = 1;
                                    while (r.list1[i].day.IndexOf(date.ToString("ddd")) == -1)
                                    {
                                        date = date.AddDays(day);
                                        day++;
                                    }
                                    date = DateTime.Parse(date.ToShortDateString() + " " + r.list1[j].
                                        date_str);
                                    date = date.AddHours(hours);
                                    distancer.Clear();
                                    if (r.cbd.Checked == true)
                                    {
                                        if (r.list1[j].day.IndexOf(r.dtpm.Value.ToString("ddd")) != -1)
                                        {

                                            db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                            hours = (distancer[0].distance - dst) / distancer[0].speed;
                                            distancer.Clear();
                                            db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, p.price  from btown bt, price p, rout r,town t where bt.ID_R=r.ID_R and r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);

                                            double price = (distancer[0].distance - dst) * distancer[0].speed;
                                            r.dgvm.Rows.Add(r.list1[j].id, r.cbxf.Text, r.cbt.Text, r.list1[j].day, date.ToLongTimeString(), date.AddHours(hours).ToShortTimeString(),
                                       price);
                                            distancer.Clear();
                                        }
                                    }
                                    else
                                    {
                                        db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='"+r.list1[j].id+"' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                        hours = (distancer[0].distance - dst) / distancer[0].speed;
                                        distancer.Clear();
                                        db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, p.price  from btown bt, price p, rout r,town t where bt.ID_R=r.ID_R and r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);

                                        double price = (distancer[0].distance - dst) * distancer[0].speed;
                                        r.dgvm.Rows.Add(r.list1[j].id, r.cbxf.Text, r.cbt.Text, r.list1[j].day, date.ToLongTimeString(), date.AddHours(hours).ToShortTimeString(),
                                   price);
                                        distancer.Clear();
                                    }

                                }
                                else if ((r.cbxf.Text != r.list1[j].str_tw) && (r.cbt.Text == r.list1[j].end_tw))
                                {
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='"+r.list1[j].id+"' and bt.id_t=t.id_t and t.Name_t='" + r.cbxf.Text + "'", ref distancer);
                                    double hours = distancer[0].distance / distancer[0].speed;
                                    DateTime date = new DateTime();
                                    date = DateTime.Parse(r.list1[j].date_str);
                                    distancer.Clear();
                                    if (r.list1[j].day.IndexOf(date.ToString("ddd")) != -1)
                                    {
                                        db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, p.price  from btown bt, price p, rout r,town t where bt.ID_R=r.ID_R and r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbxf.Text + "'", ref distancer);
                                        double price = distancer[0].distance * distancer[0].speed;
                                        r.dgvm.Rows.Add(r.list1[j].id, r.cbxf.Text, r.list1[j].end_tw, r.list1[j].day, date.AddHours(hours).ToLongTimeString(), r.list1[j].date_end,
                                 r.list1[j].price - price);
                                        distancer.Clear();
                                    }
                                }
                            }
                            else if ((r.cbf.Checked == true) && (r.cb2.Checked == false))
                            {
                                if (r.cbxf.Text == r.list1[j].str_tw)
                                {
                                    r.dgvm.Rows.Add(r.list1[j].id, r.list1[j].str_tw, r.list1[j].end_tw, r.list1[j].day, r.list1[j].date_str, r.list1[j].date_end,
                                    r.list1[j].price);
                                }

                                else if (r.cbxf.Text != r.list1[j].str_tw)
                                {
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbxf.Text + "'", ref distancer);
                                    double dst = distancer[0].distance;
                                    double hours = distancer[0].distance / distancer[0].speed;
                                    DateTime date = new DateTime();
                                    date = DateTime.Parse(r.list1[j].date_str);
                                    date = date.AddHours(hours);
                                    distancer.Clear();
                                    if (r.cbd.Checked == true)
                                    {
                                        if (r.list1[i].day.IndexOf(date.ToString("ddd")) == -1)
                                        {
                                            db.Execute<DistanceBT>(ref sp, "SELECT r.DISTANCE_R, p.price  from  price p, rout r where  r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "'", ref distancer);
                                            double price = (distancer[0].distance - dst) * distancer[0].speed;
                                            r.dgvm.Rows.Add(r.list1[j].id, r.cbxf.Text, r.list1[j].end_tw, r.list1[j].day, date.ToLongTimeString(), r.list1[j].date_end,
                                       price);
                                            distancer.Clear();
                                        }
                                    }
                                    else
                                    {
                                        db.Execute<DistanceBT>(ref sp, "SELECT r.DISTANCE_R, p.price  from  price p, rout r where  r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "'", ref distancer);
                                        double price = (distancer[0].distance - dst) * distancer[0].speed;
                                        r.dgvm.Rows.Add(r.list1[j].id, r.cbxf.Text, r.list1[j].end_tw, r.list1[j].day, date.ToLongTimeString(), r.list1[j].date_end,
                                   price);
                                        distancer.Clear();
                                    }

                                }

                            }
                            else if ((r.cb2.Checked == true) && (r.cbf.Checked == false))
                            {
                                if (r.cbt.Text == r.list1[j].end_tw)
                                {
                                    r.dgvm.Rows.Add(r.list1[j].id, r.list1[j].str_tw, r.list1[j].end_tw, r.list1[j].day, r.list1[j].date_str, r.list1[j].date_end,
                                    r.list1[j].price);
                                }

                                else if (r.cbt.Text != r.list1[j].end_tw)
                                {
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, l.speed from btown bt, look l, rout r,town t, bus b, connectionr_d cd where bt.ID_R=r.ID_R and cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                    double hours = distancer[0].distance / distancer[0].speed;
                                    DateTime date = new DateTime();
                                    date = DateTime.Parse(r.list1[j].date_str);
                                    distancer.Clear();
                                    db.Execute<DistanceBT>(ref sp, "SELECT bt.DISTANCE_BT, p.price  from btown bt, price p, rout r,town t where bt.ID_R=r.ID_R and r.id_pr=p.id_pr and  r.ID_R='" + r.list1[j].id + "' and bt.id_t=t.id_t and t.Name_t='" + r.cbt.Text + "'", ref distancer);
                                    double price = distancer[0].distance * distancer[0].speed;
                                    r.dgvm.Rows.Add(r.list1[j].id, r.list1[j].str_tw, r.cbt.Text, r.list1[j].day, r.list1[j].date_str, date.AddHours(hours).ToShortTimeString(),
                                    price);
                                    distancer.Clear();

                                }
                            }

                        }
                    }


                }
            }

        }
        public int SearchDate(DateTime rt, int idr)
        {
            int idd = 0;
            r.search1.Clear();
            db.Execute<Shearch>(ref sp, "select d.id_d from datefors d where d.dateleave='" + rt.ToString("yyyy.MM.dd") + "' and d.id_r='"+r.list1[idr].id+"'", ref r.search1);
            if(r.search1.Count==0)
            { db.Execute<Shearch>(ref sp, "select d.id_d from datefors d order by d.id_D", ref r.search1);
                
                if (r.search1.Count != 0)
                {
                    idd = r.search1[r.search1.Count - 1].id+1;
                }
                else idd = 1;
                int n = db.ExecuteNonQuery(ref sp, "insert into datefors values('" + idd + "', '"+rt.ToString("yyyy.MM.dd")+"', '"+r.list1[idr].id+"')",0);
                if (n == 1)
                {
                    db.Execute<Shearch>(ref sp, "select fs.id_f from free_s fs order by fs.id_f", ref r.search1);
                    int idf = 0;
                    if (r.search1.Count != 0)
                    {
                        idf = r.search1[r.search1.Count-1].id+1;
                    }
                    else idf = 1;
                    r.search1.Clear();
                    int bus = 0;
                    db.Execute<Shearch>(ref sp, "select l.QUANTITY_L from connectionr_d cd, bus b, look l, rout r where cd.ID_B=b.ID_B and b.ID_L=l.ID_L and cd.id_r=r.ID_R and r.id_R='" + r.list1[idr].id + "'", ref r.search1);
                    bus = r.search1[0].id;
                    r.search1.Clear();
                    db.Execute<Shearch>(ref sp, "select b.id_bt from btown b, rout r where b.id_r=r.id_r and r.id_r='" + r.list1[idr].id + "'", ref r.search1);
                   
                    if (r.search1.Count == 0)
                    {
                        SearchTown(r.list1[idr].str_tw);
                        db.ExecuteNonQuery(ref sp, "insert into free_s values('"+idf+"', '"+r.list1[idr].id+"', '"+r.search1[0].id+"', '"+idd+"', '"+bus+"', "+"'0!')" , 0);
                        SearchTown(r.list1[idr].end_tw);
                        idf++;
                        db.ExecuteNonQuery(ref sp, "insert into free_s values('" + idf + "', '" + r.list1[idr].id + "', '" + r.search1[0].id + "', '" + idd + "', '" + bus + "', " + "'0!')", 0);
                    }
                    else
                    {
                        SearchTown(r.list1[idr].str_tw);
                        db.ExecuteNonQuery(ref sp, "insert into free_s values('" + idf + "', '" + r.list1[idr].id + "', '" + r.search1[0].id + "', '" + idd + "', '" + bus + "', " + "'0!')", 0);
                        r.search1.Clear();
                        db.Execute<Shearch>(ref sp, "select bt.id_t from btown bt,rout r where bt.id_r=r.id_R and r.id_R='" + r.list1[idr].id+"'", ref r.search1);
                        for (int i = 0; i < r.search1.Count; i++)
                        {
                            idf++;
                            db.ExecuteNonQuery(ref sp, "insert into free_s values('" + idf + "', '" + r.list1[idr].id + "', '" + r.search1[i].id + "', '" + idd + "', '" + bus + "', " + "'0!')", 0);

                        }
                        SearchTown(r.list1[idr].end_tw);
                        idf++;
                        db.ExecuteNonQuery(ref sp, "insert into free_s values('" + idf + "', '" + r.list1[idr].id + "', '" + r.search1[0].id + "', '" + idd + "', '" + bus + "', " + "'0!')", 0);
                        r.search1.Clear();

                    }
                }
            }
            else
            {
                idd = r.search1[r.search1.Count - 1].id;
            }
            return idd;
        }
        public void SearchTown(string s)
        {
            r.search1.Clear();
            db.Execute<Shearch>(ref sp, "Select t.id_t from town t where t.name_t='" + s + "'", ref r.search1);
        }

    }
}
