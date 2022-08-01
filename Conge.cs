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
    public partial class Conge : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Conge()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Congé c = new Congé();
                c.Date_demande = DateTime.Now.ToShortDateString();
                c.Date_debut = dateTimePicker1.Value.ToShortDateString();
                c.Date_fin = dateTimePicker2.Value.ToShortDateString();
                c.Raison = textBoxX3.Text;
                c.commentaire = "";
                c.Validation = "en attente";
                c.Vu = false;
                c.nom = textBoxX1.Text;
                c.ID_personnnel = IdentificationForm.idutilisateur;
                dc.Congé.AddObject(c);
                dc.SaveChanges();
                new FormAjoutsucces().ShowDialog();
            }
            catch
            {
                new FormErreur().ShowDialog();
            }
            
            
        }

        private void Conge_Load(object sender, EventArgs e)
        {
            try
            {
                int a;
                a=IdentificationForm.idutilisateur;
                var req = (from t in dc.Personnel where t.Valide == true && t.ID_pers==a select t).SingleOrDefault();
                textBoxX1.Text = req.Nom_pers + " " + req.Prenom_pers;
                //comboBoxEx1.DataSource = req;
                //comboBoxEx1.DisplayMember = "Nom_pers";
                //comboBoxEx1.ValueMember = "ID_pers";
            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {

                //comboBoxEx1.Text = "";
                dateTimePicker1.Value=DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                textBoxX3.Clear();
                
                
            }
            catch { }
        }
    }
}