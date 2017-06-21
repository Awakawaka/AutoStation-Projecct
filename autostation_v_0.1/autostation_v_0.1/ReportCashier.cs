using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.IO;
using System.Xml.Serialization;
using MetroFramework;

namespace autostation_v_0._1
{
    public partial class ReportCashier : MetroFramework.Forms.MetroForm
    {
        fm r;
        public ReportCashier(fm u)
        {
            InitializeComponent();
            r = u;
        }
        public List<Sales> sale = new List<Sales>();
        public List<SalesBT> salesBt =new  List<SalesBT>();
        public List<SearchDouble> search = new List<SearchDouble>();
        public List<ReturnTicket> rticket = new List<ReturnTicket>();
        public List<string>dgvrows= new List<string>();
        private void btncsearch_Click(object sender, EventArgs e)
        {
            if (tbsearchc.Text != "")
            {
                bool check = true;
                
                for (int i = 0; i < dgvr.Rows.Count - 1; i++)
                {
                    string st = "";
                    for (int j = 0; j < dgvr.Columns.Count; j++)
                    {
                        if (dgvr[j, i].Value != null)
                        {
                            st += dgvr[j, i].Value.ToString()+"!";
                        }

                    }
                    dgvrows.Add(st);
                }

                    for (int i = 0; i < dgvr.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvr.Columns.Count; j++)
                    {
                        if (dgvr[j, i].Value != null)
                        {
                            if (dgvr[j, i].Value.ToString() == tbsearchc.Text)
                            {
                                check = false;
                            }
                        }

                    }

                    if (check == true)
                    {
                        dgvr.Rows.Remove(dgvr.Rows[i]);
                        check = true;
                        i--;
                    }
                    else check = true;

                }
                
            }
            else MessageBox.Show("Заполните поле поиска");
        }

        private void ReportCashier_Load(object sender, EventArgs e)
        {
            MethodsReportforCashier m = new MethodsReportforCashier(this, r);
            m.LoadData();
            m.ShowSales();
            m.ShowCB();
            cbroutsr.Text = "Все";
            rballc.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodsReportforCashier m = new MethodsReportforCashier(this, r);
            m.SortSales();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    r.dgvr.Columns[0].Name = "№ маршрута";
            //    r.dgvr.Columns[1].Name = "Откуда";
            //    r.dgvr.Columns[2].Name = "Куда";
            //    r.dgvr.Columns[3].Name = "Кол-во проданных билетов";
            //    r.dgvr.Columns[4].Name = "Общая стоимость";
            //    r.dgvr.Columns[5].Name = "Кол-во возврщенных билетов на сумму";
            //    r.dgvr.Columns[6].Name = "На сумму";
            ForReportCashier fr = new ForReportCashier();
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            if((cbroutsr.Text=="Все"))
            {
                fr.routs = "По маршрутам";
                if (rballc.Checked == true)
                {
                    fr.period = startDate.ToShortDateString() + "-" + endDate.ToShortDateString();
                }
                else
                {
                    fr.period= DateTime.Now.ToShortDateString();
                }
                fr.dateofmaking = DateTime.Now.ToLongDateString();
                for (int i = 0; i < dgvr.Rows.Count-1; i++)
                {
                    fr.dg.Add(new ForDGVCahier(dgvr[0, i].Value.ToString(), dgvr[1, i].Value + "-" + dgvr[2, i].Value, dgvr[3, i].Value.ToString(), dgvr[5, i].Value.ToString(), (Convert.ToDouble(dgvr[4, i].Value)+ Convert.ToDouble(dgvr[6, i].Value)).ToString()));
                }
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(ForReportCashier));
                System.IO.StreamWriter file = new System.IO.StreamWriter("2.xml");
                writer.Serialize(file, fr);
                file.Close();
                report r = new report("ReportCashier.frx");
                r.ShowDialog();
            }
            else
            {
                InformationforReport n = new InformationforReport();

                n.rout = tbrc.Text;
                if (rballc.Checked == true)
                {
                    n.fromdate = startDate.ToShortDateString();  
                    n.todate = endDate.ToShortDateString();
                }
                else
                {
                    n.fromdate = DateTime.Now.ToShortDateString();
                    n.todate = "";
                }
                int q = 0;
                for (int i = 0; i < dgvr.Rows.Count; i++)
                {
                    q += Convert.ToInt32(dgvr[3, i].Value);

                }
                n.quantitysoldticket = q;
                n.quantityreturnticket = Convert.ToInt32(tbrtcq.Text);
                double qd = 0;
                for (int i = 0; i < dgvr.Rows.Count; i++)
                {
                    qd += Convert.ToDouble(dgvr[4, i].Value);

                }
                n.gain = Math.Round(qd + Convert.ToDouble(tbsum.Text),2);
                //fm.dgvman.Columns[0].Name = "№ маршрута";
                //fm.dgvman.Columns[1].Name = "Откуда";
                //fm.dgvman.Columns[2].Name = "Куда";
                //fm.dgvman.Columns[3].Name = "Кол-во проданных билетов";
                //fm.dgvman.Columns[4].Name = "Общая стоимость";
                for (int i = 0; i < dgvr.Rows.Count - 1; i++)
                {
                    n.a.Add(new DGVforReport(dgvr[1, i].Value.ToString()+"-"+ dgvr[2, i].Value.ToString(), Convert.ToInt32(dgvr[3, i].Value), Convert.ToDouble(dgvr[4, i].Value)));
                }
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(InformationforReport));
                System.IO.StreamWriter file = new System.IO.StreamWriter("1.xml");
                writer.Serialize(file, n);
                file.Close();
                report r = new report("ReportSales.frx");
                r.Show();
            }
        }

        private void cbroutsr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbroutsr.Text!="Все")
            {
                label1.Visible = true;
                label2.Visible = true;
                lbrtc.Visible = true;
                tbsum.Visible = true;
                tbrc.Visible = true;
                tbrtcq.Visible = true;
                tbrc.Text = cbroutsr.Text;
                tbsum.Text = "";
                tbrtcq.Text = "";
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                lbrtc.Visible = false;
                tbsum.Visible = false;
                tbrc.Visible = false;
                tbrtcq.Visible = false;
                tbrc.Text = "";
                tbsum.Text = "";
                tbrtcq.Text = "";
            }
        }

        private void tbsearchc_TextChanged(object sender, EventArgs e)
        {
            if(tbsearchc.Text=="")

            {
                dgvr.Rows.Clear();
                for (int i = 0; i < dgvrows.Count; i++)
                {
                    string[] val = dgvrows[i].Split('!');
                    if(cbroutsr.Text=="Все")
                    {
                        dgvr.Rows.Add(val[0], val[1], val[2], val[3], val[4], val[5], val[6]);
                    }
                    else
                    {
                        dgvr.Rows.Add(val[0], val[1], val[2], val[3], val[4], val[5]);
                    }
                }
                dgvrows.Clear();
            }

        }
    }
}
