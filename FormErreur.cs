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
    public partial class FormErreur : DevComponents.DotNetBar.Metro.MetroForm
    {
        public FormErreur()
        {
            InitializeComponent();
        }

        private void symbolBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}