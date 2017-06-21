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
using DGVPrinterHelper;

namespace autostation_v_0._1
{
    public partial class MainManeger : MetroFramework.Forms.MetroForm
    {
        public List<timetable> timetabler = new List<timetable>();
        public List<towns> town = new List<towns>();
        public List<Sales> sale = new List<Sales>();
        public List<Bttown> bttown = new List<Bttown>();
        public List<DriverCB> driverCBs = new List<DriverCB>();
        public List<DriverBus> driverBuss = new List<DriverBus>();
        public List<Shearch> search = new List<Shearch>();
        public List<SearchDouble> searchd = new List<SearchDouble>();
        public List<BusforCB> busforCB = new List<BusforCB>();
        public List<SalesBT> salesBT = new List<SalesBT>();
        public List<InformationforReport> informationforReport = new List<InformationforReport>();
        public List<Driver> driver = new List<Driver>();
        public List<Bus> bus = new List<Bus>();
        public bool change=false;
        public bool condition = false;
        public bool triggerall;
        public bool dattes = true;
        public int idrr = 0;
        public int idrrr = 0;
        public DateTime from;
        public DateTime to;
        public string s = "";
        public int idsales = 0;
        public MainManeger()
        {
            InitializeComponent();
        }



        private void MainManeger_Load(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.LoadDriverforCB();
            m.LoadDateCB();
            m.LoadDate();
            m.ShowDate();
            m.LoadBt();
            m.LoadSales();
            m.CBTowns();
            m.PricesK();
            m.FreeBuses();
            rbyes.Checked = true;
            dgvmnew.Visible = true;
            rball.Checked = true;
            rball.Enabled = false;
            rbparts.Enabled = false;
            cbtables.Text = "Маршруты";
            dgvmnew.Font = new Font("Microsoft Sans Serif", 8);
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgvmnew.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dgvmnew.Visible = false;
        }

        private void tbnew_Click(object sender, EventArgs e)
        {

        }

        private void cbto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainManeger_FormClosing(object sender, FormClosingEventArgs e)
        {
            Authorization a = new Authorization();
            a.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cbtables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbtables_TextChanged(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);

            switch (cbtables.Text)
            {
                case "Маршруты":

                    this.dgvman.Rows.Clear();
                    this.dgvman.Columns.Clear();
                    m.ShowDate();
                    tbnew.Parent = tbchange;
                    tchrout.Parent = null;
                    tprepair.Parent = null;
                    tpinfdriver.Parent = null;
                    tpinfosales.Parent = null;
                    tabPage2.Parent = null;
                    addDriver.Parent = null;
                    tbAddbuses.Parent = null;
                    button1.Text = "Распечатать Маршруты";
                    break;
                case "Продажи":
                    this.dgvman.Rows.Clear();
                    this.dgvman.Columns.Clear();
                    m.ShowSales();
                    tbnew.Parent = null;
                    tpinfdriver.Parent = null;
                    tprepair.Parent = null;
                    tchrout.Parent = null;
                    addDriver.Parent = null;
                    tbAddbuses.Parent = null;
                    tpinfosales.Parent = tbchange;
                    tabPage2.Parent = tbchange;
                   
                    button1.Text = "Распечатать Продажи";
                    break;
                case "Водители":
                    this.dgvman.Rows.Clear();
                    this.dgvman.Rows.Clear();
                    m.LoadDrivers();
                    m.ShowDrivers();
                    tpinfosales.Parent = null;
                    tprepair.Parent = null;
                    tpinfdriver.Parent = tbchange;
                    tabPage2.Parent = null;
                    tbnew.Parent = null;
                    tchrout.Parent = null;
                    tbAddbuses.Parent = null;
                    addDriver.Parent = tbchange;
                    button1.Text = "Распечатать инф. о все Водителях";
                    break;
                case "Автобусы":
                    this.dgvman.Rows.Clear();
                    this.dgvman.Rows.Clear();
                    tpinfosales.Parent = null;
                    tpinfdriver.Parent = null;
                    tabPage2.Parent = null;
                    tbnew.Parent = null;
                    tchrout.Parent = null;
                    addDriver.Parent = null;
                    m.LoadBuses();
                    m.ShowBuses();
                    tprepair.Parent = tbchange;
                    tbAddbuses.Parent = tbchange;
                    break;


            }
        }

        private void dgvman_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MethodsManager m = new MethodsManager(this);
            //int r = Convert.ToInt32(dgvman[0, dgvman.CurrentRow.Index].Value);
            //m.Check(r - 1);

        }

        private void dgvman_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvBT_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBT[0, dgvBT.CurrentRow.Index].Selected == true)
            {
                if (cbtowns.Text != "")
                {
                    dgvBT[0, dgvBT.CurrentRow.Index].Value = cbtowns.Text;
                }
            }
        }

        private void cbtowns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbrout_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ChangeRout_Click(object sender, EventArgs e)
        {
            tbchange.SelectedIndex = 1;
        }

        private void dgvman_MouseDown(object sender, MouseEventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            int r = Convert.ToInt32(dgvman[0, dgvman.CurrentRow.Index].Value);
            try {
                if (e.Button == MouseButtons.Right)
                {
                    if (dgvman.Rows.Count > 2)
                    {
                        m.Check(r - 1, r - 1);
                    }
                    else
                    {
                        m.Check(r - 1, 0);
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Проверьте соединение с базой данных");
            }
       }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dattes == true)
                {
                    if ((tbchangedistance.Text != "") && (tbchangetimeto.Text != "") && (cbchangeprice.Text != "") && (tbdays.Text != ""))
                    {
                        double d = Convert.ToDouble(cbchangeprice.Text);
                         DateTime rd = DateTime.Parse(tbchangetimeto.Text);
                        d = Convert.ToDouble(tbchangedistance.Text);
                        
                        if (rbonedriver.Checked == true)
                        {
                            if (cbDrivers.Text == "")
                            {
                                throw new System.Exception();
                            }
                        }
                        else
                        {
                            if (cbDrivers.Text == "" || cbdrivers1.Text == "")
                            {
                                throw new System.Exception();
                            }
                        }
                        string[] valdays = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
                        string[] val = tbdays.Text.Split(',');
                        bool triger = false;

                        for (int j = 0; j < val.Length; j++)
                        {
                            for (int i = 0; i < valdays.Length; i++)
                            {
                                if (val[j] == valdays[i])
                                {
                                    triger = true;
                                }
                            }
                            if (triger != true)
                            {
                                throw new System.Exception();
                            }
                            else triger = false;


                        }
                        if(d<10)
                        {
                            throw new System.Exception();
                        }
                        double g = 0;
                        if(dgvBT.Rows.Count-1>=1)
                        {
                            for (int i = 0; i < dgvBT.Rows.Count-1; i++)
                            {
                                for(int j=0;j<dgvBT.ColumnCount;j++)
                                {
                                    if (dgvBT[j, i].Value == null || dgvBT[j, i].Value.ToString() == tbchangefrom.Text || dgvBT[j, i].Value.ToString() == tbchangeto.Text)
                                    {
                                        throw new System.Exception();
                                    }
                                    
                                }
                                g = Convert.ToDouble(dgvBT[1, i].Value);
                                if(g>d)
                                {
                                    throw new System.Exception();
                                }
                            }
                        }
                        
                    }
                }
                else
                {

                    if (rbonedriver.Checked == true)
                    {
                        if (cbDrivers.Text == "")
                        {
                            throw new System.Exception();
                        }
                    }
                    else
                    {
                        if (cbDrivers.Text == "" || cbdrivers1.Text == "")
                        {
                            throw new System.Exception();
                        }
                    }
                }
                MethodsManager m = new MethodsManager(this);
                m.ChandeRout(idrrr);
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void bttmsrch_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int i = 0; i < dgvman.Rows.Count; i++)
            {
                for (int j = 0; j < dgvman.Columns.Count; j++)
                {
                    if (dgvman[j, i].Value != null)
                    {
                        if (dgvman[j, i].Value.ToString() == tbsearch.Text)
                        {
                            check = false;
                        }
                    }

                }
                if (check == true)
                {
                    dgvman.Rows.Remove(dgvman.Rows[i]);
                    check = true;
                    i--;
                }
                else check = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter dg = new DGVPrinter();
           
            
            if (cbtables.Text == "Маршруты")
            { dg.Title = "Маршрут";
                
                dg.SubTitle = System.String.Format("Дата:{0}", DateTime.Now.ToLongDateString());
                dg.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                dg.PageNumbers = true;
                dg.PageNumberInHeader = false;
                dg.PorportionalColumns = true;
                dg.HeaderCellAlignment = StringAlignment.Near;
                dg.Footer = "Автостанция \"Higway to Hell!\"";
                dg.FooterSpacing = 15;
                dg.PrintPreviewDataGridView(dgvman);
                
            }
            else if(cbtables.Text=="Продажи")
            {
                
                dg.Title = "Продажи";
                 dg.SubTitle = System.String.Format("Дата:{0}", DateTime.Now.ToLongDateString());
                dg.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                dg.PageNumbers = true;
                dg.PageNumberInHeader = false;
                dg.PorportionalColumns = true;
                dg.HeaderCellAlignment = StringAlignment.Near;
                dg.Footer = "Автостанция \"Higway to Hell!\"";
                dg.FooterSpacing = 15;
                dg.PrintPreviewDataGridView(dgvman);
               
            }
            else if(cbtables.Text=="Водители")
            {
                
                dg.Title = "Водители";
                dg.SubTitle = System.String.Format("Дата:{0}", DateTime.Now.ToLongDateString());
                dg.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                dg.PageNumbers = true;
                dg.PageNumberInHeader = false;
                dg.PorportionalColumns = true;
                dg.HeaderCellAlignment = StringAlignment.Near;
                dg.Footer = "Автостанция \"Higway to Hell!\"";
                dg.FooterSpacing = 15;
                dg.PrintPreviewDataGridView(dgvman);
                
            }
            else if(cbtables.Text=="Автобусы")
            {
                dg.Title = "Автобусы";
                dg.SubTitle = System.String.Format("Дата:{0}", DateTime.Now.ToLongDateString());
                dg.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                dg.PageNumbers = true;
                dg.PageNumberInHeader = false;
                dg.PorportionalColumns = true;
                dg.HeaderCellAlignment = StringAlignment.Near;
                dg.Footer = "Автостанция \"Higway to Hell!\"";
                dg.FooterSpacing = 15;
                dg.PrintPreviewDataGridView(dgvman);
            }

        }

        private void btaddDriver_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            try
            {
                if ((tbdrivername.Text != "") && (tbdriversecond.Text != "") && (tbdriverthird.Text != "") && (tbpasspot.Text != "") && (tbidentity.Text != "") && (tbidentity.Text != ""))
                {
                    m.AddDriver();
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
                dgvman.Rows.Clear();
                dgvman.Rows.Clear();

                m.LoadDrivers();
                m.ShowDrivers();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ИНН равен 10 символов");
            }
        }

        private void cbpk_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbAddbuses_Click(object sender, EventArgs e)
        {

        }

        private void btnaddbus_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            if ((tbbusnomber.Text != "") && (tbmodel.Text != "") && (tbsites.Text != "") && (tbaveragespeed.Text != ""))
            {
                m.AddBus();
            }
            else
            {
                MessageBox.Show("Введите данные ");
            }
            this.dgvman.Rows.Clear();
            this.dgvman.Rows.Clear();
            m.LoadBuses();
            m.ShowBuses();
        }

        private void tbsearch_TextChanged(object sender, EventArgs e)
        {
            if (tbsearch.Text == "")
            {
                dgvman.Rows.Clear();
                MethodsManager m = new MethodsManager(this);
                if (cbtables.Text == "Маршруты")
                {
                    m.ShowDate();
                }
                else if (cbtables.Text == "Продажи")
                {
                    m.ShowSales();
                }
                else if (cbtables.Text == "Водители")
                {
                    m.ShowDrivers();
                }
                else if(cbtables.Text=="Автобусы")
                {
                    m.ShowBuses();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
         
            //s += comboBox1.SelectedText;
            //if (s.Length > 2)
            //{
            //    s += "'";
            //    comboBox1.Text = s;
            //}
            //else comboBox1.Text = s;
            //if (comboBox1.Text != "")
            //{
            //    comboBox1.Text += "," + s;
            //}
            //else s += comboBox1.Text;

            //return;
           // for (int i = 0; i < comboBox1.Items.Count; i++)
           // {
           //     if(comboBox1.Text==comboBox1.Items[i].ToString())
           //     {
           //         s += comboBox1.Text+"'";
           //     }
           // }
           //comboBox1.Text = s;
        }

        private void cbnrDriver_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cbsalesto.Enabled = false;
            dtpfrm.Enabled = false;
            cbsalesfrom.Enabled = false;
            dtpto.Enabled = false;
            
           

        }

        private void rbparts_CheckedChanged(object sender, EventArgs e)
        {
            cbsalesto.Enabled = true;
            dtpfrm.Enabled = true;
            cbsalesfrom.Enabled = true;
            dtpto.Enabled = true;
            btnsalessearch.Enabled = true;
        }

        private void tpinfosales_Click(object sender, EventArgs e)
        {

        }
        public int columnid = 0;
        private void dgvman_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            columnid = e.ColumnIndex;
        }

        private void tbchange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbnrdays_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void cbfreebuses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            if ((cbto.Text != "") && (cbfrm.Text != "") && (cbfreebuses.Text != "") && (tbnrdays.Text != "") && (datearrive.Text != "") && (dateleave.Text != "") && (cbpk.Text != "") && (tbdistance.Text != "") && (cbnrDriver.Text != ""))
            {
                double r;
                DateTime rt;
                try
                {
                    string [] valdays = { "Пн","Вт","Ср","Чт","Пт","Сб","Вс" };
                    
                    r = Convert.ToDouble(cbpk.Text);
                    r = Convert.ToDouble(tbdistance.Text);

                    rt = DateTime.Parse(datearrive.Text);
                    rt = DateTime.Parse(dateleave.Text);
                    if (r < 10)
                    {
                        throw new System.Exception();
                    }
                    string[] val = tbnrdays.Text.Split(',');
                    bool triger = false;
                   
                    for (int j = 0; j < val.Length; j++)
                    {
                        for (int i = 0; i < valdays.Length; i++)
                        {
                            if(val[j]==valdays[i])
                            {
                                triger = true;
                            }
                        }
                        if (triger != true)
                        {
                            throw new System.Exception();
                        }
                        else triger = false; 
                        
                    }
                    if(rbyes.Checked==true)
                    {
                        if(dgvmnew.Rows.Count==1)
                        {
                            if ((dgvmnew[0, 1].Value == null)&&(dgvmnew[0, 2].Value == null)) throw new System.Exception();
                        }
                        double tr = 0;
                        for (int i = 0; i < dgvmnew.Rows.Count-1; i++)
                        {
                            if (dgvmnew[0, i].Value == null) throw new System.Exception();
                            else
                            {
                                tr+=Convert.ToDouble(dgvmnew[0, i].Value);
                            }
                        }
                        if (tr>Convert.ToDouble(tbdistance.Text))
                        {
                            throw new System.Exception();
                        }
                    }

                    m.AddRout();
                    this.dgvman.Rows.Clear();
                    this.dgvman.Rows.Clear();
                    m.LoadDate();
                    m.ShowDate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при проверке данных, проверьте правильность вводы");
                }

            }
            else MessageBox.Show("Все данные должны быть введены");
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lbDriver_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbprice_Click(object sender, EventArgs e)
        {

        }

        private void dgvmnew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbfrm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tchrout_Click(object sender, EventArgs e)
        {

        }

        private void tbrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvroutDriver_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Водитель_Click(object sender, EventArgs e)
        {

        }

        private void cbDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbbus_Click(object sender, EventArgs e)
        {

        }

        private void cbbuses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dgvBT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvchange_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void addDriver_Click(object sender, EventArgs e)
        {

        }

        private void tbtelephon_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void tbdriversecond_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbdriverthird_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbpasspot_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbidentity_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbdrivername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void tbsites_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbaveragespeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnrout_Click(object sender, EventArgs e)
        {

        }

        private void NewRout_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.Report();
        }

        private void btnsalessearch_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.SearchSales(idsales);
        }

       

        

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            cballroutsfrom.Enabled = true;
            cballroutsto.Enabled = true;
            dtpallroutsfrom.Enabled = true;
            dtpallroutsto.Enabled = true;
            cbbigger.Enabled = true;
            cbless.Enabled = true;
            tbbigger.Enabled = true;
            tbless.Enabled = true;

        }

        private void dtpallroutsto_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnchoise_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.LoadSales(0);
        }

        private void tballrouts_CheckedChanged(object sender, EventArgs e)
        {
            cballroutsfrom.Enabled = false;
            cballroutsto.Enabled = false;
            dtpallroutsfrom.Enabled = false;
            dtpallroutsto.Enabled = false;
            cbbigger.Enabled = false;
            cbless.Enabled = false;
            tbbigger.Enabled = false;
            tbless.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.ChangeCondition(condition);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.DeleteDriver();
        }

        private void tprepair_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MethodsManager m = new MethodsManager(this);
            m.ChangeBus();
            this.dgvman.Rows.Clear();
            this.dgvman.Rows.Clear();
            m.LoadBuses();
            m.ShowBuses();
        }

        private void tbinfaname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void tbinfasname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbinfatname_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbinfapass_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbinfaiden_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbinfanumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbidentity_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
    