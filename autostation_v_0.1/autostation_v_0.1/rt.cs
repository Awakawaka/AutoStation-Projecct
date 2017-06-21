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
    public partial class rt : MetroFramework.Forms.MetroForm
    {
        public rt()
        {
            InitializeComponent();
        }
        public List<ticket> tick = new List<ticket>();
        public List<towns> town = new List<towns>();
        public   List<FreeSites> forsearch = new List<FreeSites>();

        private void button1_Click(object sender, EventArgs e)
        {
            MethodsRT m = new MethodsRT(this);
            m.Search();
        }

        private void rt_Load(object sender, EventArgs e)
        {
            btnrt.Enabled = false;
        }

        private void btnrt_Click(object sender, EventArgs e)
        {
            MethodsRT m = new MethodsRT(this);
            m.deletesites();
        }
    }
}
