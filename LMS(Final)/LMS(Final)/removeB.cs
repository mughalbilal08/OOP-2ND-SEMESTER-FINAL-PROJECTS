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
    public partial class removeB : UserControl
    {
        public removeB()
        {
            InitializeComponent();
        }
        public void resetform()
        {
            guna2TextBox4.Text = null;
            guna2TextBox1.Text = null;
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string name = guna2TextBox4.Text;
            string auth = guna2TextBox1.Text;
            bool check = detailBooksDL.checkRbooks(ref name, ref auth);
            if (check == true)
            {
                MessageBox.Show(" Book Has Been Removed ");
            }
            else
            {
                MessageBox.Show(" Irrelevant Details ");
            }
            resetform();
        }
    }
}
