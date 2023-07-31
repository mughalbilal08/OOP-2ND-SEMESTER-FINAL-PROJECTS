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
    public partial class unavailableB : UserControl
    {
        public unavailableB()
        {
            InitializeComponent();
     /*       List<detailBooks> b = new List<detailBooks>();
            foreach (detailBooks s in detailBooksList.bookDetail)
            {
                if (s.getbookwidraw() == true)
                {
                    b.Add(s);
                }
            }
            guna2DataGridView4.DataSource = b;
            guna2DataGridView4.Columns["password"].Visible = false;
            guna2DataGridView4.Columns["roles"].Visible = false;*/
        }

        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
