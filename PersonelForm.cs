using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.IO;
using System.Data.Entity;
namespace KglinkRH
{
    public partial class PersonelForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public PersonelForm()
        {
            InitializeComponent();
        }
        GestionRHEntities7 dc = new GestionRHEntities7();
        string chemain = "";
        int aaa ;
        int bbb = 0;
        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                Personnel r = new Personnel();
                string a = textBoxX1.Text;
                r.CIN_pers =a;
                string b = textBoxX2.Text;
                r.Nom_pers =b;
                string c= textBoxX3.Text;
                r.Prenom_pers =c;
                string d = dateTimePicker1.Value.ToShortDateString();
                r.Date_naissance = d;
                string f = comboBoxEx1.SelectedItem.ToString();
                r.Fonction = f;
                string g = textBoxX6.Text;
                r.Formateur_Centre =g;
                string h = textBoxX4.Text;
                r.Adresse = h;
                string i = textBoxX5.Text;
                r.Login = i;
                string j = textBoxX7.Text;
                r.Pass = j;
                string k = comboBoxEx5.SelectedItem.ToString();
                r.Type_formation = k;
                int l = Convert.ToInt32(textBoxX11.Text);
                r.Durée_formation = l;
                string m = textBoxX12.Text;
                r.Tel = m;
                string n = textBoxX10.Text;
                r.E_mail = n;
                string o = comboBoxEx2.SelectedItem.ToString();
                r.sexe = o;
                string p = textBoxX9.Text;
                r.Niv_etude = p;
                string q = textBoxX8.Text;
                r.Diplome_obtenu = q;
                string s = dateTimePicker2.Value.ToShortDateString();
                r.Date_embauche = s;
                int t = Convert.ToInt32(comboBoxEx3.SelectedValue.ToString());
                r.ID_departement = t;
                string u = comboBoxEx4.SelectedItem.ToString();
                r.Role = u;
                bool v = true;
                r.Valide = v;
                //r.img=chemain;
                MemoryStream w = new MemoryStream();
                pictureBox1.Image.Save(w, pictureBox1.Image.RawFormat);
                byte[] ima = w.ToArray();

                r.img = ima;
                

                 if (chemain !="")
                {
                    r.img_chem = @"file:///C://Photos_personnel//" + textBoxX1.Text + ".jpeg";
                    try
                    {
                        System.IO.File.Copy(chemain, "C:\\Photos_personnel\\" + textBoxX1.Text + ".jpeg");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    r.img_chem = "";
                }

                dc.Personnel.AddObject(r);
                dc.SaveChanges();
                chemain = "";
                new FormAjoutsucces().ShowDialog();
               
            }
            
            
            catch
            {
                new FormErreur().ShowDialog();
            }
        }
         //r.CIN_pers = textBoxX1.Text;
         //       r.Nom_pers =" ";
         //       r.Prenom_pers =" ";
         //       r.Date_naissance = dateTimePicker1.Value.ToShortDateString();
         //       r.Fonction = comboBoxEx1.SelectedItem.ToString();
         //       r.Formateur_Centre =" ";
         //       r.Adresse =" ";
         //       r.Login =" ";
         //       r.Pass =" ";
         //       r.Type_formation =comboBoxEx5.SelectedItem.ToString();
         //       r.Durée_formation =Convert.ToInt32(textBoxX11.Text.ToString());
         //       r.Tel =" ";
         //       r.E_mail =" ";
         //       r.sexe = comboBoxEx2.SelectedItem.ToString();
         //       r.Niv_etude =" ";
         //       r.Diplome_obtenu =" ";
         //       r.Date_embauche = dateTimePicker2.Value.ToShortDateString();
         //       r.ID_departement = int.Parse(comboBoxEx3.SelectedValue.ToString());
         //       r.Role = comboBoxEx4.SelectedItem.ToString();
         //       r.Valide = true;
         //       MemoryStream m = new MemoryStream();
         //       pictureBox1.Image.Save(m, pictureBox1.Image.RawFormat);
         //       byte[] ima = m.ToArray();

         //       r.img = ima;
         //       dc.Personnel.AddObject(r);
         //       dc.SaveChanges();

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            try
            {
                System.IO.Directory.CreateDirectory(@"C:\\Photos_personnel");
                var re = (from k in dc.Departement where k.valide == true select k).ToList();
                comboBoxEx3.DataSource = re;
                comboBoxEx3.DisplayMember = "Nom_depart";
                comboBoxEx3.ValueMember = "ID_depart";

                var req = (from t in dc.Personnel where t.Valide == true select t).ToList();
                aaa = int.Parse(req.Count().ToString());
                timer1.Start();
                //labelX21.Text = req.Count().ToString();
                dataGridViewX1.DataSource = req;
            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {

            try
            {

                textBoxX1.Clear();
                textBoxX2.Clear();
                textBoxX3.Clear();
                textBoxX4.Clear();
                comboBoxEx1.Text = "";
                textBoxX6.Clear();
                textBoxX5.Clear();
                textBoxX7.Clear();
                comboBoxEx5.Text = "";
                textBoxX11.Clear();
                textBoxX12.Clear();
                textBoxX10.Clear();
                comboBoxEx2.Text = "";
                textBoxX9.Clear();
                textBoxX8.Clear();
                comboBoxEx3.Text = "";
                comboBoxEx4.Text = "";

            }
            catch { }
            
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBoxX13.Text;
                string b = textBoxX14.Text;
                var req = (from t in dc.Personnel where t.Nom_pers == a && t.Prenom_pers == b select t).SingleOrDefault();
                req.Valide = false;
                dc.SaveChanges();
            
            new FormSupression().ShowDialog();

            }


            catch
            {
                new FormErreur().ShowDialog();
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBoxX13.Text;
                string b = textBoxX14.Text;
                var req = (from t in dc.Recrutement where t.Nom_Candidat == a && t.Prenom_Candidat == b select t).FirstOrDefault();

                textBoxX1.Text = req.CIN_Candidat.ToString();
                textBoxX2.Text = req.Nom_Candidat.ToString();
                textBoxX3.Text = req.Prenom_Candidat.ToString();
                dateTimePicker1.Value = DateTime.Parse(req.Date_Naissance);
                textBoxX12.Text = req.Tel.ToString();
                textBoxX9.Text = req.Niv_etd.ToString();
                textBoxX8.Text = req.Diplome_obtenu.ToString();
            }
            catch { }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBoxX13.Text;
                string b = textBoxX14.Text;
                var req = (from t in dc.Personnel where t.Nom_pers == a && t.Prenom_pers == b select t).SingleOrDefault();

                textBoxX1.Text = req.CIN_pers;
                textBoxX2.Text = req.Nom_pers;
                textBoxX3.Text = req.Prenom_pers;
                comboBoxEx1.Text = req.Fonction;
                textBoxX6.Text = req.Formateur_Centre;
                textBoxX5.Text = req.Login;
                textBoxX7.Text = req.Pass;
                textBoxX8.Text = req.Diplome_obtenu;
                comboBoxEx5.Text = req.Type_formation;
                textBoxX11.Text = req.Durée_formation.ToString();
                textBoxX12.Text = req.Tel;
                textBoxX10.Text = req.E_mail;
                comboBoxEx2.Text = req.sexe;
                textBoxX9.Text = req.Niv_etude;
                req.Diplome_obtenu = textBoxX8.Text;
                dateTimePicker2.Value = DateTime.Parse(req.Date_embauche);
                comboBoxEx3.Text = req.ID_departement.ToString();
                comboBoxEx4.Text = req.Role;
            }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBoxX13.Text;
                string b = textBoxX14.Text;
                var req = (from t in dc.Personnel where t.Nom_pers == a && t.Prenom_pers == b select t).SingleOrDefault();

                req.CIN_pers = textBoxX1.Text;
                req.Nom_pers = textBoxX2.Text;
                req.Prenom_pers = textBoxX3.Text;
                req.Date_naissance = dateTimePicker1.Value.ToShortDateString();
                req.Fonction = comboBoxEx1.SelectedItem.ToString();
                req.Formateur_Centre = textBoxX6.Text;
                req.Login = textBoxX5.Text;
                req.Pass = textBoxX7.Text;
                req.Type_formation = comboBoxEx5.SelectedItem.ToString();
                req.Durée_formation = int.Parse(textBoxX11.Text);
                req.Tel = textBoxX12.Text;
                req.E_mail = textBoxX10.Text;
                req.sexe = comboBoxEx2.Text;
                req.Niv_etude = textBoxX9.Text;
                req.Diplome_obtenu = textBoxX8.Text;
                req.Date_embauche = dateTimePicker2.Value.ToShortDateString();
                req.ID_departement = int.Parse(comboBoxEx3.SelectedValue.ToString());
                req.Role = comboBoxEx4.SelectedItem.ToString();
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
                

                var req = (from t in dc.Personnel where t.Valide == true select t).ToList();
                dataGridViewX1.DataSource = req;
            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = " imag | *jpg; *png; *bmp; ";
            if (op.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(op.FileName);
                chemain = op.FileName;
                //chemain = FileName;

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Close();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(bbb!=aaa)
            {
                bbb++;
                labelX21.Text = bbb.ToString();
            }
        }
    }
}