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
    public partial class Filière : Form
    {
        public Filière()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_Fil) from Filière where code_Fil='" + textBox1.Text + "' ", p.con);
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
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);

                p.cmd.CommandText = "update Filière set CoeNiveau='" + comboBox1.SelectedValue + "',code_secteur='" + comboBox2.SelectedValue + "',nom_Fil='" + textBox2.Text + "',date_Création='" + dt1 + "' where code_Fil='" + textBox1.Text + "'";
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //

        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Filière values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedValue + "','" + dt1 + "','" + comboBox2.SelectedValue + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }


        public bool supprimer()
        {

            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from Filière where code_Fil='" + textBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;


        }
        public void combo1()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Niveau", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "intitué_niveau";
            comboBox1.ValueMember = "Code_niveau";
            p.dr.Close();
            p.deconnecter();
        }
        public void combo2()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Secteur", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox2.DataSource = p.dt;
            comboBox2.DisplayMember = "intitulé_sect";
            comboBox2.ValueMember = "code_sect";
            p.dr.Close();
            p.deconnecter();
        }
        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière'", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        public void chagedgvbNIVE()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière where CoeNiveau='" + comboBox1.SelectedValue + "' ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();

        }
        public void chagedgvbSECTEUR()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière where code_secteur='" + comboBox2.SelectedValue + "' ", p.con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool vide = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && ((TextBox)c).Text == "")
                {
                    vide = true;
                }
            }
            if (vide)
            {
                MessageBox.Show("Merci de Remplir Tous les champs");
            }
            else
            {
                if (ajouter() == true)
                {
                    MessageBox.Show("Bien Ajouter!");
                    chagedgv();
                }
                else
                {
                    MessageBox.Show("Existe Deja!");
                }
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (supprimer() == true)
                {
                    MessageBox.Show("Bien Supprimer!");
                    chagedgv();
                }
                else
                {
                    MessageBox.Show("N'existe pas!");
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                chagedgvbSECTEUR();
            }
            else
            {
                MessageBox.Show("veuillez sélectionner le Secteur!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                chagedgvbNIVE();
            }
            else
            {
                MessageBox.Show("veuillez sélectionner le Niveau!");
            }
        }

        private void Filière_Load(object sender, EventArgs e)
        {
            chagedgv();
            combo1();
            combo2();

        }
    }
}
