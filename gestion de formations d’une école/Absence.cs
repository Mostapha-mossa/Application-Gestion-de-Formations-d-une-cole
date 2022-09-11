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
    public partial class Absence : Form
    {
        public Absence()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_stagiaire) from Absence where code_stagiaire='" + comboBox1.SelectedValue + "' AND code_mod='" + comboBox2.SelectedValue + "' AND code_Absence='" + textBox2.Text + "' ", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();
                DateTime dt1 = DateTime.Parse(dateTimePicker2.Text);
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Absence values ('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + textBox2.Text + "','"+ maskedTextBox1.Text + "','" + textBox1.Text + "','" + dt1 + "')", p.con);
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
                DateTime dt1 = DateTime.Parse(dateTimePicker2.Text);
                p.cmd.CommandText = "update Absence set date_affectation='" + dt1 + "',Nbr_heure='" + textBox1.Text + "',Heure_abs='" + maskedTextBox1.Text + "' where code_stagiaire='" + comboBox1.SelectedValue + "' AND code_mod='" + comboBox2.SelectedValue  +"' AND code_Absence='" + textBox2.Text + "''";
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Module", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox2.DataSource = p.dt;
            comboBox2.DisplayMember = "Intitulé_mod";
            comboBox2.ValueMember = "code_mod";
            p.dr.Close();
            p.deconnecter();
        }



        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Absence", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        private void Absence_Load(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
