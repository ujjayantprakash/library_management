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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tb2.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb2_MouseClick(object sender, MouseEventArgs e)
        {
            if(tb2.Text=="")
            {
                const char V = '*';
                tb2.PasswordChar = V;
            }
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                obj.SelectCommand = new MySqlCommand("select * from library.login where username ='"+tb1.Text+"' and password='"+tb2.Text+"';", ob);
                MySqlCommandBuilder cb =new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);
               // MessageBox.Show("connected");
               if(ds.Tables[0].Rows.Count!=0)
                {
                    this.Hide();
                    landingpage oo = new landingpage();
                    oo.Show();
                }
                else
                {
                    MessageBox.Show("wrong username or password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ob.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
