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
    public partial class inscriptions : Form
    {
        public inscriptions()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_stagiaire) from Inscription where code_stagiaire='" + comboBox1.SelectedValue + "' AND Code_groupe='" + comboBox2.SelectedValue + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Inscription values ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + dt1 + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //
        public bool modifier()
        {
            if (count() != 0)
            {
                p.connecter();
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);
                p.cmd.CommandText = "update Inscription set dateInscription='" + dt1 + "' where code_stagiaire='" + comboBox1.SelectedValue + "' AND Code_groupe='" + comboBox2.SelectedValue + "''";
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //
        public bool supprimer()
        {

            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from Inscription where code_stagiaire='" + comboBox1.SelectedValue + "' AND Code_groupe='" + comboBox2.SelectedValue + "'", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Stagiaire", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "nom_st";
            comboBox1.ValueMember = "code_stagiaire";
            p.dr.Close();
            p.deconnecter();
        }
        public void combo2()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Groupe", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox2.DataSource = p.dt;
            comboBox2.DisplayMember = "Nom_Groupe";
            comboBox2.ValueMember = "Code_groupe";
            p.dr.Close();
            p.deconnecter();
        }

        public void chagedgvbygroup()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Inscription where Code_groupe='" + comboBox2.SelectedValue + "' ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }

        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Inscription", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        private void inscriptions_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            chagedgv();
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                chagedgvbygroup();
            }
            else
            {
                MessageBox.Show("veuillez sélectionner le groupe!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
