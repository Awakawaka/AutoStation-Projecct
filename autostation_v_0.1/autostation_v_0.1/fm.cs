using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MySql.Data.MySqlClient;
using GMap.NET.WindowsForms;

namespace autostation_v_0._1
{
    public partial class fm : MetroFramework.Forms.MetroForm
    {

        public fm()
        {

            InitializeComponent();


        }

        public List<timetable> list1 = new List<timetable>();
        public List<towns> ttowns = new List<towns>();
        public List<Shearch> search1 = new List<Shearch>();
        public List<FreeSites> forsearch = new List<FreeSites>();
        
        public DateTime was = DateTime.Now;
        bool onsearch=false;
        public int id;


        private void fm_Load(object sender, EventArgs e)
        {
            Methods m = new Methods(this);
            m.LoadData();
            m.LoadDataCB();
            m.ShowDate();
            m.ShowDataCB();
            was = was.ToLocalTime();
            mcm.MinDate = DateTime.Now;
            mcm.MaxDate = DateTime.Now.AddDays(13);
            dtpm.MinDate= DateTime.Now;
            dtpm.MaxDate= DateTime.Now.AddDays(13);

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        public DialogResult result;
        public int iddate;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(e.ColumnIndex.ToString());
            //MessageBox.Show(dgvm.SelectedCells[0].Value.ToString());
            int r = Convert.ToInt32(dgvm[0, dgvm.CurrentRow.Index].Value);
            id = dgvm.CurrentRow.Index;
            int columnid = e.ColumnIndex;
            Methods m = new Methods(this);
            if (columnid == 7)
            {
                if (onsearch == true)
                {

                    result = MessageBox.Show("Билет оформлять по пунктам из поиска?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (cbd.Checked == true)
                        {
                            if (dtpm.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                            {
                                if (((DateTime.Now.Hour > DateTime.Parse(dgvm[4, dgvm.CurrentRow.Index].Value.ToString()).Hour) && (DateTime.Now.Hour < DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour))|| DateTime.Now.Hour > DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour)

                                {
                                    MessageBox.Show("Билет оформить не возможно так как маршрут уже в пути");
                                    
                                }
                                else
                                {
                                    iddate = m.SearchDate(dtpm.Value, r - 1);
                                    fmt f = new fmt(this, r - 1, result, dtpm.Value.ToShortDateString());
                                    f.ShowDialog();
                                }
                            }
                            else
                            {
                                iddate = m.SearchDate(dtpm.Value, r - 1);
                                fmt f = new fmt(this, r - 1, result, dtpm.Value.ToShortDateString());
                                f.ShowDialog();
                            }
                        }
                        else MessageBox.Show("Оформление билета по пунктам из поиска можно осуществить только если поиск совершлася с учетом даты!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (dgvm.Rows[dgvm.CurrentRow.Index].DefaultCellStyle.BackColor == System.Drawing.Color.LightCoral)
                        {
                            if (mcm.SelectionStart.ToShortDateString() == DateTime.Now.ToShortDateString())
                            {  if (((DateTime.Now.Hour > DateTime.Parse(dgvm[4, dgvm.CurrentRow.Index].Value.ToString()).Hour) && (DateTime.Now.Hour < DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour)) || DateTime.Now.Hour >= DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour)
                                {
                                    MessageBox.Show("Билет оформить не возможно так как маршрут уже в пути");
                                }
                            else
                                {
                                    iddate = m.SearchDate(mcm.SelectionStart, r - 1);
                                    fmt f = new fmt(this, r - 1, result, mcm.SelectionStart.ToShortDateString());
                                    f.ShowDialog();
                                    MessageBox.Show("Билет оформить не возможно так как маршрут уже в пути");
                                }
                            }
                            else
                            {
                                result = DialogResult.No;
                                iddate = m.SearchDate(mcm.SelectionStart, r - 1);
                                fmt f = new fmt(this, r - 1, result, mcm.SelectionStart.ToShortDateString());
                                f.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберете дату");
                        }
                    }

                    onsearch = false;
                }
                else
                {
                    if (dgvm.Rows[dgvm.CurrentRow.Index].DefaultCellStyle.BackColor == System.Drawing.Color.LightCoral)
                    {
                        if (mcm.SelectionStart.ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            if (((DateTime.Now.Hour > DateTime.Parse(dgvm[4, dgvm.CurrentRow.Index].Value.ToString()).Hour) && (DateTime.Now.Hour < DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour)) || DateTime.Now.Hour >= DateTime.Parse(dgvm[5, dgvm.CurrentRow.Index].Value.ToString()).Hour)
                            {
                                MessageBox.Show("Билет оформить не возможно так как маршрут уже в пути");
                            }
                            else
                            {
                                result = DialogResult.No;
                                iddate = m.SearchDate(mcm.SelectionStart, r - 1);
                                fmt f = new fmt(this, r - 1, result, mcm.SelectionStart.ToShortDateString());
                                f.ShowDialog();
                               
                            }
                        }
                        else
                        {
                            result = DialogResult.No;
                            iddate = m.SearchDate(mcm.SelectionStart, r - 1);
                            fmt f = new fmt(this, r - 1, result, mcm.SelectionStart.ToShortDateString());
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберете дату");
                    }
                }
            }
            else if(columnid==8)
            {
                WholeRout wr = new WholeRout(r-1, this);
                wr.ShowDialog();
            }
        }

       

        private void btnntckt_Click(object sender, EventArgs e)
        {

        }

        private void bttnmrpt_Click(object sender, EventArgs e)
        {
            ReportCashier r = new ReportCashier(this);
            r.ShowDialog();
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        public void Answear()
        {
            if (search1.Count == 0)
            {
                MessageBox.Show("Такого маршрута/участка не найденно");
                onsearch = false;
                Methods m = new Methods(this);
                list1.Clear();
                m.LoadData();
                m.ShowDate();
            }
            else
            {
                onsearch = true;
            }
        }

        private void bttmsrch_Click(object sender, EventArgs e)
        {
            search1.Clear();
            if ((cbt.Text != "") && (cbxf.Text != ""))
            {
                if (cbt.Text != cbxf.Text)
                {
                    if ((cbt.Text == "") && (cbxf.Text == "") && (cbf.Checked == true) && (cb2.Checked == true))
                    {
                        MessageBox.Show("Введите города");
                    }
                    else if ((cbt.Text != "") && (cbf.Checked == false) && (cb2.Checked == true))
                    {
                        if (cbd.Checked == false)
                        {
                            MessageBox.Show("Поиск будет осуществлен только по пункту приезда");
                            Methods m = new Methods(this);
                            m.Search(cbt.Text, 1);

                        }
                        else
                        {
                            MessageBox.Show("Поиск будет осуществлен только по пункту приезда и по дате");
                            Methods m = new Methods(this);
                            m.SearchDate(cbt.Text);

                        }
                    }
                    else if ((cbxf.Text != "") && (cbf.Checked == true) && (cb2.Checked == false))
                    {
                        if (cbd.Checked == false)
                        {
                            MessageBox.Show("Поиск будет осуществлен только по пункту отправления");
                            Methods m = new Methods(this);
                            m.SearchFrom(cbxf.Text);
                        }
                        else
                        {
                            MessageBox.Show("Поиск будет осуществлен только по пункту отправления и дате");
                            Methods m = new Methods(this);
                            m.SearchFrom(cbxf.Text, dtpm.Text);
                        }
                    }
                    else if ((cbf.Checked == true) && (cb2.Checked = true) && (cbxf.Text != "") && (cbt.Text != ""))
                    {
                        if (cbd.Checked == false)
                        {

                            Methods m = new Methods(this);
                            m.SearchFromTo(cbxf.Text, cbt.Text);
                        }
                        else
                        {
                            Methods m = new Methods(this);
                            m.Search(cbxf.Text, cbt.Text);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете совершать поиск по одинаковым пунктам");
                }
            }
            else { MessageBox.Show("Введите пункты!"); }    

            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnall_Click(object sender, EventArgs e)
        {
            Methods m = new Methods(this);
            dgvm.Rows.Clear();
            m.ShowDate();
            
        }

        private void fm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization a = new Authorization();
                a.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            for (int i = 0; i < dgvm.Rows.Count; i++)
            {
                dgvm.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            for (int i = 0; i < dgvm.Rows.Count; i++)

            {
                if(dgvm[3,i].Value.ToString().IndexOf(mcm.SelectionStart.ToString("ddd"))!=-1)
                {
                    dgvm.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                }
            }
        }

        private void btnmrtkt_Click(object sender, EventArgs e)
        {
            rt r = new rt();
            r.ShowDialog();
        }
    }
}

