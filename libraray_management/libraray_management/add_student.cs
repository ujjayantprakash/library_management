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
    public partial class add_student : Form
    {
        public add_student()
        {
            InitializeComponent();
        }

        private void add_student_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String student_name = textBox1.Text;
            String reg = textBox6.Text;
            String dep = textBox2.Text;
            String sem = textBox5.Text;
            Int64 mob = Int64.Parse(textBox3.Text);
            String emid = textBox4.Text;

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                obj.SelectCommand = new MySqlCommand("insert into library.student (reg,name,department,sem,mobile,email) values ('" + reg + "','" + student_name + "','" + dep + "','" + sem + "','" + mob + "','" + emid + "');", ob);
                // obj.SelectCommand = new MySqlCommand("select * from library.newbook;", ob); 
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);

                MessageBox.Show("Data saved successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                ob.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
