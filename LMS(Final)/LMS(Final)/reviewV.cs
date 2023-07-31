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
    public partial class reviewV : UserControl
    {  
        public reviewV()
        {
            InitializeComponent();
            List<student> u = new List<student>();
            foreach (student r in usersDL.viewlist)
            {
                if (r.getreviewcheck() == true)
                {
                    u.Add(r);
                }
            }
            guna2DataGridView4.DataSource = u;
            guna2DataGridView4.Columns["Complaints"].Visible = false;
            guna2DataGridView4.Columns["roles"].Visible = false;
            guna2DataGridView4.Columns["password"].Visible = false;
            guna2DataGridView4.Columns["Borrowed_Books"].Visible = false;
        }
        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
