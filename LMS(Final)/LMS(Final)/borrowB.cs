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
    public partial class borrowB : UserControl
    {
      
        public borrowB()
        {
            InitializeComponent();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string name = guna2TextBox6.Text;
            string auth = guna2TextBox5.Text;
            detailBooks objC = new detailBooks(name, auth);
            bool check = detailBooksDL.booksWidraw(objC, usersDL.user[index.getIndex()]);
            if (check == true)
            {
                System.DateTime d = DateTime.Now;
                string ds = "" + d;
                MessageBox.Show(ds);
                record obj = new record(name, auth, d);
                usersDL.user[index.getIndex()].adddataintohistory(obj);
                usersDL.saveData();
                usersDL.savedateforborrow(d, index.getIndex());
                detailBooksDL.saveData1();
                usersDL.saveDataforview();

            }
            else
            {
                MessageBox.Show("Irrelevent Credentials");
            }
            guna2TextBox6.Text = null;
            guna2TextBox5.Text = null;
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}