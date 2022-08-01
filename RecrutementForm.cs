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
    public partial class RecrutementForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public RecrutementForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        int d;
        int aaa;
        int bbb = 0;

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Recrutement r = new Recrutement();
                r.CIN_Candidat = textBoxX1.Text;
                r.Nom_Candidat = textBoxX2.Text;
                r.Prenom_Candidat = textBoxX3.Text;
                r.Date_Naissance = dateTimePicker1.Value.ToShortDateString();
                r.Adresse = textBoxX4.Text;
                r.Ville = textBoxX5.Text;
                r.Code_postal = int.Parse(textBoxX6.Text);
                r.Numero_Passport = textBoxX11.Text;
                r.Tel = textBoxX12.Text;
                r.E_mail = textBoxX10.Text;
                r.daterecrutement = dateTimePicker2.Value.ToShortDateString();
                r.Niv_etd = textBoxX9.Text;
                r.Diplome_obtenu = textBoxX9.Text;
                r.Note_test = textBoxX7.Text;
                r.Commentaire = textBoxX13.Text;
                if (checkBox1.Checked == true)
                {
                    r.Français = "oui";
                }
                else { r.Français = null; }
                if (checkBox2.Checked == true)
                {
                    r.Anglais = "non";
                }
                else { r.Anglais = null; }
                r.valide = true;
                dc.Recrutement.AddObject(r);
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
                
                textBoxX4.Clear();
                textBoxX5.Clear();
                textBoxX6.Clear();
                textBoxX11.Clear();
                textBoxX12.Clear();
                textBoxX10.Clear();
                
                textBoxX9.Clear();
                textBoxX9.Clear();
                textBoxX7.Clear();
                textBoxX13.Clear();
                checkBox1.Checked =false;
                checkBox2.Checked =false;
                
                
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = textBox7.Text;
                string pn = textBox8.Text;
                var re = (from t in dc.Recrutement where t.Nom_Candidat == nom && t.Prenom_Candidat == pn select t).SingleOrDefault();

                textBoxX1.Text=re.CIN_Candidat;
                textBoxX2.Text =re.Nom_Candidat;
                textBoxX3.Text=re.Prenom_Candidat;

                textBoxX4.Text=re.Adresse;
                textBoxX5.Text=re.Ville;
                textBoxX6.Text=re.Code_postal.ToString();
                textBoxX11.Text=re.Numero_Passport;
                textBoxX12.Text=re.Tel;
                textBoxX10.Text=re.E_mail;

                textBoxX9.Text=re.daterecrutement;
                textBoxX9.Text=re.Niv_etd;
                textBoxX7.Text=re.Diplome_obtenu;
                textBoxX13.Text = re.Note_test;
                if (re.Français == "oui")
                {
                    checkBox1.Checked = true;
                }
                else { checkBox1.Checked = false; }
                if (re.Anglais == "oui")
                {
                    checkBox1.Checked = true;
                }
                else { checkBox1.Checked = false; }
                       
            }
            catch { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = textBox7.Text;
                string pn = textBox8.Text;
                var re = (from t in dc.Recrutement where t.Nom_Candidat == nom && t.Prenom_Candidat == pn select t).SingleOrDefault();

                re.valide = false;

                new FormSupression().ShowDialog();

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
                
                var re = (from t in dc.Recrutement where t.valide==true select t).ToList();

                dataGridViewX1.DataSource = re;

            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = textBox7.Text;
                string pn = textBox8.Text;
                var re = (from t in dc.Recrutement where t. ID_Candidat== d select t).SingleOrDefault();

                re.CIN_Candidat=textBoxX1.Text;
                re.Nom_Candidat=textBoxX2.Text;
                re.Prenom_Candidat=textBoxX2.Text;

                re.Adresse=textBoxX4.Text;
                re.Ville=textBoxX5.Text;
                re.Code_postal=int.Parse(textBoxX6.Text);
                re.Numero_Passport=textBoxX11.Text;
                re.Tel=textBoxX12.Text;
                re.E_mail=textBoxX10.Text;

                re.daterecrutement=textBoxX9.Text;
                re.Niv_etd=textBoxX9.Text;
                re.Diplome_obtenu=textBoxX7.Text;
                re.Note_test=textBoxX13.Text;
                if (checkBox1.Checked == true)
                {
                    re.Français = "oui";
                }
                else { re.Français = "non"; }
                if (checkBox1.Checked == true)
                {
                    re.Anglais = "oui";
                }
                else { re.Anglais = "non"; }
                dc.SaveChanges();

                new FormModification().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void RecrutementForm_Load(object sender, EventArgs e)
        {
            try
            {

                var re = (from t in dc.Recrutement where t.valide == true select t).ToList();
                //labelX17.Text = re.Count().ToString();
                aaa = int.Parse(re.Count().ToString());
                dataGridViewX1.DataSource = re;
                timer1.Start();

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
               d = int.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["ID_Candidat"].Value.ToString());
               textBoxX1.Text = dataGridViewX1.Rows[e.RowIndex].Cells["CIN_Candidat"].Value.ToString();
            dateTimePicker1.Value=DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["Date_Naissance"].Value.ToString());
            textBoxX3.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Prenom_Candidat"].Value.ToString();
            
            
            
            textBoxX4.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Adresse"].Value.ToString();
            textBoxX5.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Ville"].Value.ToString();
            textBoxX6.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Code_postal"].Value.ToString();
            textBoxX11.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Numero_Passport"].Value.ToString();
                        
            textBoxX12.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Tel"].Value.ToString();
            textBoxX10.Text = dataGridViewX1.Rows[e.RowIndex].Cells["E_mail"].Value.ToString();
            dateTimePicker2.Value = DateTime.Parse(dataGridViewX1.Rows[e.RowIndex].Cells["daterecrutement"].Value.ToString());
            
         
            textBoxX13.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Commentaire"].Value.ToString();

            textBoxX9.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Diplome_obtenu"].Value.ToString();
            textBoxX7.Text = dataGridViewX1.Rows[e.RowIndex].Cells["Note_test"].Value.ToString();
            //    textBoxX3.Text = 
            if(dataGridViewX1.Rows[e.RowIndex].Cells["Français"].Value.ToString()!=null)
            {checkBox1.Checked = true;}
            if(dataGridViewX1.Rows[e.RowIndex].Cells["Anglais"].Value.ToString()!=null)
            {checkBox2.Checked = true;}
            
            

            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (bbb != aaa)
            {
                bbb++;
                labelX17.Text = bbb.ToString();
            }
        }

        
    }
}