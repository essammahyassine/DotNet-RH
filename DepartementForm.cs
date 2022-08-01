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
    public partial class DepartementForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        GestionRHEntities7 dc = new GestionRHEntities7();
        int d;
        public DepartementForm()
        {
            InitializeComponent();
        }
        
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Departement p = new Departement();
                p.Code_depart = textBoxX1.Text;
                p.Nom_depart = textBoxX2.Text;
                p.ID_Prj = int.Parse(comboBoxEx1.SelectedValue.ToString());
                p.valide = true;
                dc.Departement.AddObject(p);
                dc.SaveChanges();
                new FormAjoutsucces().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void DepartementForm_Load(object sender, EventArgs e)
        {
            try
            {
                var re = (from d in dc.Departement where d.valide == true select d).ToList();
                dataGridViewX1.DataSource = re;
                labelX4.Text = re.Count().ToString();
                var req = (from t in dc.Projet where t.valide == true select t).ToList();
                comboBoxEx1.DataSource = req;
                comboBoxEx1.DisplayMember = "Nom_Projet";
                comboBoxEx1.ValueMember = "ID_projet";
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                var req = (from t in dc.Departement where t.Nom_depart == a select t).SingleOrDefault();
                textBoxX1.Text = req.Code_depart;
                textBoxX2.Text = req.Nom_depart;
                comboBoxEx1.Text = req.ID_Prj.ToString();
            }
            catch { }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                var req = (from t in dc.Departement where t.valide == true select t).ToList();
                dataGridViewX1.DataSource = req;
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                var req = (from t in dc.Departement where t.Nom_depart == a || t.ID_depart==d select t).SingleOrDefault();
                req.Code_depart = textBoxX1.Text;
                req.Nom_depart = textBoxX2.Text;
                req.ID_Prj = int.Parse(comboBoxEx1.SelectedValue.ToString());
                dc.SaveChanges();
                new FormModification().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox7.Text;
                var req = (from t in dc.Departement where t.Nom_depart == a || t.ID_depart == d select t).SingleOrDefault();
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

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxX1.Clear();
                textBoxX2.Clear();
                comboBoxEx1.Text="";
            }
            catch { }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_depart"].Value.ToString());

                textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Code_depart"].Value.ToString();

                textBoxX2.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Nom_depart"].Value.ToString();
                int a  = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_Prj"].Value.ToString());
                var r=(from t in dc.Projet where t.ID_projet==a select t).SingleOrDefault();
                comboBoxEx1.Text=r.Nom_Projet;

                

                
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