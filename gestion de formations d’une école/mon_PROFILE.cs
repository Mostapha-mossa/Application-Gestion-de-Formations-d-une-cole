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
    public partial class mon_PROFILE : Form
    {
        public mon_PROFILE()
        {
            InitializeComponent();
        }
        mos p = new mos();
        static DataTable dt1 = new DataTable();
        //
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_Ens) from Enseignant where code_Ens='" + comboBox1.SelectedValue +  "' ", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        //
        public bool modifier()
        {
            if (count() != 0)
            {
                p.connecter();
                DateTime dt1 = DateTime.Parse(dateTimePicker2.Text);
                p.cmd.CommandText = "update Enseignant set dateNaissance='" + dt1 + "',nom='" + textBox2.Text+ "',adresse='" + textBox4.Text + "',email='" + textBox3.Text + "',prenom='" + textBox1.Text + "',tel='" + maskedTextBox1.Text + "',Diplôme='" + textBox5.Text + "',grade='" + textBox6.Text + "',statut='" + comboBox2.Text + "' where code_Ens='" + comboBox1.SelectedValue  + "'";
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //



        public void combo1()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Enseignant", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "cin";
            comboBox1.ValueMember = "code_Ens";
            p.dr.Close();
            p.deconnecter();
        }
     



        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Enseignant where code_Ens='" + comboBox1.SelectedValue + "' ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mon_PROFILE_Load(object sender, EventArgs e)
        {
            combo1();
            chagedgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (modifier() == true)
            {
                MessageBox.Show("Bien Modifier!");
                chagedgv();
            }
            else
            {
                MessageBox.Show("N'existe pas!");
            }
        }
    }
}
