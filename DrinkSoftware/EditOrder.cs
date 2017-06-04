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
    public partial class EditOrder : Form
    {
        public EditOrder()
        {
            InitializeComponent();
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;password=1;Database=DrinkSoftware;encoding=unicode;");
            string commStr = "UPDATE \"Order\" SET per_id = " + textBox1.Text + ", cas_id = " + textBox2.Text + ", disc_id = " + textBox3.Text + ", closedate = '" + textBox5.Text + "', payment = " + textBox6.Text + ", collateral = " + textBox7.Text + ", orderstate = " + textBox8.Text + " WHERE ID = " + textBox10.Text;
            NpgsqlCommand command = new NpgsqlCommand(commStr, conn);
            try
            {
                conn.Open();
                NpgsqlDataReader create_tab1 = command.ExecuteReader();
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;
                textBox8.Text = null;
                textBox10.Text = null;
                MessageBox.Show("Запись отредактирована");
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
