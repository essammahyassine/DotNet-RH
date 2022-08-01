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
    public partial class FormVirement : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormVirement()
        {
            InitializeComponent();
        }
        int d;
        int k;
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void FormVirement_Load(object sender, EventArgs e)
        {
            try
            {
                var r = (from t in dc.Virement where t.valide == true select t).ToList();
                dataGridViewX1.DataSource = r;
                var req = (from t in dc.Personnel where t.Valide == true select t).ToList();
                comboBoxEx1.DataSource = req;
                comboBoxEx1.DisplayMember = "Nom_pers";
                comboBoxEx1.ValueMember = "ID_pers";
                
            }
            catch { }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Virement v = new Virement();
                v.id_personnel = int.Parse(comboBoxEx1.SelectedValue.ToString());
                int a = int.Parse(comboBoxEx1.SelectedValue.ToString());

                var r = (from t in dc.Personnel where t.Valide == true && t.ID_pers == a select t).SingleOrDefault();
                v.nom = r.Nom_pers + " " + r.Prenom_pers;
                var re = (from t in dc.Departement where t.ID_depart==r.ID_departement select t).SingleOrDefault();
                var req = (from t in dc.Projet where t.ID_projet== re.ID_Prj select t).SingleOrDefault();
                float f = float.Parse(textBoxX2.Text);
                float q = float.Parse(textBoxX1.Text);
                string h=req.Prime_Projet.ToString();
                float g = f * float.Parse(h);
                v.Salaire = q + g;
                v.Commentair = textBoxX3.Text;
                v.date_effectue = dateTimePicker2.Value.ToShortDateString();
                v.valide = true;
                dc.Virement.AddObject(v);
                dc.SaveChanges();

                new FormAjoutsucces().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }

        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            var req = (from t in dc.Virement where t.valide == true select t).ToList();
            dataGridViewX1.DataSource = req;
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                
                comboBoxEx1.Text="";
                textBoxX1.Clear();
                textBoxX3.Clear();
                dateTimePicker2.Value=DateTime.Now;
                
            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Close();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                k = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["id_personnel"].Value.ToString());
                var req=(from t in dc.Personnel where t.ID_pers==k select t).SingleOrDefault();
                comboBoxEx1.Text = req.Nom_pers;
                textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Salaire"].Value.ToString();

                dateTimePicker2.Value =DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["date_effectue"].Value.ToString());
                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Commentair"].Value.ToString();


            }
            catch { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                var req = (from t in dc.Virement where t.id_personnel == k && t.id==d select t).SingleOrDefault();
                req.valide = false;
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
                var v = (from t in dc.Virement where t.id_personnel == k && t.id == d select t).SingleOrDefault();
                //v.id_personnel = int.Parse(comboBoxEx1.SelectedValue.ToString());

                int a = int.Parse(comboBoxEx1.SelectedValue.ToString());

                var r = (from t in dc.Personnel where t.Valide == true && t.ID_pers == a select t).SingleOrDefault();
                v.nom = r.Nom_pers + " " + r.Prenom_pers;
                var re = (from t in dc.Departement where t.ID_depart == r.ID_departement select t).SingleOrDefault();
                var req = (from t in dc.Projet where t.ID_projet == re.ID_Prj select t).SingleOrDefault();
                float f = float.Parse(textBoxX2.Text);
                float q = float.Parse(textBoxX1.Text);
                string h = req.Prime_Projet.ToString();
                float g = f * float.Parse(h);
                v.Salaire = q + g;

                
                v.Commentair = textBoxX3.Text;
                v.date_effectue = dateTimePicker2.Value.ToShortDateString();
                dc.SaveChanges();

                new FormModification().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }
    }
}