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
    public partial class Enseignant : Form
    {
        public Enseignant()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_Ens) from Enseignant where code_Ens='" + textBox1.Text + "' ", p.con);
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
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Enseignant values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox8.Text + "','" + dt1 + "','','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "')", p.con);
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
                p.cmd.CommandText = "update Enseignant set dateNaissance='" + dt1 + "',nom='" + textBox2.Text + "',cin='" + textBox8.Text + "',adresse='" + textBox4.Text + "',email='" + textBox5.Text + "',prenom='" + textBox3.Text + "',tel='" + maskedTextBox1.Text + "',Diplôme='" + textBox7.Text + "',grade='" + textBox6.Text + "',statut='" + comboBox1.Text + "' where code_Ens='" + textBox1.Text + "'";
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
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from Enseignant where code_Ens='" + textBox1.Text + "'", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Enseignant '" , p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }


        public void chagedgvSTA()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Enseignant where statut='" + comboBox1.Text + "' ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Enseignant_Load(object sender, EventArgs e)
        {
            chagedgv();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (comboBox1.Text != "")
            {
                chagedgvSTA();
            }
            else
            {
                MessageBox.Show("veuillez sélectionner le statut!");
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
    }
}
