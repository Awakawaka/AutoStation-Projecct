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
    public partial class Authorization : MetroFramework.Forms.MetroForm
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            fm fm = new fm();
           
            fm.Show();
            this.Visible=false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainManeger mm = new MainManeger();
            mm.Show();
            this.Visible = false;
        }

        private void Authorization_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
