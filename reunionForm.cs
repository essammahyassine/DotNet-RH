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
    public partial class reunionForm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public reunionForm()
        {
            InitializeComponent();
        }
        
        GestionRHEntities7 dc = new GestionRHEntities7();
        private void reunionForm_Load(object sender, EventArgs e)
        {
            try
            {
                //timer1.Start();
                dataGridViewX1.DataSource = dc.reunion.ToList();
                //
            }
            catch { }
        }

        

        
    }
}