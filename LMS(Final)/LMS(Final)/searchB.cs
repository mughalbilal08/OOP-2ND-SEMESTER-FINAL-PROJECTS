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
    public partial class searchB : UserControl
    {
        public searchB()
        {
            InitializeComponent();
        }
        public  void resetform()
        {
             guna2TextBox4.Text = null;
             guna2TextBox1.Text = null;
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string name = guna2TextBox4.Text;
            string auth = guna2TextBox1.Text;
            detailBooks objS = new detailBooks(name, auth);
            bool isCheck = detailBooksDL.searchBooks(objS);

            if (isCheck == true)
            {
                MessageBox.Show(" Book Is Available");
            }

            if (isCheck == false)
            {
                MessageBox.Show(" Book Is Not Available");
            }
            resetform();
        }
    }

    public partial class CopyOfsearchB : UserControl
    {
        public CopyOfsearchB()
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
            detailBooks objS = new detailBooks(name, auth);
            bool isCheck = detailBooksDL.searchBooks(objS);

            if (isCheck == true)
            {
                MessageBox.Show(" Book Is Available");
            }

            if (isCheck == false)
            {
                MessageBox.Show(" Book Is Not Available");
            }
            resetform();
        }
    }
}
