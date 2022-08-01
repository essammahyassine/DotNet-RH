using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace KglinkRH
{
    public partial class showForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public showForm()
        {
            InitializeComponent();
        }

        private void showForm_Load(object sender, EventArgs e)
        {
            
           circularProgress1.IsRunning = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgress1.Value += 2;
            //if (circularProgress1.Value == 100) 
            //{
            //    new IdentificationForm().Show();
            //    timer1.Enabled = false;
            //    this.Hide();
            //}
            label1.Text = "Reading modules..." + circularProgress1.Value + "%";
            if (this.circularProgress1.Value == 10)
            {
                label1.Text = "Reading modules...10%";

                //lblWelcome.Text = "Welcome To Kemodos PIMS";
            }
                label1.Text = "Preparing on modules..." + circularProgress1.Value + "%";
             if (this.circularProgress1.Value == 20)
            {
                label1.Text = "Preparing on modules...20%";

            }

            else if (this.circularProgress1.Value == 30)
            {
                label1.Text = "Getting Started on modules...30%";
            }
            else if (this.circularProgress1.Value == 40)
            {
                label1.Text = "Loading Started modules....40%";
            }
            else if (this.circularProgress1.Value == 50)
            {
                label1.Text = "Standing on Loading modules...50%";
            }
            else if (this.circularProgress1.Value == 60)
            {
                label1.Text = "Turning on modules...60%";
            }
            else if (this.circularProgress1.Value == 70)
            {
                label1.Text = "Starting modules...70%";

            }
            else if (this.circularProgress1.Value == 80)
            {
                label1.Text = "Loading modules...80%";

            }
            else if (this.circularProgress1.Value == 90)
            {
                label1.Text = "Done Loading modules...90%";

            }
            else if (this.circularProgress1.Value == 100)
            {
                new IdentificationForm().Show();
                timer1.Enabled = false;
                this.Hide();
            }

        }
    }
}