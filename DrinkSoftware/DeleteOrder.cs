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
    public partial class DeleteOrder : Form
    {
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;");
            string commStr = "DELETE FROM \"Order\" WHERE ID = " + textBox1.Text;
            NpgsqlCommand command = new NpgsqlCommand(commStr, conn);
            try
            {
                conn.Open();
                NpgsqlDataReader udalenie_studenta = command.ExecuteReader();
                textBox1.Text = null;
                MessageBox.Show("Запись удалена");
                conn.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
