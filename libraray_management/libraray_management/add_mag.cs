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
    public partial class ADD_MAG : Form
    {
        public ADD_MAG()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                String Magazine_Name = textBox1.Text;

                String magazine_id = textBox2.Text;


                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    obj.SelectCommand = new MySqlCommand("insert into library.magazine (name,magazine_id) values ('" + Magazine_Name + "','" + magazine_id + "');", ob);
                    // obj.SelectCommand = new MySqlCommand("select * from library.magazine;", ob); 
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    MessageBox.Show("Data saved successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    ob.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("Empty fields error!! please enter again", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }
    }
}
