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
    public partial class complainA : UserControl
    {
        public complainA()
        {
            InitializeComponent();
            panel1.Visible = true;

        }
        public void reset()
        {
            passC.Text = null;
            comlpainbox.Text = null;
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string pass = passC.Text;
            if (pass == usersDL.user[index.getIndex()].getpassword())
            {
                MessageBox.Show("Complaint Has Been Removed");

                resetcomplain(usersDL.user[index.getIndex()]);
                usersDL.saveData();
                usersDL.saveDataforview();
            }
            reset();
        }
        public static void resetcomplain(users s)
        {
            s.setusercomplaints(" ");
            s.setcomplaincheck(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string comp = comlpainbox.Text;
            usersDL.user[index.getIndex()].setusercomplaints(comp);
            usersDL.user[index.getIndex()].setcomplaincheck(true);
            usersDL.saveData();
            usersDL.saveDataforview();
            MessageBox.Show("Complain Has Been Submitted");
            reset();
        }

        private void COMLAINSBUTTON_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            guna2Transition1.ShowSync(addCpanel);
        }

        private void REMOVECBUTTON_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            addCpanel.Visible = false;
            guna2Transition1.ShowSync(complaintpanel);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
           
            guna2Transition1.HideSync(addCpanel);
            guna2Transition1.HideSync(complaintpanel);
            panel1.Visible = true;

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
          
            guna2Transition1.HideSync(addCpanel);
            guna2Transition1.HideSync(complaintpanel);
            panel1.Visible = true;
        
        }
    }
}
