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
    public partial class MenuForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        int a=0;
        //int b = 0;
        GestionRHEntities7 dc = new GestionRHEntities7();

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
            if (IdentificationForm.typeutilisateur == "User")
            {
                //buttonX1.Enabled = false;
                //buttonX2.Enabled = false;
                //buttonX3.Enabled = false;
                //buttonX4.Enabled = false;
                //buttonX6.Enabled = false;
                //buttonX10.Enabled = false;
                //buttonX9.Enabled = false;
                //buttonX12.Enabled = false;
                //buttonX11.Enabled = false;
                //symbolBox1.Enabled = false;


            }
            //IdentificationForm.idutilisateur
            if (IdentificationForm.abcd == 0)
            {   
                this.Size = new System.Drawing.Size(1104, 0);
                timer1.Start();
                IdentificationForm.abcd = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (a < 622 )
            {
                a=a+20;
                //this.dataGridViewX1.Size = new System.Drawing.Size(f, 396);
                this.Size = new System.Drawing.Size(1104, a);
                
            }
            //labelX2.Text += DateTime.Now.ToString("dd:mm:yyyy");
            //labelX3.Text += DateTime.Now.ToString("HH:mm:ss");
            //label1.Text += DateTime.Now.ToString("dd:mm:yyyy");
            //label2.Text += DateTime.Now.ToString("HH:mm:ss");

            //if (pictureBox1.Visible == true)
            //{
            //    pictureBox1.Visible = false;
            //    pictureBox2.Visible = true;
            //}
            //else if (pictureBox2.Visible == true)
            //{
            //    pictureBox2.Visible = false;
            //    pictureBox3.Visible = true;
            //}
            //else if (pictureBox3.Visible == true)
            //{
            //    pictureBox3.Visible = false;
            //    pictureBox4.Visible = true;
            //}
            //else if (pictureBox4.Visible == true)
            //{
            //    pictureBox4.Visible = false;
            //    pictureBox5.Visible = true;
            //}
            //else if (pictureBox5.Visible == true)
            //{
            //    pictureBox5.Visible = false;
            //    pictureBox1.Visible = true;
            //}
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                ProjetForm F = new ProjetForm();
                F.Show();
                this.Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                PersonelForm F = new PersonelForm();
                F.Show();
                this.Close();
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                DepartementForm f = new DepartementForm();
                f.Show();
                this.Close();
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                RecrutementForm f = new RecrutementForm();
                f.Show();
                this.Close();
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                Conge f = new Conge();
                f.Show();
            }
            
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "Admin")
            {
                MForm f = new MForm();
                f.Show();
                this.Close();
            }
            else
            {
                reunionForm f = new reunionForm();
                f.Show();
                
            }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                AbsenceForm f = new AbsenceForm();
                f.Show();
                this.Close();
            }
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            
                Citation c = new Citation();
                c.Show();
                this.Close();
            
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                //RepertoireForm r = new RepertoireForm();
                new Relation_SociauxForm().Show();
                //r.Show();
                this.Close();
            }
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                new Formattestation().Show();
                //this.Close();
            }
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                new FormVirement().Show();
                this.Close();
            }

        }

        private void buttonX11_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                new Formprintagent().Show();
                //this.Close();
            }
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {
            IdentificationForm f = new IdentificationForm();
            f.Show();
            this.Close();
            
        }

        private void symbolBox1_Click(object sender, EventArgs e)
        {
            if (IdentificationForm.typeutilisateur == "User")
            {
                new FormAcces().Show();

            }
            else
            {
                RepertoireForm r = new RepertoireForm();

                r.Show();
            }
        }


        
    }
}