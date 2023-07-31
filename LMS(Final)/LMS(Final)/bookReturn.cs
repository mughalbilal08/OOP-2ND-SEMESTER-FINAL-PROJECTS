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
using LMS_Final_.BL;

namespace LMS_Final_
{
    public partial class bookReturn : UserControl
    {
        public bookReturn()
        {
            InitializeComponent();

        }
    
        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
        }

        public void setBorrowedBookName(string name, string author)
        {
            bookNameLbl.Text = name;
            asd.Text = author;
        }
        public void setBorrowedBookdate(string name)
        {
            
        }


        public void reset()
        {
            returnBookChkBx.Checked = false;
            bookNameLbl.Text = null;
            asd.Text = null;

        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            if (returnBookChkBx.Checked == true)
            {
                detailBooksDL.returnBoook(usersDL.user[index.getIndex()].getborrowbookname(), usersDL.user[index.getIndex()].getborrowbookAuthur());
                usersDL.user[index.getIndex()].resetB();
                usersDL.saveData();
                detailBooksDL.saveData1();
                usersDL.saveDataforview();
                MessageBox.Show("The Book Has Returned");
            }

            else
            {
                MessageBox.Show("You Didn't Return The Book");
            }
            reset();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
