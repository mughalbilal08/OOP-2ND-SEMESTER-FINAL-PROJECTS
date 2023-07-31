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
    public partial class fine : UserControl
    {
        public fine()
        {
            InitializeComponent();
        }
        public void reset()
        {
            datebox.Text = null;
            monthbox.Text = null;
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string date = datebox.Text;
            bool ch = detailBooksDL.IsdateValid(date);
            if (ch == true)
            {
                string month = monthbox.Text;
                bool chk = detailBooksDL.ValidateMonth(month);
                if (chk == true)
                {
                    usersDL.fine(date, month);
                }
                else
                {
                    MessageBox.Show("Invalid Month! ");
                    MessageBox.Show("Enter Month Again ");
                }
            }
            else
            {
                MessageBox.Show("Invalid Date! ");
                MessageBox.Show("Enter Date Again ");
            }
            reset();
        }
    }
}
