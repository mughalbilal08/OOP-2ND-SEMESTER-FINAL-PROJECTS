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
    public partial class reviewA : UserControl
    {
        public reviewA()
        {
            InitializeComponent();
        }
        public void reset()
        {
            reviewComboBox.Text = null;
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string review = reviewComboBox.Text;
            usersDL.user[index.getIndex()].setreview(review);
            usersDL.user[index.getIndex()].setreviewcheck(true);
            usersDL.saveData();
            usersDL.saveDataforview();
            MessageBox.Show("Review Has Been Given");
            reset();
        }
    }
}
