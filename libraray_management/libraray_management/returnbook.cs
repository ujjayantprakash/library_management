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
    public partial class @return : Form
    {
        public @return()
        {
            InitializeComponent();
        }
        int b_id;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
                obj.SelectCommand = new MySqlCommand("select * from library.issuereturn where reg='" + textBox1.Text + "' and status like 'NO' ;", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);
                if(ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("invalid id or no book issued ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ob.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void return_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Clear();
        }

        String bname;
        String bdate;
        Int64 rowid;
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
            MySqlConnection ob = new MySqlConnection(myConnection);
            MySqlDataAdapter obj = new MySqlDataAdapter();
            //string query;
            //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
            obj.SelectCommand = new MySqlCommand("select * from library.issuereturn where reg='" + textBox1.Text + "';", ob);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
            ob.Open();
            DataSet ds = new DataSet();
            obj.Fill(ds);
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
            {
                rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                bdate = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                b_id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                obj.SelectCommand = new MySqlCommand("select book_name from library.newbook where book_id='" + b_id + "';", ob);
                MySqlCommandBuilder cb1 = new MySqlCommandBuilder(obj);
                DataSet ds1 = new DataSet();
                obj.Fill(ds1);
                bname =ds1.Tables[0].Rows[0][0].ToString();
            }
            textBox2.Text = bname;
            textBox3.Text = bdate;
            ob.Close();
        }

        string b_return;
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
               // obj.SelectCommand = new MySqlCommand("update library.issuereturn set status='YES',book_return='"+dateTimePicker1.Text+"' where reg='"+textBox1.Text+"' and book_id='"+b_id+"';", ob);
                //obj.SelectCommand = new MySqlCommand("delete from library.issuereturn where reg='" + textBox1.Text + "' and book_id='" + b_id + "';", ob);
                //MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                //DataSet ds = new DataSet();
                //obj.Fill(ds);
                obj.SelectCommand = new MySqlCommand("select book_return from library.issuereturn where book_id='" + b_id + "' and reg='"+textBox1.Text+"';", ob);
                MySqlCommandBuilder cb1 = new MySqlCommandBuilder(obj);
                DataSet ds1 = new DataSet();
                obj.Fill(ds1);
                b_return= ds1.Tables[0].Rows[0][0].ToString();
                if(string.Equals(b_return,dateTimePicker1.Text))
                {
                    obj.SelectCommand = new MySqlCommand("update library.issuereturn set penalty=0,book_return='" + dateTimePicker1.Text + "' where reg='" + textBox1.Text + "' and book_id='" + b_id + "';", ob);
                    MySqlCommandBuilder cb11 = new MySqlCommandBuilder(obj);
                    DataSet ds11 = new DataSet();
                    obj.Fill(ds11);
                    MessageBox.Show("no penalty","info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    obj.SelectCommand = new MySqlCommand("update library.issuereturn set penalty=50,book_return='" + dateTimePicker1.Text + "' where reg='" + textBox1.Text + "' and book_id='" + b_id + "';", ob);
                    MySqlCommandBuilder cb11 = new MySqlCommandBuilder(obj);
                    DataSet ds11 = new DataSet();
                    obj.Fill(ds11);
                    MessageBox.Show("give penalty","info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                ob.Close();

                MessageBox.Show("Book returned", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return_Load(this, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel2.Visible = false;
        }
    }
}
