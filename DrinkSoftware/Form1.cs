using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DrinkSoftware
{
    public partial class Form1 : Form
    {
        NpgsqlDataAdapter da = new NpgsqlDataAdapter();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseDisc st = new ChooseDisc();
            st.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            //NpgsqlConnection conn = new NpgsqlConnection(connStr);
            //DataTable dt = new DataTable();
            //conn.Open();
            //string commStrr = "SELECT * FROM \"Order\" ORDER BY ID";
            ////NpgsqlCommand comm2 = new NpgsqlCommand(commStrr, conn);
            ////try
            ////{
            ////    da.Fill(dt, "Order");
            ////}
            ////catch (NpgsqlException ex)
            ////{
            ////    MessageBox.Show(ex.ToString());
            ////}
            ////conn.Close();
            ////dataGridView1.DataSource = dt.Tables["Order"];
            //da = new NpgsqlDataAdapter(commStrr, conn);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            dataGridView1.DataSource = MainForm.GetDataSet();
            dataGridView1.DataMember = "order";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteOrder st = new DeleteOrder();
            st.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            
            DataTable dt = new DataTable();
            conn.Open();
            da = new NpgsqlDataAdapter();
            //da.Update(, "customers");
            //UpdateDataSet((DataTable)dataGridView1.DataSource);
            conn.Close();*/
            MainForm.UpdateDataSet((DataSet)dataGridView1.DataSource);
            //EditOrder st = new EditOrder();
            //st.Show();
        }
    }
}
