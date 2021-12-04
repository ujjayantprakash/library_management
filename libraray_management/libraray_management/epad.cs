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
    public partial class epad : Form
    {
        public epad()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                String regno = textBox1.Text;
                String epadid = textBox3.Text;
                String SesDate = dateTimePicker1.Text;


                try
                {
                    string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                    MySqlConnection ob = new MySqlConnection(myConnection);
                    MySqlDataAdapter obj = new MySqlDataAdapter();
                    //string query;
                    obj.SelectCommand = new MySqlCommand("insert into library.epad (reg,epad_id,date_time) values ('" + regno + "','" + epadid + "','" + SesDate + "');", ob);
                    // obj.SelectCommand = new MySqlCommand("select * from library.epad;", ob); 
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                    ob.Open();
                    DataSet ds = new DataSet();
                    obj.Fill(ds);

                    MessageBox.Show("Epad Training Session Booked successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();

                    textBox3.Clear();


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

                textBox3.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure?","warning",MessageBoxButtons.OK,MessageBoxIcon.Warning)==DialogResult.OK)
                 this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
