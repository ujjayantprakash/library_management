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
    public partial class viewbook : Form
    {
        public viewbook()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewbook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
              //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                 obj.SelectCommand = new MySqlCommand("select * from library.newbook;", ob); 
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
               // MessageBox.Show("Data saved successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
                ob.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int bookid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                bookid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               // MessageBox.Show((dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
            panel2.Visible = true;
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                obj.SelectCommand = new MySqlCommand("select * from library.newbook where book_id='"+bookid+"';", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);

                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                dateTimePicker1.Text= ds.Tables[0].Rows[0][4].ToString();
                textBox5.Text = ds.Tables[0].Rows[0][5].ToString();
                textBox6.Text = ds.Tables[0].Rows[0][6].ToString();

                // dataGridView1.DataSource = ds.Tables[0];
                // MessageBox.Show("Data saved successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();*/
                ob.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
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
                    //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                    obj.SelectCommand = new MySqlCommand("select * from library.newbook where book_name like '"+textBox1.Text+"%';", ob);
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
                    //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                    obj.SelectCommand = new MySqlCommand("select * from library.newbook;", ob);
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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("are you sure?", "success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = textBox2.Text;
                string bauthor = textBox3.Text;
                string publish = textBox4.Text;
                string pubdate = dateTimePicker1.Text;
                double price = Double.Parse(textBox5.Text);
                Int64 quant = Int64.Parse(textBox6.Text);

                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                    obj.SelectCommand = new MySqlCommand("update library.newbook set book_name = '" + bname + "' , book_author ='" + bauthor + "'  ,publisher = '" + publish + "' ,publish_date='" + pubdate + "'  ,cost='" + price + "'  ,quantity='" + quant + "'  where book_id='" + rowid + "'", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    //dataGridView1.DataSource = ds.Tables[0];
                    ob.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("are you sure?", "confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                    obj.SelectCommand = new MySqlCommand("delete from library.newbook where book_id='"+rowid+"';", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    //dataGridView1.DataSource = ds.Tables[0];
                    ob.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
