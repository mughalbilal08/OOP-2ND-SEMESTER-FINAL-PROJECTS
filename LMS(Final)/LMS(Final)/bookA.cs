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
    public partial class bookA : UserControl
    {
        int count = 0;
        public bookA()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string s = guna2TextBox1.Text;
            count = int.Parse(s);
            guna2Panel1.Visible = false;
            guna2Transition1.ShowSync(guna2Panel2);
        }
        private void resetform()
        {
            guna2TextBox4.Text = null;
            guna2TextBox3.Text = null;
            guna2TextBox5.Text = null;
        }
        private void resetform1()
        {
            guna2ComboBox1.Text = null;
            guna2TextBox1.Text = null;
                  }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string c = guna2ComboBox1.Text;
            if (count != 0)
            {
               
                string n = guna2TextBox4.Text;
                string a = guna2TextBox3.Text;
                string y = guna2TextBox5.Text;
                if (detailBooksDL.IsYearValid(y))
                {
                    detailBooks obj = new detailBooks(c, n, a, y);
                    detailBooksDL.addIntoBookList(obj);
                    detailBooksDL.saveData1();
                    MessageBox.Show("Book Has Been Added");
                    count--;
                    resetform();
                }
                else
                {
                    MessageBox.Show("Invalid Year");
                }
                
            }
            if (count == 0 || count < 0)
            {
                guna2Panel2.Visible = false;
                guna2Transition1.ShowSync(guna2Panel1);
                resetform1();      
            }

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
