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
    public partial class changeD : UserControl
    {
        string name;
        string pass;
        public changeD()
        {
            InitializeComponent();
        }
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
            currentpannel.Visible=false;
            guna2Transition1.ShowSync(newpanel);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
         bool check=   usersDL.changedetails(ref name ,ref pass);
            if (check)
            {
                string namen = nameN.Text;
                string passn = passwordN.Text;
                usersDL.user[0].setname(namen);
                usersDL.user[0].setpassword(passn);
                usersDL.saveDataA();
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
