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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnContra_Click(object sender, EventArgs e)
        {
            openChildForm(new compteS());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Niveau());
        }

        private void btnville_Click(object sender, EventArgs e)
        {
            openChildForm(new Secteur());

        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            openChildForm(new Filière());

        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            openChildForm(new Groupe());

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            openChildForm(new Enseignant());

        }

        private void btnFacture_Click(object sender, EventArgs e)
        {
            openChildForm(new Diplôme());

        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Stagiaire());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new inscriptions());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Absence());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Examen());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new examnote());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Module());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new ModuleFiliere());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Affecation());
        }
    }
}
