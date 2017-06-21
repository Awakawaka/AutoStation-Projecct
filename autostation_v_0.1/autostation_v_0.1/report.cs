using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport;

namespace autostation_v_0._1
{
    public partial class report : Form
    {
        string s = "";
        public report(string name)

        {
            InitializeComponent();
            s = name;
        }
        Report repor = new Report();
        FastReport.Preview.PreviewControl control = new FastReport.Preview.PreviewControl();
        private void Print_ticket_Load(object sender, EventArgs e)
        {



            repor = Report.FromFile(s);
            repor.Preview = control;
            repor.Show();
            control.Size = new Size(this.Size.Width, this.Size.Height);
            this.Controls.Add(control);
        }
    }
}
