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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void btnProduit_Click(object sender, EventArgs e)
        {
            openChildForm(new Groupe());
            
        }

        private void btnContra_Click(object sender, EventArgs e)
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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            openChildForm(new Enseignant());

        }

        private void btnFacture_Click(object sender, EventArgs e)
        {
            openChildForm(new Diplôme());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new compteS());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new examnote());
        }
    }
}
