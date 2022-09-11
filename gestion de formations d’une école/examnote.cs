using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_de_formations_d_une_école
{
    public partial class examnote : Form
    {
        public examnote()
        {
            InitializeComponent();
        }
        mos p = new mos();
        static DataTable dt1 = new DataTable();
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void examnote_Load(object sender, EventArgs e)
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Stagiaire", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "nom_st";
            comboBox1.ValueMember = "code_stagiaire";
            p.dr.Close();
            p.deconnecter();

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dt1.Clear();
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("exec p1 '" + comboBox1.SelectedValue + "'", p.con);
                p.dr = p.cmd.ExecuteReader();
                dt1.Load(p.dr);
                CrystalReportnote cr = new CrystalReportnote();
                cr.SetDataSource(dt1);
                crystalReportViewer1.ReportSource = cr;
                p.deconnecter();
            }
            catch
            {

            }
        }
    }
}
