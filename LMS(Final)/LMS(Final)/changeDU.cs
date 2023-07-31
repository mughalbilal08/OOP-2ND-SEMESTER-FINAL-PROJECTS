using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS_Final_.BL;
using LMS_Final_.DL;

namespace LMS_Final_
{
    public partial class changeDU : UserControl
    {
        public changeDU()
        {
            InitializeComponent();
        }
        string name;
        string pass;
        public void reset()
        {
            nameC.Text = null;
            passC.Text = null;
            nameN.Text = null;
            passwordN.Text = null;
        }
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            name = nameC.Text;
            pass = passC.Text;
            currentpannel.Visible = false;
            guna2Transition1.ShowSync(newpanel);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (name == usersDL.user[index.getIndex()].getname() && pass == usersDL.user[index.getIndex()].getpassword())
            {

                string namen = nameN.Text;
                string passn = passwordN.Text;
                usersDL.user[index.getIndex()].setname(namen);
                usersDL.user[index.getIndex()].setpassword(passn);
                usersDL.saveData();
                usersDL.saveDataforview();
                MessageBox.Show("YOUR ID IS UPDATED");
                newpanel.Visible = false;
                guna2Transition1.ShowSync(currentpannel);
            }
            else
            {
                MessageBox.Show("IRRELEVENT CREDENTIALS");
                newpanel.Visible = false;
                guna2Transition1.ShowSync(currentpannel);
            }
            reset();
        }
    }
}
