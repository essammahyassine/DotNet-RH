using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Data.Entity;
using System.IO;




namespace KglinkRH
{
    public partial class Citation : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Citation()
        {
            InitializeComponent();
        }
        byte f;
        int d;
        string nom;
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void Citation_Load(object sender, EventArgs e)
        {
            try
            {
                
            
            
                int a = IdentificationForm.idutilisateur;
                string b = IdentificationForm.typeutilisateur;
                
                if (b == "User")
                {
                    var req = (from t in dc.Citations where t.valide == true && t.envoye_a==a select t).ToList();
                    labelX4.Text = req.Count().ToString() + " " + "Message Non Lus";
                    var r = (from f in dc.Congé where f.ID_personnnel == a select f).ToList();
                    labelX1.Text = " " + r.Count().ToString() + " " + " Demande de Conge";
                
                }
                if (b == "Admin")
                {
                    var req = (from t in dc.Citations where t.valide == true && t.envoye_a == a select t).ToList();
                    labelX4.Text = " " + req.Count().ToString() + " " + " Message Non Lus";
                    
                    var r = (from f in dc.Congé where f.Validation == "en attente" select f).ToList();
                    labelX1.Text = " " + r.Count().ToString() + " " + " Demande de Conge";
                }

                
                var q = (from t in dc.Personnel select new { t.img, f=(t.Nom_pers+" "+t.Prenom_pers),t.ID_pers }).ToList();
                dataGridViewX4.DataSource = q;



                int j = IdentificationForm.idutilisateur;
                var requ = (from t in dc.Personnel where t.ID_pers == j select new { t.img,t.Nom_pers,t.Prenom_pers,t.Role,t.CIN_pers,t.Tel,t.Adresse,t.E_mail,t.Date_naissance,t.Fonction,t.Niv_etude,t.Diplome_obtenu}).SingleOrDefault();
                label3.Text += " " + requ.Role;
                label4.Text += " " + requ.CIN_pers;
                label5.Text += " " + requ.Nom_pers + " " + requ.Prenom_pers;
                label6.Text += " " + requ.Tel;
                label13.Text += " " + requ.Adresse;
                label14.Text += " " + requ.E_mail;
                label15.Text += " "+requ.Date_naissance;
                label3.Text += " " + requ.Fonction;
                label11.Text += " " + requ.Niv_etude;
                label12.Text += " " + requ.Diplome_obtenu;
                
                byte[] image = (byte[])requ.img;
                MemoryStream ms = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(ms);
                


 
            }
            catch { }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            try
            {
                int a=IdentificationForm.idutilisateur;
                var req = (from t in dc.Personnel where t.ID_pers == a select t).SingleOrDefault();
            var re = (from t in dc.Personnel where t.ID_pers == d select t).SingleOrDefault();
    
                Citations c = new Citations();
                c.date_publication = DateTime.Now.ToString();
                c.valide = true;
                c.text = textBoxX1.Text;
                c.Nom = req.Nom_pers + " " + req.Prenom_pers;
                label1.Text = "Envoyer a " + re.Nom_pers + " " + re.Prenom_pers+" avec succés";
                c.img = req.img;
                c.envoye_a = d;
                c.id_pers = req.ID_pers;
                //if(req.Role=="Admin")
                //{
                //    c.valide = true;
                //}
                //else if (req.Role == "User") { c.valide = false; }
                c.valide = true;
                dc.Citations.AddObject(c);
                dc.SaveChanges();
                textBoxX1.Clear();

            }
            catch { }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            //if (IdentificationForm.typeutilisateur == "User")
            //{
            //    var req = (from t in dc.Citations where t.valide == true select new { t.img, t.Nom, t.text }).ToList();
            //    dataGridViewX1.DataSource = req;
            //}
            //else if (IdentificationForm.typeutilisateur == "Admin")
            //{
            //    var re = (from t in dc.Citations where t.valide == false select new { t.img, t.Nom, t.text }).ToList();
            //    dataGridViewX2.DataSource = re;
            //}

        }

        private void labelX4_Click(object sender, EventArgs e)
        {
            try
            {

                if (IdentificationForm.typeutilisateur == "User")
                {
                    int a = IdentificationForm.idutilisateur;

                    var req = (from t in dc.Citations where t.valide == true && t.envoye_a == a select new { t.img, t.Nom, t.text, t.id }).ToList();
                    dataGridViewX2.DataSource = req;
                    labelX4.Text = 0 + " " + "Message Non Lus ";
                    dataGridViewX2.Visible = true;
                    dataGridViewX3.Visible = false;
                    dataGridViewX5.Visible = false;
                    buttonX1.Visible = true;
                    buttonX4.Visible = false;
                    buttonX3.Visible = false;
                    //Valider

                }
                else 
                if (IdentificationForm.typeutilisateur == "Admin")
                {
                    int a = IdentificationForm.idutilisateur;

                    var re = (from t in dc.Citations where t.valide == true && t.envoye_a == a select new { t.img, t.Nom, t.text, t.id }).ToList();
                    dataGridViewX2.DataSource = re;
                    labelX4.Text = 0 + " " + "Message Non Lus";
                    dataGridViewX2.Visible = true;
                    dataGridViewX3.Visible = true;


                    buttonX1.Visible = true;
                    //buttonX2.Visible = false;
                    buttonX3.Visible = false;


                }
            }
            catch 
            { 
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridViewX2.Rows.Count - 1; i++)
            {
                Boolean b;
                b = Convert.ToBoolean(dataGridViewX2.Rows[i].Cells[0].Value);
                if (b == true)
                {
                    int k = int.Parse(dataGridViewX2.Rows[i].Cells[4].Value.ToString());
                    var v = dc.Citations.Where(x => x.id == k).SingleOrDefault();
                    if (v != null)
                    {   

                        dc.Citations.DeleteObject(v);
                        dc.SaveChanges();
                    }

                }
            }
        }

        //private void buttonX2_Click(object sender, EventArgs e)
        //{
        //    //for (int i = 0; i <= dataGridViewX2.Rows.Count - 1; i++)
        //    //{
        //    //    Boolean b;
        //    //    b = Convert.ToBoolean(dataGridViewX2.Rows[i].Cells[0].Value);
        //    //    if (b == true)
        //    //    {
        //    //        int k = int.Parse(dataGridViewX2.Rows[i].Cells[4].Value.ToString());
        //    //        var v = dc.Citations.Where(x => x.id == k).SingleOrDefault();
        //    //        if (v != null)
        //    //        {   
        //    //            v.valide = true;
        //    //            dc.SaveChanges();
        //    //        }

        //    //    }
        //    //}
        //}

        private void labelX1_Click(object sender, EventArgs e)
        {
            try
            {
                int j;
                j = IdentificationForm.idutilisateur;
                if (IdentificationForm.typeutilisateur == "User")
                {
                    var req = (from t in dc.Congé where t.ID_personnnel == j select new { t.nom, t.Date_demande, t.Date_debut, t.Date_fin,t.Validation, t.ID_congé }).ToList();
                    dataGridViewX5.DataSource = req;
                    labelX1.Text = 0 + " " + "Congé ";
                    dataGridViewX3.Visible = false;
                    dataGridViewX5.Visible = true;
                    dataGridViewX2.Visible = false;

                    buttonX1.Visible = true;
                    //buttonX2.Visible = false;
                    buttonX3.Visible = false;
              
                    buttonX4.Visible = true;


                }
                if (IdentificationForm.typeutilisateur == "Admin")
                {
                    var req = (from t in dc.Congé where t.Validation == "en attente" select new { t.nom,t.Date_demande,t.Date_debut,t.Date_fin,t.ID_congé}).ToList();
                    dataGridViewX3.DataSource = req;
                    labelX1.Text = 0 + " " + "Congé Non valider";
                    dataGridViewX3.Visible = true;
                    dataGridViewX5.Visible = false;
               
                    dataGridViewX2.Visible = false;

                    buttonX1.Visible = false;
                    //buttonX2.Visible = true;
                    buttonX3.Visible = true;
                    buttonX4.Visible = false;


                }

                
                
            }
            catch
            {
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridViewX3.Rows.Count - 1; i++)
            {
                Boolean valider;
                Boolean refuser;
                int idcon;
                idcon =  Convert.ToInt32(dataGridViewX3.Rows[i].Cells[6].Value.ToString());
                valider = Convert.ToBoolean(dataGridViewX3.Rows[i].Cells[0].Value);
                refuser = Convert.ToBoolean(dataGridViewX3.Rows[i].Cells[1].Value);
                if (valider == true)
                {
                    var r = (from t in dc.Congé where t.ID_congé == idcon select t).SingleOrDefault();
                    
                    if (r != null)
                    {
                        
                        string vl = "validée";
                        r.Validation = vl;
                        dc.SaveChanges();
                    }

                }
                if (refuser == true)
                {
                    var r = (from t in dc.Congé where t.ID_congé == idcon select t).SingleOrDefault();

                    if (r != null)
                    {

                        string refu = "refusée";
                        r.Validation = refu;
                        dc.SaveChanges();
                    }

                }
            }
            //for (int i = 0; i <= dataGridViewX3.Rows.Count ; i++)
            //{
            //    //Boolean b;
            //    //b = Convert.ToBoolean(dataGridViewX2.Rows[i].Cells[0].Value);
            //    //if (b == true)
            //    //{
            //        int k =int.Parse(dataGridViewX2.Rows[i].Cells[0].Value.ToString());
            //        var v = dc.Congé.Where(x => x.ID_congé == k).SingleOrDefault();
            //        string h = dataGridViewX2.Rows[i].Cells[1].Value.ToString();

            //        if (h != null && h!="")
            //        {   /*  dataGridView1.Rows.RemoveAt(i);  */
            //            v.Validation = h;
            //            dc.SaveChanges();
            //        }

            //    //}
            //}
        }

        private void dataGridViewX4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                d = int.Parse(dataGridViewX4.Rows[e.RowIndex].Cells["ID_pers"].Value.ToString());
                nom = dataGridViewX4.Rows[e.RowIndex].Cells["Nom"].Value.ToString();
                //label1.Text = "Envoyer un message a "+nom;
                var q = (from t in dc.Personnel where t.ID_pers==d select new {  t.Nom_pers , t.Prenom_pers}).SingleOrDefault();
                label1.Text = "Envoyer un message a " + q.Nom_pers + " " + q.Prenom_pers;
                
               

            }
            catch { }
        }

        private void explorerBar1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i <= dataGridViewX5.Rows.Count - 1; i++)
            {
                Boolean valider;
                
                int idcon;
                idcon = Convert.ToInt32(dataGridViewX5.Rows[i].Cells[6].Value.ToString());

                valider = Convert.ToBoolean(dataGridViewX5.Rows[i].Cells[0].Value);
                if (valider == true)
                {
                    var r = (from t in dc.Congé where t.ID_congé == idcon select t).SingleOrDefault();

                    if (r != null)
                    {

                        dc.Congé.DeleteObject(r);

                        dc.SaveChanges();
                    }

                }

            }





            //for (int i = 0; i <= dataGridViewX5.Rows.Count - 1; i++)
            //{
            //    Boolean b;
            //    b = Convert.ToBoolean(dataGridViewX5.Rows[i].Cells[0].Value);
            //    if (b == true)
            //    {
            //        int k = int.Parse(dataGridViewX5.Rows[i].Cells[4].Value.ToString());
            //        var v = dc.Citations.Where(x => x.id == k).SingleOrDefault();
            //        if (v != null)
            //        {

            //            dc.Citations.DeleteObject(v);
            //            dc.SaveChanges();
            //        }

            //    }
            //}
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        

        

        
    }
}