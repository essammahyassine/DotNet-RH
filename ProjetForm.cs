using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Data.Entity;

namespace KglinkRH
{
    public partial class ProjetForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public ProjetForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        int d;
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try{
            Projet f = new Projet();
            f.Code_Projet = textBoxX1.Text;
            f.Nom_Projet = textBoxX2.Text;
            f.Prime_Projet = double.Parse(textBoxX3.Text);
            f.valide = true;
            dc.Projet.AddObject(f);
            dc.SaveChanges();
            new FormAjoutsucces().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
            textBoxX1.Clear();
            textBoxX2.Clear();
            textBoxX3.Clear();
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                string a=textBox7.Text;
                var req = (from t in dc.Projet where t.Nom_Projet == a select t).SingleOrDefault();
                textBoxX1.Text=req.Code_Projet;
                textBoxX2.Text=req.Nom_Projet;
                textBoxX3.Text=req.Prime_Projet.ToString();
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                var req = (from t in dc.Projet where t.Nom_Projet == a || t.ID_projet == d select t).SingleOrDefault();
                req.Code_Projet = textBoxX1.Text;
                req.Nom_Projet=textBoxX2.Text;
                req.Prime_Projet=float.Parse(textBoxX3.Text);
                dc.SaveChanges();
                new FormModification().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
            var req = (from t in dc.Projet where t.valide==true select t).ToList();
            dataGridViewX1.DataSource = req;
            }
            catch { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                var req = (from t in dc.Projet where t.Nom_Projet==a || t.ID_projet == d select t).SingleOrDefault();
                req.valide = false;
                dc.SaveChanges();
                new FormSupression().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
            this.Hide();
            }
            catch { }
        }

        private void ProjetForm_Load(object sender, EventArgs e)
        {
            try
            {
                var req = (from t in dc.Projet where t.valide == true select t).ToList();
                labelX17.Text = req.Count().ToString();
                dataGridViewX1.DataSource = req;
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Hide();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_projet"].Value.ToString());

                textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Code_Projet"].Value.ToString();

                textBoxX2.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Nom_Projet"].Value.ToString();
                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Prime_Projet"].Value.ToString();

                
            }
            catch { }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}