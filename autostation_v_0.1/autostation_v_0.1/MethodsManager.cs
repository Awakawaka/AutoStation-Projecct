using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;


namespace autostation_v_0._1
{
    public class MethodsManager
    {
        MainManeger fm;
        ClassDataBase db = new ClassDataBase();
        ClassSetupProgram sp = new ClassSetupProgram();
        public MethodsManager(MainManeger t)
        {
            fm = t;
        }
        public void LoadDate()
        {
            fm.timetabler.Clear();
            string a = "select id_r, t.name_t,(select t1.name_t from town t1,rout r1, price pr1 where r1.id_end=t1.id_t and pr1.ID_PR=r1.ID_PR and r1.ID_R=r.ID_R ) as end_r,";
            string b = "r.DAY_R, strdate_r,enddate_r,DISTANCE_R*pr.PRICE, pr.Price, DISTANCE_R from rout r, town t, price pr where r.id_st = t.id_t and pr.ID_PR=r.ID_PR";
            string d = a + b;
            db.Execute<timetable>(ref sp, d, ref fm.timetabler);
        }
        public void LoadDateCB()
        {
            db.Execute<towns>(ref sp, "Select id_t,name_t from town", ref fm.town);
        }
        public void CBTowns()
        {

            for (int i = 0; i < fm.town.Count; i++)
            {
                fm.cbto.Items.Add(fm.town[i].name_t);
                fm.cbfrm.Items.Add(fm.town[i].name_t);
            }
        }
        public void PricesK()
        {
            fm.search.Clear();
            fm.cbpk.Items.Clear();
            fm.cbchangeprice.Items.Clear();
            db.Execute<SearchDouble>(ref sp, "select p.price from price p", ref fm.searchd);
            for (int i = 0; i < fm.searchd.Count; i++)
            {
                fm.cbchangeprice.Items.Add(fm.searchd[i].id);
                fm.cbpk.Items.Add(fm.searchd[i].id);
            }
            fm.searchd.Clear();
        }
        public void ShowDate()
        {
            fm.dgvman.ColumnCount = 7;
            fm.dgvman.ColumnHeadersVisible = true;
            fm.dgvman.Columns[0].Name = "№";
            fm.dgvman.Columns[1].Name = "Откуда";
            fm.dgvman.Columns[2].Name = "Куда";
            fm.dgvman.Columns[3].Name = "День недели";
            fm.dgvman.Columns[4].Name = "Дата отправления";
            fm.dgvman.Columns[5].Name = "Дата прибытия";
            fm.dgvman.Columns[6].Name = "Цена";
            fm.dgvman.Columns[0].Visible = false;


            for (int i = 0; i < fm.timetabler.Count; i++)
            {
                fm.dgvman.Rows.Add(fm.timetabler[i].id, fm.timetabler[i].str_tw, fm.timetabler[i].end_tw, fm.timetabler[i].day, fm.timetabler[i].date_str, fm.timetabler[i].date_end, fm.timetabler[i].price);
            }



        }
        public void LoadBt()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
          
            cmb.HeaderText = "Промежуточный пункт";

          
            for (int i = 0; i < fm.town.Count; i++)
            {
                cmb.Items.Add(fm.town[i].name_t);
            }
            fm.dgvmnew.ColumnCount = 1;
            fm.dgvmnew.Columns[0].Name = "Растояние";
            fm.dgvmnew.Columns.Add(cmb);
        }
        public void LoadSales()
        {
            fm.search.Clear();
            db.Execute<Sales>(ref sp, "select r.id_r, count(t.ID_T), sum(t.price) from rout r, ticket t where r.ID_R=t.ID_R and month(t.Date_Purchase)=month(now()) group by r.id_r", ref fm.sale);
            for (int i = 0; i < fm.sale.Count; i++)
            {
                db.Execute<Shearch>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and tr.id_R=r.id_R", ref fm.search);
                if (fm.search.Count != 0)
                {
                    fm.sale[i].commonsum += fm.search[fm.search.Count - 1].id;
                }
                fm.search.Clear();
            }
            db.Execute<Shearch>(ref sp, "select DAYOFMONTH(DATE_SUB(DATE_ADD(CONCAT(YEAR(t.Date_Purchase),'-',MONTH(t.Date_Purchase),'-01'),INTERVAL 1 MONTH),INTERVAL 1 DAY)) as end FROM ticket t  WHERE month(t.Date_Purchase) = month(now()) group by end ", ref fm.search);
            string s = fm.dtpallroutsfrom.Value.ToShortDateString();
            string[] val = s.Split('.');
            val[0] = "1";
            s = val[0] + "." + val[1] + "." + val[2];
            fm.dtpallroutsfrom.Value = DateTime.Parse(s);
            fm.from = DateTime.Parse(s);
            s = fm.dtpallroutsfrom.Value.ToShortDateString();
            val = s.Split('.');
            val[0] = fm.search[fm.search.Count - 1].id.ToString();
            fm.search.Clear();
            s = val[0] + "." + val[1] + "." + val[2];
            fm.dtpallroutsto.Value = DateTime.Parse(s);
            fm.to = DateTime.Parse(s);
            fm.triggerall = true;


        }
        public void LoadSales(int a)
        {
            if (fm.tballroutspart.Checked == true)
            {
                if ((fm.cballroutsfrom.Checked == true) && (fm.cballroutsto.Checked == true))
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select count(t.ID_T) from ticket t  where   t.Date_Purchase between '" + fm.dtpallroutsfrom.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpallroutsto.Value.ToString("yyyy.MM.dd") + "' ", ref fm.search);
                    if (fm.search.Count != 0)
                    {
                        fm.from = fm.dtpallroutsfrom.Value;
                        fm.to = fm.dtpallroutsto.Value;
                        fm.search.Clear();
                        fm.sale.Clear();
                        fm.triggerall = true;
                        db.Execute<Sales>(ref sp, "select r.id_r, count(t.ID_T), sum(t.price) from rout r, ticket t where r.ID_R=t.ID_R and t.Date_Purchase between '" + fm.dtpallroutsfrom.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpallroutsto.Value.ToString("yyyy.MM.dd") + "' group by r.id_R ", ref fm.sale);
                        if ((fm.cbbigger.Checked == false) && (fm.cbless.Checked == false))
                        {
                            fm.dgvman.Rows.Clear();
                            for (int i = 0; i < fm.sale.Count; i++)
                            {
                                fm.searchd.Clear();
                                db.Execute<SearchDouble>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and tr.id_R=r.id_R", ref fm.searchd);
                                if (fm.searchd.Count != 0)
                                {
                                    fm.sale[i].commonsum += fm.searchd[fm.searchd.Count - 1].id;
                                }

                                fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, Math.Round(fm.sale[i].commonsum,2));
                                fm.search.Clear();
                            }

                        }
                        else if ((fm.cbbigger.Checked == true) && (fm.cbless.Checked == false))
                        {
                            bool trigger = true;
                            for (int i = 0; i < fm.sale.Count; i++)
                            {
                                fm.searchd.Clear();
                                db.Execute<SearchDouble>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and tr.id_R=r.id_R and tr.datereturn between'"+ fm.dtpallroutsfrom.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpallroutsto.Value.ToString("yyyy.MM.dd") + "'", ref fm.searchd);
                                if (fm.searchd.Count != 0)
                                {
                                    fm.sale[i].commonsum += fm.searchd[fm.searchd.Count - 1].id;
                                }
                                if (fm.sale[i].commonsum > Convert.ToDouble(fm.tbbigger.Text))
                                {
                                    if (trigger == true)
                                    {
                                        fm.dgvman.Rows.Clear();
                                    }
                                    fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, fm.sale[i].commonsum);
                                    trigger = false;
                                }
                                fm.search.Clear();
                            }

                        }
                        else if ((fm.cbbigger.Checked == false) && (fm.cbless.Checked == true))
                        {
                            bool trigger = true;
                            for (int i = 0; i < fm.sale.Count; i++)
                            {
                                fm.searchd.Clear();
                                db.Execute<SearchDouble>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and tr.id_R=r.id_R and tr.datereturn between '" + fm.dtpallroutsfrom.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpallroutsto.Value.ToString("yyyy.MM.dd") + "'", ref fm.searchd);
                                if (fm.searchd.Count != 0)
                                {
                                    fm.sale[i].commonsum += fm.searchd[fm.searchd.Count - 1].id;
                                }
                                if (fm.sale[i].commonsum < Convert.ToDouble(fm.tbless.Text))
                                {
                                    if (trigger == true)
                                    {
                                        fm.dgvman.Rows.Clear();
                                    }
                                    fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, fm.sale[i].commonsum);
                                    trigger = false;
                                }
                                fm.search.Clear();
                            }
                        }
                        else if ((fm.cbbigger.Checked == true) && (fm.cbless.Checked == true))
                        {
                            bool trigger = true;
                            for (int i = 0; i < fm.sale.Count; i++)
                            {
                                fm.searchd.Clear();
                                db.Execute<SearchDouble>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and tr.id_R=r.id_R and tr.datereturn between '" + fm.dtpallroutsfrom.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpallroutsto.Value.ToString("yyyy.MM.dd") + "'", ref fm.searchd);
                                if (fm.searchd.Count != 0)
                                {
                                    fm.sale[i].commonsum += fm.searchd[fm.searchd.Count - 1].id;
                                }
                                if ((fm.sale[i].commonsum < Convert.ToDouble(fm.tbless.Text)) && (fm.sale[i].commonsum > Convert.ToDouble(fm.tbbigger.Text)))
                                {
                                    if (trigger == true)
                                    {
                                        fm.dgvman.Rows.Clear();
                                    }
                                    fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, fm.sale[i].commonsum);
                                    trigger = false;
                                }
                                fm.search.Clear();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Упс..Ничего не найдено");
                    }
                }

            }
            else if (fm.tballrouts.Checked == true)
            {
                fm.searchd.Clear();
                fm.sale.Clear();
                db.Execute<Sales>(ref sp, "select r.id_r, count(t.ID_T), sum(t.price) from rout r, ticket t where r.ID_R=t.ID_R group by r.id_r", ref fm.sale);
                fm.dgvman.Rows.Clear();
                for (int i = 0; i < fm.sale.Count; i++)
                {
                    db.Execute<SearchDouble>(ref sp, "select sum(tr.Rtrn) from rout r, return_t tr where r.ID_R='" + fm.sale[i].id_r + "' and r.id_r=tr.id_R", ref fm.searchd);
                    if (fm.searchd.Count != 0)
                    {
                        fm.sale[i].commonsum += fm.searchd[fm.searchd.Count - 1].id;
                    }
                    fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, Math.Round(fm.sale[i].commonsum,2));
                    fm.search.Clear();
                    fm.triggerall = false;
                }
            }
        }
        public void ShowSales()
        {
            fm.dgvman.ColumnCount = 5;
            fm.dgvman.ColumnHeadersVisible = true;
            fm.dgvman.Columns[0].Name = "№ маршрута";
            fm.dgvman.Columns[0].Width = 90;
            fm.dgvman.Columns[1].Name = "Откуда";
            fm.dgvman.Columns[1].Width = 100;
            fm.dgvman.Columns[2].Name = "Куда";
            fm.dgvman.Columns[2].Width = 100;
            fm.dgvman.Columns[3].Name = "Кол-во проданных билетов";
            fm.dgvman.Columns[3].Width = 150;
            fm.dgvman.Columns[4].Name = "Общая стоимость";
            fm.dgvman.Columns[4].Width = 100;
            for (int i = 0; i < fm.sale.Count; i++)
            {
                fm.dgvman.Rows.Add(fm.sale[i].id_r, fm.timetabler[fm.sale[i].id_r - 1].str_tw, fm.timetabler[fm.sale[i].id_r - 1].end_tw, fm.sale[i].quantity, fm.sale[i].commonsum);
            }
        }
        public void Check(int e, int ed)
        {
            if (fm.tbchange.SelectedIndex == 1)
            {
                if (fm.tbchange.TabPages[1].Text == "Изменение маршрута")
                {
                    fm.idrrr = fm.timetabler[e].id;
                    fm.cbbuses.Enabled = true;
                    fm.tbdays.Enabled = true;
                    
                    fm.dgvBT.Enabled = true;
                    fm.cbtowns.Enabled = true;
                    fm.cbtowns.Enabled = true;
                    fm.tbchangetimefrom.Enabled = true;
                   
                    fm.tbchangedistance.Enabled = true;
                    fm.cbchangeprice.Enabled = true;
                    DateTime dr = DateTime.Now;
                    for (int i = 1; i < 15; i++)
                    {
                        fm.search.Clear();
                        db.Execute<Shearch>(ref sp, "sELECT t.id_t FROM ticket t, rout r where t.ID_R=r.ID_R and r.ID_R='" + fm.timetabler[e].id + "' and date(t.dataleave)='" + dr.ToString("yyyy.MM.dd") + "'", ref fm.search);
                        if (fm.search.Count != 0)
                        {
                            
                            fm.cbbuses.Enabled = false;
                            fm.tbdays.Enabled = false;
                            fm.dgvBT.Enabled = false;
                            fm.cbtowns.Enabled = false;
                            fm.tbchangetimefrom.Enabled = false;
                          
                             fm.tbchangedistance.Enabled = false;
                            fm.cbchangeprice.Enabled = false;
                            fm.dattes = false;
                            MessageBox.Show("Так как в течение двух недель на этот маршрут были покупки билетов, то возможно поменять только водителя");
                            break;
                        }
                        dr=dr.AddDays(i);

                    }
                    fm.cbDrivers.Items.Clear();
                    fm.cbdrivers1.Items.Clear();
                    fm.tbdays.Text = fm.timetabler[e].day;
                    fm.tbchangefrom.Text = fm.timetabler[e].str_tw;
                    fm.tbchangeto.Text = fm.timetabler[e].end_tw;
                    fm.tbchangetimefrom.Text = fm.timetabler[e].date_str;
                    fm.tbchangetimeto.Text = fm.timetabler[e].date_end;
                    fm.tbchangedistance.Text = fm.timetabler[e].distation.ToString();
                    fm.cbchangeprice.Text = fm.timetabler[e].id_price.ToString();
                    fm.driverCBs.Clear();
                    db.Execute<DriverCB>(ref sp, "select d.id_d, d.sname_D, d.condition_D from driver d,connectionr_d ds,rout r where ds.id_D=d.id_D and r.id_r=ds.id_R and r.id_r='"+fm.timetabler[e].id+"'", ref fm.driverCBs);
                    if(fm.driverCBs.Count==1)
                    {
                        fm.rbonedriver.Checked = true;
                        if (fm.driverCBs[0].family == "0")
                        {
                            
                            fm.cbDrivers.Items.Add(fm.driverCBs[0].family);
                        }
                        else
                        {
                            fm.cbDrivers.Text = fm.driverCBs[0].family;
                            fm.cbDrivers.Items.Add(fm.driverCBs[0].family);
                        }
                    }
                    else
                    {
                        fm.rbtwodrivers.Checked = true;
                        fm.cbDrivers.Text = fm.driverCBs[0].family;
                        fm.cbDrivers.Items.Add(fm.driverCBs[0].family);
                        fm.cbdrivers1.Text = fm.driverCBs[1].family;
                        fm.cbdrivers1.Items.Add(fm.driverCBs[1].family);
                    }
                    fm.driverCBs.Clear();
                   
                    //select sname_D, r.ID_R,d.Condition_D from driver d, connectionr_d cd, rout r where cd.id_r = r.ID_R and cd.ID_D = d.ID_D and r.id_r = '
                    db.Execute<DriverCB>(ref sp, "select d.id_d, sname_D, d.Condition_D from driver d where d.Condition_D = 2", ref fm.driverCBs);
                    for (int i = 0; i < fm.driverCBs.Count; i++)
                    {
                        fm.cbDrivers.Items.Add(fm.driverCBs[i].family);
                        fm.cbdrivers1.Items.Add(fm.driverCBs[i].family);
                    }
                    fm.dgvBT.Rows.Clear();
                    fm.dgvBT.Columns.Clear();
                    fm.dgvBT.ColumnCount = 2;
                    fm.dgvBT.Columns[0].Name = "Пункт";
                    fm.cbtowns.Items.Clear();
                    for (int i = 0; i < fm.town.Count; i++)
                    {
                        if ((fm.town[i].name_t != fm.timetabler[e].str_tw) && (fm.town[i].name_t != fm.timetabler[e].end_tw))

                        {
                            fm.cbtowns.Items.Add(fm.town[i].name_t);
                        }
                    }
                    fm.dgvBT.ColumnCount = 2;
                    fm.dgvBT.Columns[1].Name = "Растояние";

                    LoadBtown(e);
                    for (int i = 0; i < fm.bttown.Count; i++)
                    {

                        fm.dgvBT.Rows.Add(fm.bttown[i].t_name, fm.bttown[i].distance);


                    }

                    
                }

            }
            else if (fm.tbchange.SelectedIndex == 0)
            {
                if (fm.tbchange.TabPages[0].Text == "Информация по маршруту")
                {
                    fm.idsales = e;
                    fm.rball.Enabled = true;
                    fm.rbparts.Checked = true;
                    fm.rbparts.Enabled = true;
                    fm.tbsalesfrom.Text = fm.timetabler[e].end_tw;
                    fm.tbsalesto.Text = fm.timetabler[e].str_tw;
                    fm.tbsalesquantity.Text = fm.dgvman[3, ed].Value.ToString();
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select count(tr.ID_R) from rout r, return_t tr where r.ID_R='" + fm.timetabler[e].id + "' and r.id_R=tr.id_R", ref fm.search);
                    fm.tbsalsereturn.Text = fm.search[fm.search.Count - 1].id.ToString();
                    fm.search.Clear();
                    fm.lbgain.Text = "Прибыль";
                    fm.tbgain.Text = fm.dgvman[4, ed].Value.ToString();
                    fm.salesBT.Clear();
                    if (fm.triggerall == true)
                    {
                        db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + fm.timetabler[e].id + "' and tw.ID_T=t.ID_ST and t.Date_Purchase between '" + fm.from.ToString("yyyy.MM.dd") + "' and '" + fm.to.ToString("yyyy.MM.dd") + "'and t.ID_R=r.ID_R group by t.price", ref fm.salesBT);
                    }
                    else
                    {
                        db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + fm.timetabler[e].id + "' and tw.ID_T=t.ID_ST and r.ID_R=t.ID_R group by t.price", ref fm.salesBT);
                    }

                    fm.dgvsales.Rows.Clear();
                    fm.dgvsales.ColumnCount = 3;
                    fm.dgvsales.Columns[0].Name = "Участок";
                    fm.dgvsales.Columns[1].Name = "Кол-во купленных билетов";
                    fm.dgvsales.Columns[2].Name = "Cумма";
                    for (int i = 0; i < fm.salesBT.Count; i++)
                    {
                        fm.dgvsales.Rows.Add(fm.salesBT[i].to + "-" + fm.salesBT[i].from, fm.salesBT[i].quantity, fm.salesBT[i].price);
                    }
                    fm.dtpfrm.Value = fm.from;
                    fm.dtpto.Value = fm.to;

                }
                else if (fm.tbchange.TabPages[0].Text == "Информация о водителе")
                {
                    string[] val = fm.dgvman[1, e].Value.ToString().Split(' ');
                    fm.tbinfaname.Text = val[0];
                    fm.tbinfasname.Text = val[1];
                    fm.tbinfatname.Text = val[2];
                    fm.tbinfapass.Text = fm.dgvman[2, e].Value.ToString();
                    fm.tbinfaiden.Text = fm.dgvman[3, e].Value.ToString();
                    fm.tbinfanumber.Text = fm.dgvman[4, e].Value.ToString();
                    if (fm.dgvman[5, e].Value.ToString() == "Работает")
                    {
                        fm.cbinfacondition.Text = "Работает";
                        fm.lbchoese.Text = "По маршруту";
                        fm.search.Clear();
                        db.Execute<Shearch>(ref sp, "select  cd.id_r from connectionr_d cd,driver d where cd.ID_D=d.ID_D and d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                        fm.idrr = fm.search[0].id;
                        fm.cbrouts.Items.Clear();
                        for (int i = 0; i < fm.timetabler.Count; i++)
                        {
                            if (fm.search[0].id == fm.timetabler[i].id)
                            {
                                fm.cbrouts.Text = fm.timetabler[i].str_tw + '-' + fm.timetabler[i].end_tw;
                            }
                        }
                        fm.condition = true;
                    }
                    else
                    {
                        fm.cbinfacondition.Text = fm.driver[e].Condition;
                        fm.lbchoese.Text = "Выбрать маршрут";

                        fm.search.Clear();
                        db.Execute<Shearch>(ref sp, "select  cd.id_r from connectionr_d cd, driver d where cd.ID_D = d.ID_D group by cd.id_R ", ref fm.search);
                        fm.idrr = fm.search[0].id;
                        fm.cbrouts.Items.Clear();
                        fm.cbrouts.Text = "";
                        for (int i = 0; i < fm.timetabler.Count; i++)
                        {
                            for (int j = 0; j < fm.search.Count; j++)
                            {
                                if (fm.timetabler[i].id == fm.search[j].id)
                                {
                                    fm.cbrouts.Items.Add(fm.timetabler[i].id + " " + fm.timetabler[i].str_tw + "-" + fm.timetabler[i].end_tw);
                                }
                            }
                        }
                        fm.condition = false;
                    }

                }
                else if (fm.tbchange.TabPages[0].Text == "Списание на ремонт/Возврат")
                {
                   
                    if(fm.bus[e].condition=="Занят")
                    {
                        DateTime dr = DateTime.Now;
                        bool dates = false;
                        for (int i = 1; i < 15; i++)
                        {
                            fm.search.Clear();
                            db.Execute<Shearch>(ref sp, "SELECT t.id_t FROM ticket t, rout r,connectionr_d d,bus b where t.ID_R=r.ID_R and r.ID_R=d.id_R and d.ID_b=b.id_b and b.id_b='"+fm.bus[e].id+ "' and date(t.dataleave)='" + dr.ToString("yyyy.MM.dd") + "'", ref fm.search);
                            if(fm.search.Count>0)
                            {
                                
                                MessageBox.Show("Замена автобусу будет возможна только на тот в котором столько же свободных мест!","Внимание!",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                                fm.busforCB.Clear();
                                db.Execute<BusforCB>(ref sp, "select b.ID_B,l.NAME_L,b.NOMER_B, l.QUANTITY_L from bus b, look l where b.ID_L=l.ID_L and b.Condition_B=2 and l.QUANTITY_L='"+fm.bus[e].quantity+"'", ref fm.busforCB);
                                if (fm.busforCB.Count != 0)
                                {
                                    fm.cbinfafreebus.Items.Clear();
                                    for (int j = 0; j < fm.busforCB.Count; j++)
                                    {
                                        fm.cbinfafreebus.Items.Add(fm.busforCB[j].model + " " + fm.busforCB[j].number);
                                    }
                                    dates = true;
                                    break;

                                }
                               

                            }
                            dr=dr.AddDays(i);

                        }
                        fm.label44.Visible = true;
                        fm.cbinfafreebus.Visible = true;
                        if (dates==false)
                        {

                            fm.busforCB.Clear();
                            db.Execute<BusforCB>(ref sp, "select b.ID_B,l.NAME_L,b.NOMER_B, l.QUANTITY_L from bus b, look l where b.ID_L=l.ID_L and b.Condition_B=2", ref fm.busforCB);
                            if (fm.busforCB.Count != 0)
                            {
                                fm.cbinfafreebus.Items.Clear();
                                for (int j = 0; j < fm.busforCB.Count; j++)
                                {
                                    fm.cbinfafreebus.Items.Add(fm.busforCB[j].model + " " + fm.busforCB[j].number);
                                }
                               

                            }
                        }
                       
                        fm.cbinfacondition.Text = "";
                        fm.tbinfabusnumber.Text = fm.dgvman[1, e].Value.ToString();
                        fm.tbinfamark.Text = fm.dgvman[2, e].Value.ToString();
                        fm.tbinfafrees.Text = fm.dgvman[3, e].Value.ToString();
                        fm.tbinfaaveragespeed.Text = fm.dgvman[4, e].Value.ToString();
                        fm.tbinfaconditionbus.Text = fm.dgvman[5, e].Value.ToString();
                        fm.button5.Text = "Списать в ремонт";

                    }
                    else if(fm.bus[e].condition == "Cвободен")
                    {
                        fm.label44.Visible = false;
                        fm.cbinfafreebus.Visible = false;
                        fm.cbinfafreebus.Text = "";

                        fm.tbinfabusnumber.Text = fm.dgvman[1, e].Value.ToString();
                        fm.tbinfamark.Text = fm.dgvman[2, e].Value.ToString();
                        fm.tbinfafrees.Text = fm.dgvman[3, e].Value.ToString();
                        fm.tbinfaaveragespeed.Text = fm.dgvman[4, e].Value.ToString();
                        fm.tbinfaconditionbus.Text = fm.dgvman[5, e].Value.ToString();
                        fm.button5.Text = "Списать в ремонт";
                    }
                    else if(fm.bus[e].condition=="В ремонте")
                    {
                        fm.label44.Visible = false;
                        fm.cbinfafreebus.Visible = false;
                        fm.cbinfafreebus.Text = "";
                        fm.tbinfabusnumber.Text = fm.dgvman[1, e].Value.ToString();
                        fm.tbinfamark.Text = fm.dgvman[2, e].Value.ToString();
                        fm.tbinfafrees.Text = fm.dgvman[3, e].Value.ToString();
                        fm.tbinfaaveragespeed.Text = fm.dgvman[4, e].Value.ToString();
                        fm.tbinfaconditionbus.Text = fm.dgvman[5, e].Value.ToString();
                        fm.button5.Text = "Вернуть";
                    }
                }
            }
        }
        public void ChangeBus()
        {
            if (fm.tbinfaconditionbus.Text == "Cвободен")
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + fm.tbinfabusnumber.Text + "'", ref fm.search);
                int n = db.ExecuteNonQuery(ref sp, "update bus b set b.condition_b='В ремонте' where b.id_b='" + fm.search[0].id + "'", 0);
                if (n > 0)
                {
                    MessageBox.Show("Изменения вступили в силу");
                }
            }
            else if (fm.tbinfaconditionbus.Text == "В ремонте")
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + fm.tbinfabusnumber.Text + "'", ref fm.search);
                int n = db.ExecuteNonQuery(ref sp, "update bus b set b.condition_b='Cвободен' where b.id_b='" + fm.search[0].id + "'", 0);
                if (n > 0)
                {
                    MessageBox.Show("Изменения вступили в силу");
                }

            }
            else
            {
                if (fm.cbinfafreebus.Text != "")
                {
                    fm.search.Clear();
                    string[] val = fm.cbinfafreebus.Text.Split(' ');
                    db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + val[1] + "'", ref fm.search);
                    int idb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select d.id_r from connectionr_d d, bus b where d.ID_B=b.ID_B and b.NOMER_B='" + fm.tbinfabusnumber.Text + "'", ref fm.search);
                    int n=db.ExecuteNonQuery(ref sp, "update connectionr_d d set d.ID_B='" + idb + "' where d.id_r='" + fm.search[0].id + "'", 0);
                    if(n>0)
                    {
                       fm.search.Clear();
                        db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + fm.tbinfabusnumber.Text + "'", ref fm.search);
                         n = db.ExecuteNonQuery(ref sp, "update bus b set b.condition_b='Cвободен' where b.id_b='" + fm.search[0].id + "'", 0);
                        if (n > 0)
                        {
                             db.ExecuteNonQuery(ref sp, "update bus b set b.condition_b='Занят' where b.id_b='" + idb + "'", 0);

                            MessageBox.Show("Изменения вступили в силу");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберете маршрут");
                }
            }
        }
        public void ChandeRout(int e)
        {
            if(fm.dattes==false)
            {
                if(fm.rbonedriver.Checked==true)
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='"+fm.cbDrivers.Text+"'",ref fm.search);
                    int iddb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d where d.id_r='" + e + "'",ref fm.search);
                    int idb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from connectionr_d d, rout r where d.id_R=r.id_R  and r.id_r='" + e + "'", ref fm.search);
                    int n=db.ExecuteNonQuery(ref sp, "delete from connectionr_d where connectionr_D.id_r='"+e + "'",0);
                    if(n>0)
                    {
                        for (int i = 0; i < fm.search.Count(); i++)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Cвободен' where d.id_d='" + fm.search[i].id+"'",0);
                        }
                        n=db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('"+e+"', '"+idb+"', '"+iddb+"')", 0);
                        if(n>0){
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb + "'", 0);
                            MessageBox.Show("Операция прошла успешно");

                        }

                    }


                }
                else
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='" + fm.cbDrivers.Text + "'", ref fm.search);
                    int iddb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='" + fm.cbdrivers1.Text + "'", ref fm.search);
                    int iddb1 = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d where d.id_r='" + e + "'", ref fm.search);
                    int idb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from connectionr_d d, rout r where d.id_R=r.id_R  and r.id_r='" + e + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "delete from connectionr_d where connectionr_D.id_r='" + e + "'", 0);
                    if (n > 0)
                    {
                        for (int i = 0; i < fm.search.Count(); i++)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Cвободен' where d.id_d='" + fm.search[i].id + "'", 0);
                        }
                        n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + e + "', '" + idb + "', '" + iddb + "')", 0);
                        n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + e + "', '" + idb + "', '" + iddb1 + "')", 0);
                        if (n > 0)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb + "'", 0);
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb1 + "'", 0);
                            MessageBox.Show("Операция прошла успешно");

                        }

                    }
                }
            }
            else
            {
                fm.search.Clear();

                int idprice = 0;
                string[] d = fm.cbchangeprice.Text.Split(',');
                string rdoub = "";
                if (d.Length != 1)
                {
                    rdoub = d[0] + "." + d[1];
                }
                else rdoub = d[0];
                db.Execute<Shearch>(ref sp, "select p.id_pr from price p where p.price='" + rdoub + "'", ref fm.search);
                if (fm.search.Count != 0)
                {
                    idprice = fm.search[0].id;
                }
                else
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select p.id_pr from price p order by p.id_pr", ref fm.search);
                    idprice = fm.search[fm.search.Count - 1].id + 1;
                    db.ExecuteNonQuery(ref sp, "insert into price values('" + idprice + "', '" + rdoub + "')", 0);
                }
                fm.search.Clear();
                d = fm.tbchangedistance.Text.Split(',');
                string doub = "";
                if (d.Length != 1)
                {
                    doub = d[0] + "." + d[1];
                }
                else doub = d[0];
                db.ExecuteNonQuery(ref sp, "update rout r set r.DISTANCE_R='"+doub+"',r.DAY_R='"+fm.tbdays.Text+"',r.ENDDATE_R='"+fm.tbchangetimeto.Text+"',r.ID_Pr='"+idprice+"' where r.id_r='"+e+"'", 0);
                if(fm.dgvBT.Rows.Count-1>1)
                {
                    db.ExecuteNonQuery(ref sp, "delete from btown where r.id_R='" + e + "'",0);
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select bt.ID_BT from btown bt order by bt.ID_BT ", ref fm.search);
                    int btid = fm.search[fm.search.Count - 1].id + 1;
                    for (int i = 0; i < fm.dgvBT.Rows.Count - 1; i++)
                    {
                        SearchTown(fm.dgvBT[1, i].Value.ToString());
                        db.ExecuteNonQuery(ref sp, "insert into btown values('" + e + "', '" + btid + "', '" + fm.search[0].id + "', '" + fm.dgvmnew[0, i].Value.ToString() + "')", 0);
                        btid++;
                    }
                }
                if (fm.rbonedriver.Checked == true)
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='" + fm.cbDrivers.Text + "'", ref fm.search);
                    int iddb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d where d.id_r='" + e + "'", ref fm.search);
                    int idb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from connectionr_d d, rout r where d.id_R=r.id_R  and r.id_r='" + e + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "delete from connectionr_d where connectionr_D.id_r='" + e + "'", 0);
                    if (n > 0)
                    {
                        for (int i = 0; i < fm.search.Count(); i++)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Cвободен' where d.id_d='" + fm.search[i].id + "'", 0);
                        }
                        n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + e + "', '" + idb + "', '" + iddb + "')", 0);
                        if (n > 0)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb + "'", 0);
                            MessageBox.Show("Операция прошла успешно");

                        }

                    }


                }
                else
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='" + fm.cbDrivers.Text + "'", ref fm.search);
                    int iddb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from driver d where d.sname='" + fm.cbdrivers1.Text + "'", ref fm.search);
                    int iddb1 = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d where d.id_r='" + e + "'", ref fm.search);
                    int idb = fm.search[0].id;
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "Select d.id_D from connectionr_d d, rout r where d.id_R=r.id_R  and r.id_r='" + e + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "delete from connectionr_d where connectionr_D.id_r='" + e + "'", 0);
                    if (n > 0)
                    {
                        for (int i = 0; i < fm.search.Count(); i++)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Cвободен' where d.id_d='" + fm.search[i].id + "'", 0);
                        }
                        n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + e + "', '" + idb + "', '" + iddb + "')", 0);
                        n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + e + "', '" + idb + "', '" + iddb1 + "')", 0);
                        if (n > 0)
                        {
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb + "'", 0);
                            db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Занят' where d.id_d='" + iddb1 + "'", 0);
                            MessageBox.Show("Операция прошла успешно");

                        }

                    }
                }
            }
        }
        public void ChangeCondition(bool con)
        {
            int ir = -1;
            if (con == true)
            {
                if (fm.cbinfacondition.Text != "Работает")
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select cd.id_d from connectionr_d cd, rout r where cd.id_r=r.id_r and r.id_R='" + fm.idrr + "'", ref fm.search);
                    if (fm.search.Count == 1)
                    {
                        MessageBox.Show("Не забудьте по маршруту " + fm.cbrouts.Text + " зачислить водителя, так продажи на данный момент на этот маршрут приотсановлены");
                    }
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select  cd.id_d from connectionr_d cd,driver d where cd.ID_D=d.ID_D and d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='" + fm.cbinfacondition.Text + "' where d.id_D='" + fm.search[0].id + "'", 0);
                    if (n == 1)
                    {
                        n = db.ExecuteNonQuery(ref sp, "update connectionr_d d set d.id_D='0' where d.id_D='" + fm.search[0].id + "'", 0);
                      
                        if (n > 0)
                        {
                            ir = fm.search[0].id-1;
                            fm.search.Clear();
                            db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d,rout r where d.id_R=r.id_r  and r.id_r='"+fm.idrr+"'", ref fm.search);
                            if(fm.search.Count==2)
                            {
                                fm.search.Clear();
                                db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d,rout r where d.id_R=r.id_r and d.id_d='0' and r.id_r='" + fm.idrr + "'", ref fm.search);
                                
                                    int n1 = db.ExecuteNonQuery(ref sp, "delete   from connectionr_d  where connectionr_d.ID_r='" + fm.idrr + "' and connectionr_d.id_d='0'", 0);
                                    if (n1 > 0)
                                    {
                                    //n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + fm.idrr + "', '" + fm.search[0].id + "', '0')", 0);

                                    //if (n > 0)
                                    //{
                                    //    MessageBox.Show("Изменения вступили в силу");
                                    //}
                                    MessageBox.Show("Изменения вступили в силу");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Изменения вступили в силу");


                            }

                           
                        }
                        fm.search.Clear();
                    }
                }
            }
            else
            {
                if (fm.cbinfacondition.Text != "Свободен")
                {
                    if (fm.cbinfacondition.Text == "Работает")
                    {
                        if (fm.cbrouts.Text != "")
                        {
                            
                            string[] val = fm.cbrouts.Text.Split(' ');
                            fm.search.Clear();
                            db.Execute<Shearch>(ref sp, "select cd.id_d from connectionr_d cd, rout r where cd.id_r=r.id_r and r.id_R='" + Convert.ToInt32(val[0]) + "'", ref fm.search);
                        
                            if (fm.search.Count == 1)
                            {
                                if (fm.search[0].id == 0)
                                {
                                    fm.search.Clear();
                                    db.Execute<Shearch>(ref sp, "select  d.id_d from driver d where  d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                                    int idd = fm.search[0].id;
                                    int n = db.ExecuteNonQuery(ref sp, "update connectionr_d d,rout r set d.id_D='" + idd + "' where d.id_D='0' and d.id_r=r.id_r and r.id_R='" + val[0] + "'", 0);
                                    fm.search.Clear();
                                    if (n > 0)
                                    {
                                        n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='" + fm.cbinfacondition.Text + "' where d.id_D='" + idd + "'", 0);
                                        if (n > 0)
                                        {
                                            ir = idd-1;
                                            MessageBox.Show("Изменения вступили в силу");
                                        }
                                    }
                                }
                                else 
                                {
                                    DialogResult result = MessageBox.Show("Вы хотите добавить водителя к маршруту?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        int iddr = fm.search[0].id;
                                        fm.search.Clear();
                                        db.Execute<Shearch>(ref sp, "select  d.id_d from driver d where  d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                                        int idd = fm.search[0].id;
                                        fm.search.Clear();
                                        db.Execute<Shearch>(ref sp, "select d.id_b from connectionr_d d where d.id_d='" + iddr + "' and d.id_r='" +val[0] + "'", ref fm.search);
                                        int idb = fm.search[0].id;
                                        fm.search.Clear();
                                        int n = db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('" + val[0] + "', '" + idb + "', '" + idd + "')", 0);
                                        if (n > 0)
                                        {
                                            n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='" + fm.cbinfacondition.Text + "' where d.id_D='" + idd + "'", 0);
                                            if (n > 0)
                                            {
                                                ir = idd-1;
                                                MessageBox.Show("Изменения вступили в силу");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Водитель по маршруту будет заменен новым");
                                        int iddr = fm.search[0].id;
                                        fm.search.Clear();
                                        db.Execute<Shearch>(ref sp, "select  d.id_d from driver d where  d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                                        int idd = fm.search[0].id;
                                        int n = db.ExecuteNonQuery(ref sp, "update connectionr_d d,rout r set d.id_D='" + idd + "' where d.id_D='" + iddr + "' and d.id_r=r.id_r and r.id_R='" + val[0] + "'", 0);
                                        fm.search.Clear();
                                        if (n > 0)
                                        {
                                            n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='" + fm.cbinfacondition.Text + "' where d.id_D='" + idd + "'", 0);
                                            if (n > 0)
                                            {
                                                ir = idd-1;
                                                MessageBox.Show("Изменения вступили в силу");
                                            }
                                        }
                                    }
                                }
                            }
                            else if (fm.search.Count == 2)
                            {
                                MessageBox.Show("Вы не можете присвоить водителя этму маршруту т.к. за этим маршршрутам учтенно два водителя");
                            }



                        }
                        else MessageBox.Show("Выберете маршрут!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            fm.dgvman.Rows.Clear();
            fm.dgvman.Rows.Clear();
            
            LoadDrivers();
            ShowDrivers();
            if(ir!=-1)
            {
                Check(ir,0);
            }
            
        }
        public void LoadBtown(int e)
        {
            fm.bttown.Clear();
            db.Execute<Bttown>(ref sp, "select bt.id_bt, t.name_t, bt.distance_bt from btown bt, town t, rout r where bt.ID_T=t.ID_T and bt.ID_R=r.ID_R and r.ID_R='" + fm.timetabler[e].id + "'", ref fm.bttown);
        }
        public void LoadDriverforCB()
        {
          
            fm.cbnrDriver.Items.Clear();
            fm.cbDrivers.Items.Clear();
            fm.cbdrivers1.Items.Clear();
            //select sname_D, r.ID_R,d.Condition_D from driver d, connectionr_d cd, rout r where cd.id_r = r.ID_R and cd.ID_D = d.ID_D and r.id_r = '
            db.Execute<DriverCB>(ref sp, "select d.id_d, sname_D, d.Condition_D from driver d where d.Condition_D = 2", ref fm.driverCBs);
            for (int i = 0; i < fm.driverCBs.Count; i++)
            {
                fm.cbnrDriver.Items.Add(fm.driverCBs[i].family);
                fm.cbDrivers.Items.Add(fm.driverCBs[i].family);
                fm.cbdrivers1.Items.Add(fm.driverCBs[i].family);
            }
            //select sname_D, d.Condition_D from driver d where d.Condition_D = 2
        }
        
        public void AddDriver()
        {
            int id = 0;
            db.Execute<Shearch>(ref sp, "select d.id_d from driver d order by d.id_D", ref fm.search);
            if (fm.search.Count != 0)
            {
                id = fm.search[fm.search.Count - 1].id + 1;
            }
            else
            {
                id = 1;
            }
            fm.search.Clear();
            string command = "'" + id + "', '" + fm.tbdrivername.Text + "', '" + fm.tbdriversecond.Text + "', '" + fm.tbdriverthird.Text + "', '" + fm.tbpasspot.Text + "', '" + fm.tbidentity.Text + "','" + fm.tbtelephon.Text + "', 'Свободен'";
            id = db.ExecuteNonQuery(ref sp, "insert into driver values(" + command + ")", 0);
            if (id == 1)
            {
                MessageBox.Show("Водитель успешно занес в базу данных");
            }
            else MessageBox.Show("Упс...Произошла ошибка");
        }
        public void AddBus()
        {
            int id = 0;
            db.Execute<Shearch>(ref sp, "select l.id_l from look l order by l.id_l", ref fm.search);
            if (fm.search.Count != 0)
            {
                id = fm.search[fm.search.Count - 1].id + 1;
            }
            else
            {
                id = 1;
            }
            fm.search.Clear();
            string command = "'" + id + "', '" + fm.tbmodel.Text + "', '" + fm.tbsites.Text + "', '" + fm.tbaveragespeed.Text + "'";
            int n;
            n = db.ExecuteNonQuery(ref sp, "insert into look values(" + command + ")", 0);
            if (n == 1)
            {
                n = id;
                db.Execute<Shearch>(ref sp, "select b.id_b from bus b order by b.id_b", ref fm.search);
                if (fm.search.Count != 0)
                {
                    id = fm.search[fm.search.Count - 1].id + 1;
                }
                else
                {
                    id = 1;
                }
                fm.search.Clear();
                command = "'" + id + "', '" + fm.tbbusnomber.Text + "', 'Cвободен', '" + n + "'";
                n = db.ExecuteNonQuery(ref sp, "insert into bus values(" + command + ")", 0);
                if (n == 1)
                {
                    MessageBox.Show("Автобус успешно занесен в базу данных");
                }
                else MessageBox.Show("Упс...Произошла ошибка");

            }
            else MessageBox.Show("Упс...Произошла ошибка");
        }
        public void FreeBuses()
        {
            fm.cbfreebuses.Items.Clear();
            fm.busforCB.Clear();
            db.Execute<BusforCB>(ref sp, "select b.ID_B,l.NAME_L,b.NOMER_B, l.QUANTITY_L from bus b, look l where b.ID_L=l.ID_L and b.Condition_B=2", ref fm.busforCB);
            for (int i = 0; i < fm.busforCB.Count; i++)
            {
                fm.cbfreebuses.Items.Add(fm.busforCB[i].model + " " + fm.busforCB[i].number + " " + fm.busforCB[i].quantity);
            }

        }
        public void SearchSales(int e)
        {
            if (fm.rbparts.Checked == true)
            {
                if ((fm.cbsalesto.Checked == true) && (fm.cbsalesfrom.Checked == true))
                {

                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select count(t.ID_T) from rout r, ticket t  where r.ID_R='" + fm.timetabler[e].id + "' and t.Date_Purchase between '" + fm.dtpfrm.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpto.Value.ToString("yyyy.MM.dd") + "' and t.id_r=r.id_r", ref fm.search);
                    if (fm.search[fm.search.Count - 1].id != 0)
                    {
                        fm.tbsalesquantity.Text = fm.search[fm.search.Count - 1].id.ToString();
                        fm.search.Clear();
                        db.Execute<Shearch>(ref sp, "select count(tr.ID_R) from rout r, return_t tr where r.ID_R='" + fm.timetabler[e].id + "' and tr.id_R=r.id_R and Date(tr.datereturn) between '"+ fm.dtpfrm.Value.ToString("yyyy.MM.dd") + "' and '"+ fm.dtpto.Value.ToString("yyyy.MM.dd") + "'", ref fm.search);
                        if (fm.search.Count != 0)
                        {
                            fm.tbsalsereturn.Text = fm.search[fm.search.Count - 1].id.ToString();
                        }
                        else
                        {
                            fm.tbsalsereturn.Text = "0";
                        }
                        fm.salesBT.Clear();
                        db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + fm.timetabler[e].id + "' and tw.ID_T=t.ID_ST and t.id_r=r.id_R and t.Date_Purchase between '" + fm.dtpfrm.Value.ToString("yyyy.MM.dd") + "' and '" + fm.dtpto.Value.ToString("yyyy.MM.dd") + "' group by t.price", ref fm.salesBT);
                        fm.dgvsales.Rows.Clear();
                        fm.dgvsales.ColumnCount = 3;
                        fm.dgvsales.Columns[0].Name = "Участок";
                        fm.dgvsales.Columns[1].Name = "Кол-во купленных билетов";
                        fm.dgvsales.Columns[2].Name = "Cумма";
                        double gain = 0;
                        for (int i = 0; i < fm.salesBT.Count; i++)
                        {
                            fm.dgvsales.Rows.Add(fm.salesBT[i].to + "-" + fm.salesBT[i].from, fm.salesBT[i].quantity, fm.salesBT[i].price);
                            gain += fm.salesBT[i].price;
                        }
                        fm.lbgain.Text = "Всего по участку";
                        fm.tbgain.Text = gain.ToString();


                    }
                    else
                    {
                        MessageBox.Show("Упс...Не было ничего найдено");
                    }

                }
            }
            else if (fm.rball.Checked == true)
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select count(t.ID_T) from rout r, ticket t  where r.ID_R='" + fm.timetabler[e].id + "' and r.id_R=t.id_r ", ref fm.search);
                if (fm.search[fm.search.Count - 1].id != 0)
                {
                    fm.tbsalesquantity.Text = fm.search[fm.search.Count - 1].id.ToString();
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select count(tr.ID_R) from rout r, return_t tr where r.ID_R='" + fm.timetabler[e].id + "' and tr.id_r=r.id_r ", ref fm.search);
                    fm.tbsalsereturn.Text = fm.search[fm.search.Count - 1].id.ToString();
                    fm.salesBT.Clear();
                    db.Execute<SalesBT>(ref sp, "select tw.NAME_T,(select tw1.Name_t from rout r1, town tw1 where tw1.ID_T=t.ID_END and r1.ID_R=r.ID_R), count(t.id_t), sum(t.price) from rout r, ticket t, town tw  where r.ID_R='" + fm.timetabler[e].id + "' and tw.ID_T=t.ID_ST and t.id_r=r.id_r group by t.price", ref fm.salesBT);
                    fm.dgvsales.Rows.Clear();
                    fm.dgvsales.ColumnCount = 3;
                    fm.dgvsales.Columns[0].Name = "Участок";
                    fm.dgvsales.Columns[1].Name = "Кол-во купленных билетов";
                    fm.dgvsales.Columns[2].Name = "Cумма";
                    double gain = 0;
                    for (int i = 0; i < fm.salesBT.Count; i++)
                    {
                        fm.dgvsales.Rows.Add(fm.salesBT[i].to + "-" + fm.salesBT[i].from, fm.salesBT[i].quantity, fm.salesBT[i].price);
                        gain += fm.salesBT[i].price;
                    }
                    fm.lbgain.Text = "Всего по участку";
                    fm.tbgain.Text = gain.ToString();

                }
            }
        }
        public void Report()
        {
            InformationforReport n=new InformationforReport();
            
            n.rout = fm.tbsalesto.Text + "-" + fm.tbsalesfrom.Text;
            if (fm.rbparts.Checked == true)
            {
                n.fromdate = fm.dtpfrm.Text;
                n.todate = fm.dtpto.Text;
            }
            else
            {
                n.fromdate = "-";
                n.todate = DateTime.Now.ToShortDateString();
            }
            n.quantitysoldticket = Convert.ToInt32(fm.tbsalesquantity.Text);
            n.quantityreturnticket = Convert.ToInt32(fm.tbsalsereturn.Text);
            n.gain = Convert.ToDouble(fm.tbgain.Text);
            for (int i = 0; i<fm.dgvsales.Rows.Count-1 ; i++)
            {
                n.a.Add(new DGVforReport( fm.dgvsales[0, i].Value.ToString(), Convert.ToInt32(fm.dgvsales[1, i].Value), Convert.ToDouble(fm.dgvsales[2, i].Value)));
            }
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(InformationforReport));
            System.IO.StreamWriter file = new System.IO.StreamWriter("1.xml");
            writer.Serialize(file, n);
            file.Close();
            report r = new report("ReportSales.frx");
            r.Show();
        }
        public void  LoadDrivers()
        {
            fm.driver.Clear();
            db.Execute<Driver>(ref sp, "select d.NAME_D,d.SNAME_D,d.THNAME_D,d.PASS_D,d.INDEN_D,d.number_d,d.Condition_D,d.id_d from driver d where d.id_D!=0", ref fm.driver);
        }
        public void ShowDrivers()
        {
            fm.dgvman.ColumnCount = 6;
            fm.dgvman.Columns[0].Name = "№";
            fm.dgvman.Columns[0].Width = 30;
            fm.dgvman.Columns[1].Name = "ФИО";
            fm.dgvman.Columns[2].Name = "Номер паспорта";
            fm.dgvman.Columns[3].Name = "Индинтификационный код";
            fm.dgvman.Columns[4].Name = "Номер телефона";
            fm.dgvman.Columns[5].Name = "Cocтояние";

            for (int i = 0; i < fm.driver.Count; i++)
            {
                fm.dgvman.Rows.Add(fm.driver[i].id,fm.driver[i].FIO, fm.driver[i].passd, fm.driver[i].iden, fm.driver[i].number, fm.driver[i].Condition);
            }
        }
        public void AddRout()
        {
            fm.search.Clear();

            int idprice = 0;
            string[] d = fm.cbpk.Text.Split(',');
            string rdoub="";
            if (d.Length != 1)
            {
                rdoub = d[0] + "." + d[1];
            }
            else rdoub = d[0];
            db.Execute<Shearch>(ref sp, "select p.id_pr from price p where p.price='" + rdoub + "'", ref fm.search);
            if(fm.search.Count!=0)
            {
                idprice = fm.search[0].id;
            }
            else
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select p.id_pr from price p order by p.id_pr", ref fm.search);
                idprice = fm.search[fm.search.Count-1].id+1;
                db.ExecuteNonQuery(ref sp, "insert into price values('" + idprice + "', '" + rdoub + "')",0);
            }
            fm.search.Clear();
            db.Execute<Shearch>(ref sp, "select r.id_r from rout r order by r.id_r",ref fm.search);
            int idr = fm.search[fm.search.Count - 1].id+1;
            SearchTown(fm.cbto.Text);
            int idstart = fm.search[0].id;
            SearchTown(fm.cbfrm.Text);
            int idend = fm.search[0].id;
            fm.search.Clear();
            db.Execute<Shearch>(ref sp, "select r.n_p from rout r where r.strdate_r='" + fm.dateleave.Text + "", ref fm.search);
            if(fm.search.Count!=0)
            {
                MessageBox.Show("Данная платформа занята");
                return;
            }
            fm.search.Clear();
            d = fm.tbdistance.Text.Split(',');
            string doub = "";
            if (d.Length != 1)
            {
                doub = d[0] + "." + d[1];
            }
            else doub = d[0];
            int n = 0;
           n=db.ExecuteNonQuery(ref sp, "insert into rout values('"+idr+"', '"+idstart+"', '"+idend+"', '"+fm.tbnrdays.Text+"', '"+fm.dateleave.Text+"', '"+fm.datearrive.Text+"', '"+doub+"', '"+idprice+"', '"+fm.cbnp.Text+"')", 0);
            if(n==1)
            {
                string[] val = fm.cbfreebuses.Text.Split(' ');
                db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + val[1] + "'", ref fm.search);
                int idb = fm.search[0].id;
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select d.id_d from driver d where d.sname_d='" + fm.cbnrDriver.Text + "'", ref fm.search);
                int iddriver = fm.search[0].id;
                n=db.ExecuteNonQuery(ref sp, "insert into connectionr_d values('"+idr+"', '"+idb+"', '"+iddriver+"')", 0);
                if(n==1)
                {
                    db.ExecuteNonQuery(ref sp, "update driver d set d.Condition_D='Работает' where d.id_d='" + iddriver + "'", 0);
                    db.ExecuteNonQuery(ref sp, "update  bus b set b.Condition_B='Занят' where b.ID_B='" + idb + "'", 0);
                }
                if (fm.rbyes.Checked==true)
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select bt.ID_BT from btown bt order by bt.ID_BT ", ref fm.search);
                    int btid = fm.search[fm.search.Count - 1].id+1;
                    for (int i = 0; i < fm.dgvmnew.Rows.Count-1; i++)
                    {
                        SearchTown(fm.dgvmnew[1, i].Value.ToString());
                        db.ExecuteNonQuery(ref sp, "insert into btown values('"+idr+"', '"+btid+"', '"+fm.search[0].id+"', '"+fm.dgvmnew[0,i].Value.ToString()+"')", 0);
                        btid++;
                    }
                }
                MessageBox.Show("Маршрут успешно добавлен");
            }
        }
        public void SearchTown(string s)
        {
            fm.search.Clear();
            db.Execute<Shearch>(ref sp, "Select t.id_t from town t where t.name_t='" + s + "'", ref fm.search);
        }
        public void SearchDriver(string s)
        {
            fm.search.Clear();
            db.Execute<Shearch>(ref sp, "select b.id_b from bus b where b.nomer_b='" + s + "'", ref fm.search);
        }
        public void DeleteDriver()
        {
            if(fm.cbinfacondition.Text=="Работает")
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select cd.id_d from connectionr_d cd, rout r where cd.id_r=r.id_r and r.id_R='" + fm.idrr + "'", ref fm.search);
                if (fm.search.Count == 1)
                {
                    fm.search.Clear();
                    MessageBox.Show("Не забудьте по маршруту " + fm.cbrouts.Text + " зачислить водителя, так продажи на данный момент на этот маршрут приотсановлены");
                    db.Execute<Shearch>(ref sp, "select  cd.id_d from connectionr_d cd,driver d where cd.ID_D=d.ID_D and d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Уволен' where d.id_D='" + fm.search[0].id + "'", 0);
                    if (n > 0)
                    {
                       int n1= db.ExecuteNonQuery(ref sp, "update connectionr_d d set d.id_D='0' where d.id_D='" + fm.search[0].id + "'", 0);
                        if(n1>0)
                        {
                            MessageBox.Show("Изменения вступили в силу");
                        }
                    }
                }
                else
                {
                    fm.search.Clear();
                    db.Execute<Shearch>(ref sp, "select  cd.id_d from connectionr_d cd,driver d where cd.ID_D=d.ID_D and d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                    int n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Уволен' where d.id_D='" + fm.search[0].id + "'", 0);
                    if (n > 0)
                    {
                        int n1 = db.ExecuteNonQuery(ref sp, "delete   from connectionr_d  where  connectionr.id_d='" + fm.search[0].id + "'", 0);
                        if(n1>0)
                        {
                            MessageBox.Show("Изменения вступили в силу");
                        }

                    }
                }
               

            }
            else
            {
                fm.search.Clear();
                db.Execute<Shearch>(ref sp, "select  d.id_d from driver d where d.SNAME_D='" + fm.tbinfasname.Text + "' and d.Name_d='" + fm.tbinfaname.Text + "'", ref fm.search);
                int n = db.ExecuteNonQuery(ref sp, "update driver d set d.condition_d='Уволен' where d.id_D='" + fm.search[0].id + "'", 0);

            }
            fm.search.Clear();
            fm.dgvman.Rows.Clear();
            fm.dgvman.Rows.Clear();
            LoadDrivers();
            ShowDrivers();
        }
        public void LoadBuses()
        {
            fm.bus.Clear();
            db.Execute<Bus>(ref sp, "SELECT b.ID_B,b.NOMER_B,l.NAME_L,l.QUANTITY_L,l.Speed,b.Condition_B from bus b,look l where b.ID_L=l.ID_L", ref fm.bus);
        }
        public void ShowBuses()
        {
            fm.dgvman.ColumnCount= 6;
            fm.dgvman.Columns[0].HeaderText = "№";
            fm.dgvman.Columns[1].HeaderText = "Номер автобуса";
            fm.dgvman.Columns[2].HeaderText = "Марка";
            fm.dgvman.Columns[3].HeaderText = "Кол-во мест в автобусе";
            fm.dgvman.Columns[4].HeaderText = "Средняя скорость";
            fm.dgvman.Columns[5].HeaderText = "Состояние";
            fm.bus.Sort(delegate (Bus us1, Bus us2) { return us1.id.CompareTo(us2.id); });
            for (int i = 0; i < fm.bus.Count; i++)
            {
                fm.dgvman.Rows.Add(fm.bus[i].id, fm.bus[i].number, fm.bus[i].model, fm.bus[i].quantity, fm.bus[i].averagespeed,fm.bus[i].condition);
            }
                                
        }
    }
}
