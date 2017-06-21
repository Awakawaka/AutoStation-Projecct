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

namespace autostation_v_0._1
{
    public partial class fmt : MetroFramework.Forms.MetroForm
    {
        public int counter = 0;
        public fm t;
        public DialogResult resultforMethodsFMT;
        public string p;
        public int forcase = 0;
        public InformationforCheck inf = new InformationforCheck();
        public fmt(fm f, int counter1, DialogResult resultfromfm, string fromfm)
        {
            InitializeComponent();
            t = f;
            counter = counter1;
            resultforMethodsFMT = resultfromfm;
            p = fromfm;
            btncheck.Enabled = false;

        }


        private void fmt_Load(object sender, EventArgs e)
        {
            MethodsFMT m = new MethodsFMT(this, t, counter, resultforMethodsFMT, p);
            if (resultforMethodsFMT != DialogResult.No)
            {

                m.ShowInfo();
            }
            else m.ShowInfo(0);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int u = 0;
        public string id;
        //ClassDataBase db = new ClassDataBase();
        //ClassSetupProgram sp = new ClassSetupProgram();
        //public List<ticket> ticket = new List<ticket>();
        //public void LoadData()
        //{
        //    ClassDataBase db = new ClassDataBase();
        //    db.Execute<ticket>(ref sp, "select ns_t from ticket", ref ticket);
        //}

        private void btnntckt_Click(object sender, EventArgs e)
        {
            MethodsFMT m = new MethodsFMT(this, t, counter);
            m.InsertTicket();
           
            if (tbtotalgain.Text != "")
            {
                tbtotalgain.Text = (Convert.ToDouble(tbprice.Text) * 2).ToString();
            }
            else tbtotalgain.Text = Convert.ToDouble(tbprice.Text).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //if (!tbstng.Text.Equals(""))
            //{

            //}
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnchet_Click(object sender, EventArgs e)
        {
            if ((tbcustom.Text != "") || (tbtotalgain.Text != ""))
            {
                try
                {
                    double price = Convert.ToDouble(tbtotalgain.Text);
                    double custom = Convert.ToDouble(tbcustom.Text);
                    if((custom>0)&& (custom>=price))
                    {
                        double left =  custom-price;
                        tbleft.Text = (left).ToString();
                        btncheck.Enabled = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Вводите корректные значения");
                }
            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(InformationforCheck));
            System.IO.StreamWriter file = new System.IO.StreamWriter("3.xml");
            writer.Serialize(file, inf);
            file.Close();
            report r = new report("ReportTIcket.frx");
            r.Show();
        }

        private void tbtotalgain_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
