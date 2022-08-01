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
    public partial class AbsenceForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public AbsenceForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        int d;
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Absence ab = new Absence();
                ab.ID_Personnel = int.Parse(comboBoxEx2.SelectedValue.ToString());
                ab.Date_debut_abs = dateTimePicker1.Value.ToShortDateString();
                ab.Date_fin_abs = dateTimePicker2.Value.ToShortDateString();
                ab.Type = comboBoxEx1.Text;
                ab.Raison = textBoxX3.Text;
                ab.valide = true;
                ab.vu = true;
                dc.Absence.AddObject(ab);
                dc.SaveChanges();
                new FormAjoutsucces().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void AbsenceForm_Load(object sender, EventArgs e)
        {
            try
            {
                var req = (from t in dc.Personnel where t.Valide == true select t).ToList();
                comboBoxEx2.DataSource = req;
                comboBoxEx2.DisplayMember = "Nom_pers";
                comboBoxEx2.ValueMember = "ID_pers";
                comboBoxEx3.DataSource = req;
                comboBoxEx3.DisplayMember = "Nom_pers";
                comboBoxEx3.ValueMember = "ID_pers";
            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
              
            comboBoxEx2.Text="";
            dateTimePicker1.Value=DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBoxEx1.Text = "";
            textBoxX3.Clear();
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                int a =int.Parse(comboBoxEx3.SelectedValue.ToString()) ;
                var req = (from t in dc.Absence where t.ID_Personnel == a && t.valide==true select t).ToList();
                dataGridViewX1.DataSource = req;

                
            }
            catch { }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                
                var req = (from t in dc.Absence where t.valide == true select t).ToList();
                dataGridViewX1.DataSource = req;


            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();


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
                

                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_absence"].Value.ToString());
                int b = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_Personnel"].Value.ToString());
                var req = (from t in dc.Personnel where t.ID_pers == b select t).SingleOrDefault();
                comboBoxEx2.Text = req.Nom_pers;
                dateTimePicker1.Value = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["Date_debut_abs"].Value.ToString());
                dateTimePicker2.Value = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["Date_fin_abs"].Value.ToString());
                comboBoxEx1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Raison"].Value.ToString();


            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try 
            {
                var ab = (from t in dc.Absence where t.ID_absence == d select t).SingleOrDefault();
                ab.ID_Personnel = int.Parse(comboBoxEx2.SelectedValue.ToString());
                ab.Date_debut_abs = dateTimePicker1.Value.ToShortDateString();
                ab.Date_fin_abs = dateTimePicker2.Value.ToShortDateString();
                ab.Type = comboBoxEx1.Text;
                ab.Raison = textBoxX3.Text;
                //ab.valide = true;
                //ab.vu = true;
                
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