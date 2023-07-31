using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LMS_Final_.DL;

namespace LMS_Final_
{
    public partial class removeU : UserControl
    {
        public removeU()
        {
            InitializeComponent();
        }
        public void reset()
        {
            guna2TextBox1.Text = null;
            guna2TextBox2.Text = null;
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string name = guna2TextBox1.Text;
            string pass = guna2TextBox2.Text;
            bool rem = usersDL.removeUser(ref name, ref pass);

            if (rem == true)
            {
              MessageBox.Show(" User Has Been Removed ");

            }
            else
            {
                MessageBox.Show(" No user Found ");
            }
            reset();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
