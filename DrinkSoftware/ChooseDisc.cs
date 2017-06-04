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
    public partial class ChooseDisc : Form
    {
        public ChooseDisc()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            conn.Open();
            string commStrr = "SELECT * FROM disc ORDER BY ID";
            NpgsqlCommand comm2 = new NpgsqlCommand(commStrr, conn);
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(commStrr, conn);
            try
            {
                da.Fill(ds, "disc");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
            dataGridView1.DataSource = ds.Tables["disc"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            NpgsqlConnection conn12 = new NpgsqlConnection(connStr);
            conn12.Open();
            string commStrr = "SELECT * FROM MOVIE ORDER BY ID";
            NpgsqlCommand comm2 = new NpgsqlCommand(commStrr, conn12);
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(commStrr, conn12);
            try
            {
                da.Fill(ds, "DISK");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn12.Close();
            dataGridView1.DataSource = ds.Tables["DISK"];
        }
    }
}
