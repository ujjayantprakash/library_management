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
    public partial class catalogue : Form
    {
        public catalogue()
        {
            InitializeComponent();
        }

        private void catalogue_Load(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=2021";
                MySqlConnection ob = new MySqlConnection(myConnection);
                MySqlDataAdapter obj = new MySqlDataAdapter();
                //string query;
                //  obj.SelectCommand = new MySqlCommand("insert into library.newbook (book_name,book_author,publisher,publish_date,cost,quantity) values ('" + book_name + "','" + book_author + "','" + publisher + "','" + dop + "','" + price + "','" + quantity + "');", ob);
                //obj.SelectCommand = new MySqlCommand("update library.student set reg = '" + regi + "' , name ='" + sname + "'  ,department = '" + dep + "' ,sem='" + semester + "'  ,mobile='" + mob + "'  ,email='" + emailid + "'  where reg='" + rowid + "'", ob);
               // obj.SelectCommand = new MySqlCommand("select * from library.issuereturn where status like 'NO';", ob);
                obj.SelectCommand = new MySqlCommand("call library.getallnotreturnedbooks();", ob);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(obj);
                ob.Open();
                DataSet ds = new DataSet();
                obj.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                //obj.SelectCommand = new MySqlCommand("select * from library.issuereturn where status like 'YES';", ob);
                obj.SelectCommand = new MySqlCommand("call library.getallreturnedbooks();", ob);
                MySqlCommandBuilder cb1 = new MySqlCommandBuilder(obj);
                DataSet ds1 = new DataSet();
                obj.Fill(ds1);
                dataGridView2.DataSource = ds1.Tables[0];
                ob.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
