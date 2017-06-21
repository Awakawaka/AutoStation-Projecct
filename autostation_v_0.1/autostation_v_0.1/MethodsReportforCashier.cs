using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autostation_v_0._1
{
    class MethodsReportforCashier
    {
        ReportCashier r;
        fm f;
        ClassSetupProgram sp = new ClassSetupProgram();
        ClassDataBase db = new ClassDataBase();
        public MethodsReportforCashier(ReportCashier e,fm y)
        {
            r = e;
            f = y;
        }
        public List<int> returnricket = new List<int>();
        public void LoadData()
        {
            r.search.Clear();
            r.sale.Clear();
            ShowS();
            db.Execute<Sales>(ref sp, "select r.id_r, count(t.ID_T), sum(t.price) from rout r, ticket t where r.ID_R=t.ID_R and month(t.Date_Purchase)=month(now()) group by r.id_r", ref r.sale);
            for (int i = 0; i < r.sale.Count; i++)
            {
                db.Execute<ReturnTicket>(ref sp, "select  count(tr.id_r), sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + r.sale[i].id_r + "' and r.id_R=tr.id_r and month(tr.datereturn)=month(now())", ref r.rticket);
                if (r.rticket.Count != 0)
                {
                    r.dgvr.Rows.Add(r.sale[i].id_r, f.list1[r.sale[i].id_r - 1].str_tw, f.list1[r.sale[i].id_r - 1].end_tw, r.sale[i].quantity, r.sale[i].commonsum, r.rticket[0].quantity,Math.Round(r.rticket[0].sum,2));

                }
                else r.dgvr.Rows.Add(r.sale[i].id_r, f.list1[r.sale[i].id_r - 1].str_tw, f.list1[r.sale[i].id_r - 1].end_tw, r.sale[i].quantity, r.sale[i].commonsum,"0", "0");
                r.rticket.Clear();

            }
        }
        public void ShowSales()
        {
            //r.dgvr.Rows.Clear();
            //r.dgvr.Columns.Clear();
            //r.dgvr.ColumnCount = 5;
            //r.dgvr.ColumnHeadersVisible = true;
            //r.dgvr.Columns[0].Name = "№ маршрута";
            //r.dgvr.Columns[1].Name = "Откуда";
            //r.dgvr.Columns[2].Name = "Куда";
            //r.dgvr.Columns[3].Name = "Кол-во проданных билетов";
            //r.dgvr.Columns[4].Name = "Общая стоимость";
            //for (int i = 0; i < r.sale.Count; i++)
            //{
            //    r.dgvr.Rows.Add(r.sale[i].id_r, f.list1[r.sale[i].id_r - 1].str_tw, f.list1[r.sale[i].id_r - 1].end_tw, r.sale[i].quantity, r.sale[i].commonsum);
            //}
        }
        public void ShowS()
        {
            r.dgvr.Rows.Clear();
            r.dgvr.Columns.Clear();
            r.dgvr.ColumnCount = 7;
            r.dgvr.ColumnHeadersVisible = true;
            r.dgvr.Columns[0].Name = "№ маршрута";
            r.dgvr.Columns[1].Name = "Откуда";
            r.dgvr.Columns[2].Name = "Куда";
            r.dgvr.Columns[3].Name = "Кол-во проданных билетов";
            r.dgvr.Columns[4].Name = "Общая стоимость";
            r.dgvr.Columns[5].Name = "Кол-во возврщенных билетов на сумму";
            r.dgvr.Columns[6].Name = "На сумму";
        }
        public void ShowS(int o)
        {
            r.dgvr.Rows.Clear();
            r.dgvr.Columns.Clear();
            r.dgvr.ColumnCount = 5;
            r.dgvr.ColumnHeadersVisible = true;
            r.dgvr.Columns[0].Name = "№ маршрута";
            r.dgvr.Columns[1].Name = "Откуда";
            r.dgvr.Columns[2].Name = "Куда";
            r.dgvr.Columns[3].Name = "Кол-во проданных билетов";
            r.dgvr.Columns[4].Name = "Общая стоимость";
        }
        public void ShowCB()
        {
            r.cbroutsr.Items.Add("Все");
            for (int i = 0; i <f.list1.Count; i++)
            {
                r.cbroutsr.Items.Add(f.list1[i].str_tw + "-" + f.list1[i].end_tw);
            }
        }
        public void SortSales()
        {
            r.button1.Enabled = true;
            string[] points = r.cbroutsr.Text.Split('-');
            int n = 0;
            if ((r.rballc.Checked == true) && (r.cbroutsr.Text == "Все"))
            {
                LoadData();
                ShowSales();
            }
            else if ((r.rbtoday.Checked == true) && (r.cbroutsr.Text == "Все"))
            {
                r.sale.Clear();
                r.dgvr.Rows.Clear();
                r.rticket.Clear();
                ShowS();
                for (int i = 0; i < f.list1.Count; i++)
                {


                    db.Execute<Sales>(ref sp, "select t.id_r, count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='"+f.list1[i].id+"' and r.ID_R=t.ID_R and tw.ID_T=t.ID_ST  and date(t.Date_Purchase)=date(now()) group by t.ID_R", ref r.sale);
                    if (r.sale.Count != 0)
                    {
                        db.Execute<ReturnTicket>(ref sp, "select  count(tr.id_r), sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + r.sale[0].id_r + "' and r.id_R=tr.id_r and date(tr.datereturn)=date(now())", ref r.rticket);
                        if (r.rticket.Count !=0)
                        {
                            r.dgvr.Rows.Add(r.sale[0].id_r, f.list1[i].str_tw, f.list1[i].end_tw, r.sale[0].quantity, r.sale[0].commonsum, r.rticket[0].quantity, r.rticket[0].sum);
                            n = 1;
                        }
                        else
                        {
                            r.dgvr.Rows.Add(r.sale[0].id_r, f.list1[i].str_tw, f.list1[i].end_tw, r.sale[0].quantity, r.sale[0].commonsum, 0, 0);
                            n = 0;
                        }
                    }
                    else n = 0;
                    r.sale.Clear();
                    r.rticket.Clear();

                    
                }
                if(r.dgvr.Rows.Count==0)
                {
                    MessageBox.Show("Ничего не было найденно");
                    r.button1.Enabled = false;
                     
                }
                
            }
            else if (r.cbroutsr.Text != "Все")
            {
                for (int i = 0; i < f.list1.Count; i++)
                {
                    if ((points[0] == f.list1[i].str_tw) && (points[1] == f.list1[i].end_tw))
                    {
                        Searchtown(f.list1[i].str_tw);
                        double start = r.search[0].id;
                        Searchtown(f.list1[i].end_tw);
                        double end = r.search[0].id;
                        if (r.rballc.Checked == true)
                        {
                            r.salesBt.Clear();
                            r.dgvr.Rows.Clear();
                            r.rticket.Clear();
                            ShowS(0);
                            db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R ), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + f.list1[i].id + "' and r.ID_R=t.ID_R and tw.ID_T=t.ID_ST  and month(t.Date_Purchase)=month(now()) group by t.price", ref r.salesBt);
                            if (r.salesBt.Count != 0)
                            {
                                for (int j = 0; j < r.salesBt.Count; j++)
                                {


                                    r.dgvr.Rows.Add(f.list1[i].id, r.salesBt[j].to, r.salesBt[j].from, r.salesBt[j].quantity, r.salesBt[j].price);
                                }
                                n = 1;
                                db.Execute<ReturnTicket>(ref sp, "select  count(tr.id_r), sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + f.list1[i].id + "' and r.id_R=tr.id_r and month(tr.datereturn)=month(now())", ref r.rticket);
                                if (r.rticket.Count != 0)
                                {
                                    r.tbrtcq.Text = r.rticket[0].quantity.ToString();
                                    r.tbsum.Text = Math.Round(r.rticket[0].sum,2).ToString();
                                }
                                else
                                {
                                    r.tbrtcq.Text = "0";
                                    r.tbsum.Text = "0";
                                }
                                r.rticket.Clear();
                            }
                            else n = 0;
                            if(n==0)
                            {
                                MessageBox.Show("Упс..Ничего не было найденно");
                                r.tbrtcq.Text = "";
                                r.tbsum.Text = "";
                                r.button1.Enabled = false;
                            }
                        }
                        else
                        {
                            r.salesBt.Clear();
                            r.dgvr.Rows.Clear();
                            ShowS(0);
                            db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R ), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + f.list1[i].id + "' and r.ID_R=t.ID_R and tw.ID_T=t.ID_ST  and date(t.Date_Purchase)=date(now()) group by t.price", ref r.salesBt);
                            if (r.salesBt.Count != 0)
                            {
                                for (int j = 0; j < r.salesBt.Count; j++)
                                {


                                    r.dgvr.Rows.Add(f.list1[i].id, r.salesBt[j].to, r.salesBt[j].from, r.salesBt[j].quantity, r.salesBt[j].price);
                                }

                                n = 1;
                                db.Execute<ReturnTicket>(ref sp, "select  count(tr.id_r), sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + f.list1[i].id + "' and r.id_R=tr.id_r and date(tr.datereturn)=date(now())", ref r.rticket);

                                if (r.rticket.Count != 0)
                                {
                                    r.tbrtcq.Text = r.rticket[0].quantity.ToString();
                                    r.tbsum.Text = Math.Round(r.rticket[0].sum, 2).ToString();
                                }
                                else
                                {
                                    r.tbrtcq.Text = "0";
                                    r.tbsum.Text = "0";
                                }
                                r.rticket.Clear();
                            }
                            
                            if(r.dgvr.Rows.Count==0)
                            {
                                MessageBox.Show("Упс..Ничего не было найденно");
                                r.tbrtcq.Text = "";
                                r.tbsum.Text = "";
                                r.button1.Enabled = false;
                            }
                        }
                    }
                }
            }
                   
        }
        public void Searchtown(string s)
        {
            r.search.Clear();
            db.Execute<SearchDouble>(ref sp, "Select t.id_t from town t where t.name_t='" + s + "'", ref r.search);
        }
    }
}
