using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraray_management
{
    public partial class landingpage : Form
    {
        public landingpage()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            if(MessageBox.Show("Do you want to exit?","Yes",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void landingpage_Load(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addbook ob = new addbook();
            ob.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            add_student ob = new add_student();
            ob.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewbook ob = new viewbook();
            ob.Show();
        }
    }
}
