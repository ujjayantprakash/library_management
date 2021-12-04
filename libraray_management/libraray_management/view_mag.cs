using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace libraray_management
{
    public partial class view_mag : Form
    {
        public view_mag()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.magazine (name,magazine_id) values ('" + name + "','" + magazine_id+ "');", ob);
                obj.SelectCommand = new MySqlCommand("select * from library.magazine;", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
                // MessageBox.Show("Data saved successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


                ob.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        int mag_id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                mag_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                // MessageBox.Show((dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
            panel2.Visible = true;
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.magazine (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                obj.SelectCommand = new MySqlCommand("select * from library.magazine where magazine_id='" + mag_id + "';", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);

                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();



                ob.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    //  obj.SelectCommand = new MySqlCommand("insert into library.magazine(name,magazine_id) values ('" + name+ "','" + magazine_id + "');", ob);
                    obj.SelectCommand = new MySqlCommand("select * from library.magazine where name like '" + textBox1.Text + "%';", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                    ob.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    //  obj.SelectCommand = new MySqlCommand("insert into library.magazine (name,magazine_id) values ('" + name + "','" + magazine_id + "');", ob);
                    obj.SelectCommand = new MySqlCommand("select * from library.magazine;", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                    ob.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      
      

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel2.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
