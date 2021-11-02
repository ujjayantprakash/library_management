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
    public partial class issuebook : Form
    {
        public issuebook()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void issuebook_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
                obj.SelectCommand = new MySqlCommand("select book_name from library.newbook;", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                MySqlDataReader sdr = (obj.SelectCommand).ExecuteReader();
                while(sdr.Read())
                {
                    for(int i=0;i<sdr.FieldCount;i=i+1)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
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
                    obj.SelectCommand = new MySqlCommand("select * from library.student where reg='"+regno+"';", ob);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    if(ds.Tables[0].Rows.Count !=0)
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
    }
}
