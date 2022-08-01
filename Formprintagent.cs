using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

namespace KglinkRH
{
    public partial class Formprintagent : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Formprintagent()
        {
            InitializeComponent();
        }
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable dt;
        DataTable dtval;
        DataTable dtcount;
        DataTable dtfirst;
        DataTable dtlast;
        int i;
        DataTable dtreplace;
        string field;
        string rep;
        string script;


        void path_values()
        {
            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@"select * from Personnel where id_pers='" + i.ToString() + "'");
            adp = new SqlDataAdapter(cmd);
            dtval = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dtval);
            cmd.Connection.Close();

        }

        public int count()
        {
            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@"select * from Personnel");
            adp = new SqlDataAdapter(cmd);
            dtcount = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dtcount);
            cmd.Connection.Close();
            return dtcount.Rows.Count;

        }

        public int first()
        {
            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@" SELECT TOP 1 id_pers FROM Personnel ORDER BY id_pers asc");
            adp = new SqlDataAdapter(cmd);
            dtfirst = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dtfirst);
            cmd.Connection.Close();
            return int.Parse(dtfirst.Rows[0][0].ToString());

        }

        public int last()
        {
            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@" SELECT TOP 1 id_pers FROM Personnel ORDER BY id_pers desc");
            adp = new SqlDataAdapter(cmd);
            dtlast = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dtlast);
            cmd.Connection.Close();
            return int.Parse(dtlast.Rows[0][0].ToString());

        }



        public string Get_script()
        {
            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@"select script_html from script where id=22");
            adp = new SqlDataAdapter(cmd);
            dt = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dt);
            cmd.Connection.Close();
            return dt.Rows[0][0].ToString();

        }


        void Replace()
        {

            cnx = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=GestionRH;Integrated Security=True");
            cmd = new SqlCommand(@"select champ_per,replace_per from script_p");
            adp = new SqlDataAdapter(cmd);
            dtreplace = new DataTable();
            cmd.Connection = cnx;
            cmd.Connection.Open();
            adp.Fill(dtreplace);
            cmd.Connection.Close();
            dataGridViewX1.DataSource = dtreplace;

        }
        //GestionRHEntities7 dc = new GestionRHEntities7();
        private void Formprintagent_Load(object sender, EventArgs e)
        {
            try{

                i = first();
                count();
                Replace();
                path_values();

                script = Get_script();

                StringBuilder sb = new StringBuilder(script);

                for (int j = 0; j < dataGridViewX1.Rows.Count - 1; j++)
                {
                    field = dataGridViewX1.Rows[j].Cells["champ_per"].Value.ToString();
                    rep = dataGridViewX1.Rows[j].Cells["replace_per"].Value.ToString();
                    sb.Replace(field, dtval.Rows[0][rep].ToString());
                }


                webBrowser1.DocumentText = sb.ToString();

            }
            catch { }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try{
            i = first();
            path_values();
            script = Get_script();

            StringBuilder sb = new StringBuilder(script);

            for (int j = 0; j < dataGridViewX1.Rows.Count - 1; j++)
            {
                field = dataGridViewX1.Rows[j].Cells["champ_per"].Value.ToString();
                rep = dataGridViewX1.Rows[j].Cells["replace_per"].Value.ToString();
                sb.Replace(field, dtval.Rows[0][rep].ToString());
            }

            webBrowser1.DocumentText = sb.ToString();
            }
            catch { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (i > first())
                //{
                    i--;
                    if (i < first())
                    {
                        i = first();
                    }
                    path_values();
                    script = Get_script();

                    StringBuilder sb = new StringBuilder(script);

                    for (int j = 0; j < dataGridViewX1.Rows.Count - 1; j++)
                    {
                        field = dataGridViewX1.Rows[j].Cells["champ_per"].Value.ToString();
                        rep = dataGridViewX1.Rows[j].Cells["replace_per"].Value.ToString();
                        sb.Replace(field, dtval.Rows[0][rep].ToString());
                    }


                    webBrowser1.DocumentText = sb.ToString();

                
            }
            catch { }
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try{
            i = last();
            path_values();
            script = Get_script();

            StringBuilder sb = new StringBuilder(script);

            for (int j = 0; j <dataGridViewX1.Rows.Count - 1; j++)
            {
                field = dataGridViewX1.Rows[j].Cells["champ_per"].Value.ToString();
                rep = dataGridViewX1.Rows[j].Cells["replace_per"].Value.ToString();
                sb.Replace(field, dtval.Rows[0][rep].ToString());
            }


            webBrowser1.DocumentText = sb.ToString();
             }
            catch { }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            try{
            ////if (i < last())
            ////{
                i++;
                
                    if (i > last())
                    {
                        i = last();
                    }
                path_values();
                script = Get_script();

                StringBuilder sb = new StringBuilder(script);

                for (int j = 0; j <dataGridViewX1.Rows.Count - 1; j++)
                {
                    field = dataGridViewX1.Rows[j].Cells["champ_per"].Value.ToString();
                    rep = dataGridViewX1.Rows[j].Cells["replace_per"].Value.ToString();
                    sb.Replace(field, dtval.Rows[0][rep].ToString());
                }

                webBrowser1.DocumentText = sb.ToString();

            //}
            }
            catch { }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }

        
             


    }
}