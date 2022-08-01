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
    public partial class IdentificationForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public IdentificationForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void IdentificationForm_Load(object sender, EventArgs e)
        {

        }
        public static string typeutilisateur;
        public static int idutilisateur;
        public static int abcd=0;

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBoxX1.Text;
                string b = textBoxX2.Text;

                
                var req = (from t in dc.Personnel where t.Login == a && t.Pass == b select t).SingleOrDefault();
                if (req != null)
                {
                    typeutilisateur = req.Role;
                    idutilisateur = req.ID_pers;
                    req.conecter = true;
                    dc.SaveChanges();
                    new MenuForm().Show();
                    this.Hide();
                }
            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxX1.Clear();
                textBoxX2.Clear();
               
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

            }
            catch { }
            
        }
    }
}