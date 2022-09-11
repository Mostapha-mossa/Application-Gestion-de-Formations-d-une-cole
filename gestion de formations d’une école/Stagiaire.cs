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
    public partial class Stagiaire : Form
    {
        public Stagiaire()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_stagiaire) from Stagiaire where code_stagiaire='" + textBox1.Text + "' ", p.con);
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
                p.cmd.CommandText = "update Stagiaire set DateNaiss='" + dt1 + "',nom_st='" + textBox2.Text + "',adress_st='" + textBox4.Text + "',email_st='" + textBox5.Text + "',prenom_st='" + textBox3.Text + "',tel='" + maskedTextBox1.Text + "',Diplôme='" + textBox7.Text + "',genre='" + textBox6.Text + "',codegrp='" + comboBox1.SelectedValue + "' where code_stagiaire='" + textBox1.Text + "'";
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
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Stagiaire values ('" +textBox1.Text +"','"+ textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','','" + textBox5.Text + "','"+ textBox6.Text + "','"+maskedTextBox1.Text+"','"+dt1+"','"+ textBox7.Text + "','"+comboBox1.SelectedValue+"')", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Groupe", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "Nom_Groupe";
            comboBox1.ValueMember = "Code_groupe";
            p.dr.Close();
            p.deconnecter();
        }
        public bool supprimer()
        {

            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from Stagiaire where code_stagiaire='" + textBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;


        }

        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Stagiaire'", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }

        public void chagedgvbygroup()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Stagiaire where codegrp='" + comboBox1.SelectedValue + "' ", p.con);
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

        private void Stagiaire_Load(object sender, EventArgs e)
        {
            chagedgv();
            combo1();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text!="")
            {
                chagedgvbygroup();
            }
            else
            {
                MessageBox.Show("veuillez sélectionner le groupe!");
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
    }
}
