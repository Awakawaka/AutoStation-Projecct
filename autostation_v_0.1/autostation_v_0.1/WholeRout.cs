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
    public partial class WholeRout : MetroFramework.Forms.MetroForm
    {
        public int id;
        ClassSetupProgram sp = new ClassSetupProgram();
        ClassDataBase db = new ClassDataBase();
      public  List<Bttown> town = new List<Bttown>();
       public List<Shearch> search = new List<Shearch>();
      public   List<SearchDouble> searchd = new List<SearchDouble>();


        fm t;
        public WholeRout(int index,fm r)
        {
            id = index;
            InitializeComponent();
            t = r; 
        }
        public void LoadData()
        {
            dgvwholer.Rows.Clear();
            dgvwholer.Columns.Clear();
            dgvwholer.ColumnCount = 3;

            dgvwholer.Columns[0].HeaderText = "Город";
            dgvwholer.Columns[1].HeaderText = "Цена";
            dgvwholer.Columns[2].HeaderText = "Время";
            db.Execute<Shearch>(ref sp, "select b.id_bt from btown b, rout r where b.id_r=r.id_r and r.id_r='" + t.list1[id].id + "'", ref search);
            if(search.Count==0)
            {
                dgvwholer.Rows.Add( t.list1[id].str_tw,0,t.list1[id].date_str);
                dgvwholer.Rows.Add(t.list1[id].end_tw, t.list1[id].price, t.list1[id].date_end);
            }
            else
            {
                
                dgvwholer.Rows.Add(t.list1[id].str_tw, 0, t.list1[id].date_str);
                db.Execute<Bttown>(ref sp, "select t.id_t,t.NAME_T, b.distance_bt from btown b,town t, rout r where r.id_r=b.ID_R and t.ID_T=b.id_t and r.ID_R='" + t.list1[id].id + "'", ref town);
                
                DateTime tr = DateTime.Parse(t.list1[id].date_str);
                db.Execute<SearchDouble>(ref sp, "SELECT  l.speed from look l, rout r,town t, bus b, connectionr_d cd where  cd.id_r=r.ID_R and cd.ID_B=b.ID_B and b.ID_L=l.ID_L and r.ID_R='"+t.list1[id].id+"'", ref searchd);
                for (int i = 0; i <town.Count; i++)
                {
                    dgvwholer.Rows.Add(town[i].t_name, Convert.ToDouble(town[i].distance) * t.list1[id].id_price, tr.AddHours(Convert.ToDouble(town[i].distance) / searchd[0].id).ToLongTimeString());
                }
                dgvwholer.Rows.Add(t.list1[id].end_tw, t.list1[id].price, t.list1[id].date_end);
            }

            //    db.Execute<towns>(ref sp, "select t.id_t,t.NAME_T from rout r, free_s fs, town t where r.id_r=fs.ID_R and t.ID_T=fs.id_t and r.ID_R='" + t.list1[id].id + "'", ref town);
            searchd.Clear();
            town.Clear();
            search.Clear();
        }
        public void ShowData()
        {
            
        }

        private void WholeRout_Load(object sender, EventArgs e)
        {
            LoadData();
            ShowData();
        }
    }
}
