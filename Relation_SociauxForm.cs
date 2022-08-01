using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;

namespace KglinkRH
{
    public partial class Relation_SociauxForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Relation_SociauxForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        int d;
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Relations_Sociaux r = new Relations_Sociaux();
                r.Code_Entreprise = textBoxX1.Text;
                r.Nom_Entreprise = textBoxX2.Text;
                r.Date_debut_convention = dateTimePicker1.Value.ToShortDateString();
                r.Date_fin_convention = dateTimePicker2.Value.ToShortDateString();
                r.Produit = textBoxX3.Text;
                r.Remise = int.Parse(textBoxX4.Text);
                r.Description = textBoxX5.Text;
                r.Valide = true;
                dc.Relations_Sociaux.AddObject(r);
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
                dateTimePicker1.Value=DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBoxX3.Clear();
                textBoxX4.Clear();
                textBoxX5.Clear();
                
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                string a=textBox7.Text;
                var req = (from t in dc.Relations_Sociaux where t.Nom_Entreprise == a  select t).SingleOrDefault();
                textBoxX1.Text=req.Code_Entreprise;
                textBoxX2.Text=req.Nom_Entreprise;
                dateTimePicker1.Value = DateTime.Parse(req.Date_debut_convention);
                dateTimePicker2.Value=DateTime.Parse(req.Date_fin_convention);
                textBoxX3.Text=req.Produit;
                textBoxX4.Text=req.Remise.ToString();
                textBoxX5.Text=req.Description;
                
                
            }
            catch { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                //string a = textBox7.Text;
                var req = (from t in dc.Relations_Sociaux where t.ID_entreprise == d select t).SingleOrDefault();
                req.Valide = false;
                dc.SaveChanges();

            new FormSupression().ShowDialog();
               
            }
            
            
            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                
                var req = (from t in dc.Relations_Sociaux where t.ID_entreprise == d select t).SingleOrDefault();
                req.Code_Entreprise = textBoxX1.Text;
                req.Nom_Entreprise = textBoxX2.Text;
                dateTimePicker1.Value = DateTime.Parse(req.Date_debut_convention);
                dateTimePicker2.Value = DateTime.Parse(req.Date_fin_convention);
                req.Produit = textBoxX3.Text;
                req.Remise = int.Parse(textBoxX4.Text);
                req.Description = textBoxX5.Text;
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
                
                var req = (from t in dc.Relations_Sociaux where t.Valide == true select t).ToList();
                dataGridViewX1.DataSource = req;
               

            }
            catch { }
        }

        private void Relation_SociauxForm_Load(object sender, EventArgs e)
        {
            try
            {

                var req = (from t in dc.Relations_Sociaux where t.Valide == true select t).ToList();
                dataGridViewX1.DataSource = req;


            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_entreprise"].Value.ToString());

                textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Code_Entreprise"].Value.ToString();
                textBoxX2.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Nom_Entreprise"].Value.ToString();
                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Produit"].Value.ToString();

                dateTimePicker1.Value = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["Date_debut_convention"].Value.ToString());
                dateTimePicker2.Value= DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["Date_fin_convention"].Value.ToString());
                textBoxX4.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Remise"].Value.ToString();
                textBoxX5.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                         
                
                
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Hide();
        }
    }
}