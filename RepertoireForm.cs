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
    public partial class RepertoireForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public RepertoireForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                repertoirtel r = new repertoirtel();
                r.nom = textBoxX1.Text;
                r.numerotel = textBoxX2.Text;
                r.email = textBoxX10.Text;
                r.commentaire = textBoxX3.Text;
                dc.repertoirtel.AddObject(r);
                dc.SaveChanges();
                new FormAjoutsucces().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }
        public int d;

        private void buttonX6_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dc.repertoirtel.ToList();
        }

        private void RepertoireForm_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = dc.repertoirtel.ToList();

        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            textBoxX1.Clear();
            textBoxX2.Clear();
            textBoxX3.Clear();
            textBoxX10.Clear();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["id"].Value.ToString());

                textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["nom"].Value.ToString();
                textBoxX10.Text = dataGridViewX1.Rows[e.RowIndex].Cells["email"].Value.ToString();

                textBoxX2.Text = dataGridViewX1.Rows[e.RowIndex].Cells["numerotel"].Value.ToString();
                textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["commentaire"].Value.ToString();


            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            try
            {
                var req = (from t in dc.repertoirtel where t.id == d select t).SingleOrDefault();
                req.commentaire = textBoxX3.Text;
                req.nom = textBoxX1.Text;
                req.numerotel = textBoxX2.Text;
                req.email = textBoxX10.Text;
                dc.SaveChanges();


                new FormModification().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
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