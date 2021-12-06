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
    public partial class issue_mag : Form
    {
        public issue_mag()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
        }

        private void issue_mag_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
                obj.SelectCommand = new MySqlCommand("select name from library.magazine;", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                MySqlDataReader sdr = (obj.SelectCommand).ExecuteReader();
                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i = i + 1)
                    {
                        comboBox1.Items.Add(sdr.GetString(i));
                    }
                }
                sdr.Close();
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

        int counter;
        private void button5_Click(object sender, EventArgs e) // search button
        {
            if (textBox1.Text != "")
            {
                String regno = textBox1.Text;
                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                    //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
                    obj.SelectCommand = new MySqlCommand("select * from library.student where reg='" + regno + "';", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);


                    obj.SelectCommand = new MySqlCommand("select count(reg) from library.borrows where reg='" + regno + "' and mag_status like'NO' ;", ob);
                    MySqlCommandBuilder cb1 = new MySqlCommandBuilder(obj);
                    //ob.Open();
                    DataSet ds1 = new DataSet();
                    obj.Fill(ds1);

                    counter = int.Parse(ds1.Tables[0].Rows[0][0].ToString());

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                        textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                        textBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                        textBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                        textBox6.Text = ds.Tables[0].Rows[0][5].ToString();
                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        MessageBox.Show("Invalid Registration Number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    //dataGridView1.DataSource = ds.Tables[0];
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        string m_id;
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (comboBox1.SelectedIndex != -1 && counter <= 2)
                {
                    //MessageBox.Show("hello");
                    string regno = textBox1.Text;
                    string mag_name = comboBox1.Text;
                    string mag_issue = dateTimePicker1.Text;
                    
                    string mstatus = "NO";
                    try
                    {
                        string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                        MySqlConnection ob = new MySqlConnection(myConnection);
                        MySqlDataAdapter obj = new MySqlDataAdapter();
                        obj.SelectCommand = new MySqlCommand("select magazine_id from library.magazine where name='" + mag_name + "';", ob);
                        MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                        ob.Open();
                        DataSet ds = new DataSet();
                        obj.Fill(ds);

                        m_id =ds.Tables[0].Rows[0][0].ToString();


                        obj.SelectCommand = new MySqlCommand("insert into library.borrows (reg,magazine_id,magazine_issue,mag_status) values ('" + regno + "','" + m_id + "','" + mag_issue + "','" + mstatus + "');", ob);
                        MySqlCommandBuilder cb1 = new MySqlCommandBuilder(obj);
                        //ob.Open();
                        DataSet ds1 = new DataSet();
                        obj.Fill(ds1);
                        ob.Close();

                        MessageBox.Show("Magazine Borrowed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        comboBox1.SelectedIndex = -1;

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Magazine not issue  or select something", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter valid registration number", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
