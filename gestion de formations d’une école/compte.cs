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
    public partial class compte : Form
    {
        mos p = new mos();
        static DataTable dt1 = new DataTable();
        //
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(Login) from compte where Login='" + textBox2.Text + "' and mot_de_passe='" + textBox1.Text + "'", p.con); ;
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public compte()
        {
            InitializeComponent();
        }

        private void compte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count() != 0)
            {
                string cpt;
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("select Type_User from compte where Login='" + textBox2.Text + "' and mot_de_passe='" + textBox1.Text + "'", p.con); ;
                cpt = (string)p.cmd.ExecuteScalar();
                if (cpt == "Administrateur")
                {
                    p.deconnecter();
                    Form1 a = new Form1();
                    a.Show();
                    this.Close();

                }
                if (cpt == "Direction")
                {
                    p.deconnecter();
                    Form2 b = new Form2();
                    b.Show();
                    this.Close();

                }
                if (cpt == "Surveillante")
                {
                    p.deconnecter();
                    Form3 c = new Form3();
                    c.Show();
                    this.Close();

                }
                if (cpt == "Enseignants")
                {
                    p.deconnecter();
                    Form4 ee = new Form4();
                    ee.Show();
                    this.Close();

                }
            }
            MessageBox.Show("mot de passe ou login incorrect");
            p.deconnecter();


        }
    }
}
