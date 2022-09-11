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
    public partial class Affecation : Form
    {
        public Affecation()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_mod) from Affecation where code_mod='" + comboBox1.SelectedValue + "' AND code_fil='" + comboBox2.SelectedValue + "' AND code_Ens='" + comboBox3.SelectedValue + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);

                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into Affecation values ('" + comboBox3.SelectedValue + "','" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue  + "','" + dt1 + "')", p.con);
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
                DateTime dt1 = DateTime.Parse(dateTimePicker1.Text);

                p.connecter();
                p.cmd.CommandText = "update Affecation set date_affectation='" + dt1 + "' where code_mod='" + comboBox1.SelectedValue + "' AND code_fil='" + comboBox2.SelectedValue + "' AND code_Ens='" + comboBox3.SelectedValue + "'";
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
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from Affecation where code_mod='" + comboBox1.SelectedValue + "' AND code_fil='" + comboBox2.SelectedValue + "' AND code_Ens='" + comboBox3.SelectedValue + "'", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Affecation", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }

        public void combo1()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Module", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "Intitulé_mod";
            comboBox1.ValueMember = "code_mod";
            p.dr.Close();
            p.deconnecter();
        }
        public void combo2()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Filière", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox2.DataSource = p.dt;
            comboBox2.DisplayMember = "nom_Fil";
            comboBox2.ValueMember = "code_Fil";
            p.dr.Close();
            p.deconnecter();
        }
        public void combo3()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from Enseignant", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox3.DataSource = p.dt;
            comboBox3.DisplayMember = "nom";
            comboBox3.ValueMember = "code_Ens";
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

        private void Affecation_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
            combo3();
            chagedgv();
        }
    }
}
