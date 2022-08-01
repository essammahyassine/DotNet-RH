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
    public partial class MForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                reunion r = new reunion();
                r.datereunion = dateTimePicker1.Value.ToShortDateString();
                r.raison = textBoxX3.Text;
                dc.reunion.AddObject(r);
                dc.SaveChanges();
                new FormAjoutsucces().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }
        public int d;
        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Value = DateTime.Now;
                textBoxX3.Clear();
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            try
            {
                var req = (from t in dc.reunion where t.id == d select t).SingleOrDefault();
                req.datereunion = dateTimePicker1.Value.ToShortDateString();

                req.raison = textBoxX3.Text;
                dc.SaveChanges();


                new FormModification().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                d=int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["id"].Value.ToString());

                dateTimePicker1.Value= DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["datereunion"].Value.ToString());

                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["raison"].Value.ToString();
                
            }
            catch { }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dc.reunion.ToList();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}