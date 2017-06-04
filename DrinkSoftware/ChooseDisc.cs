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
            
            NpgsqlConnection conn2 = new NpgsqlConnection(connStr);
            conn2.Open();
            commStrr = "SELECT * FROM genre ORDER BY ID";
            NpgsqlCommand comm3 = new NpgsqlCommand(commStrr, conn2);
            DataSet ds2 = new DataSet();
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(commStrr, conn2);
            DataTable tbl = new DataTable();
            da2.Fill(tbl);
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "name";// столбец для отображения
            comboBox1.ValueMember = "id";//столбец с id
            conn2.Close();
            
            NpgsqlConnection conn3 = new NpgsqlConnection(connStr);
            conn3.Open();
            commStrr = "SELECT * FROM disc";
            NpgsqlCommand comm4 = new NpgsqlCommand(commStrr, conn3);
            DataSet ds3 = new DataSet();
            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(commStrr, conn3);
            DataTable tbl2 = new DataTable();
            da3.Fill(tbl2);
            comboBox2.DataSource = tbl2;
            comboBox2.DisplayMember = "movie_year";// столбец для отображения
            comboBox2.ValueMember = "id";//столбец с id
            conn3.Close();
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
            string commStrr = "default text";
            if (comboBox3.Text == "Рейтинг IMDB")
                commStrr = "SELECT * FROM disc WHERE movie_rating = " + textBox1.Text + ";";
            if (comboBox3.Text == "Название фильма")
                commStrr = "SELECT * FROM disc WHERE movie_name = '" + textBox1.Text + "';";
            if (comboBox3.Text == "Актер")
                commStrr = "SELECT * FROM disc WHERE movie_actors = '" + textBox1.Text + "';";
            if (comboBox3.Text == "Режиссер")
                commStrr = "SELECT * FROM disc WHERE movie_director = '" + textBox1.Text + "';";
            if (comboBox3.Text == "Сценарист")
                commStrr = "SELECT * FROM disc WHERE movie_screenwriter = '" + textBox1.Text + "';";
            NpgsqlCommand comm2 = new NpgsqlCommand(commStrr, conn12);
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(commStrr, conn12);
            try
            {
                da.Fill(ds, "disc");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn12.Close();
            dataGridView1.DataSource = ds.Tables["disc"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            NpgsqlConnection conn13 = new NpgsqlConnection(connStr);
            conn13.Open();
            string commStrr = "SELECT disc.id, disc.state, disc.availability, disc.price, disc.movie_name, disc.movie_year, disc.movie_descriptions, disc.movie_actors, disc.movie_director, disc.movie_screenwriter, disc.movie_addeddata, disc.movie_rating, genre.name FROM disc INNER JOIN association_14 ON disc.ID = association_14.disc_ID INNER JOIN genre ON association_14.genre_ID = genre.ID where genre.name = '" + comboBox1.Text + "' ORDER BY disc.ID";
            NpgsqlCommand comm3 = new NpgsqlCommand(commStrr, conn13);
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(commStrr, conn13);
            try
            {
                da.Fill(ds, "disc");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn13.Close();
            dataGridView1.DataSource = ds.Tables["disc"];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=DrinkSoftware;encoding=unicode;";
            NpgsqlConnection conn13 = new NpgsqlConnection(connStr);
            conn13.Open();
            string commStrr = "SELECT * from disc where movie_year = '" + comboBox2.Text + "' ORDER BY ID";
            NpgsqlCommand comm3 = new NpgsqlCommand(commStrr, conn13);
            DataSet ds = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(commStrr, conn13);
            try
            {
                da.Fill(ds, "disc");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn13.Close();
            dataGridView1.DataSource = ds.Tables["disc"];
        }
    }
}
