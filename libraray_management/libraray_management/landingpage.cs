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
        public landingpage(string username)
        {
            if(username=="student")
            {
                InitializeComponent();
                addToolStripMenuItem.Enabled = false;
                addToolStripMenuItem1.Enabled = false;
                issueToolStripMenuItem.Enabled = false;
                returnToolStripMenuItem.Enabled = false;
                addToolStripMenuItem2.Enabled = false;
                //menuStrip1.Items[0].Visible = false;
            }
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

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_student ob = new view_student();
            ob.Show();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issuebook ob = new issuebook();
            ob.Show();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            @return ob = new @return();
            ob.Show();
            
        }

        private void catalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catalogue ob = new catalogue();
            ob.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ADD_MAG ob = new ADD_MAG();
            ob.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            view_mag ob = new view_mag();
            ob.Show();
        }

        private void epadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            epad ob = new epad();
            ob.Show();
        }
    }
}
