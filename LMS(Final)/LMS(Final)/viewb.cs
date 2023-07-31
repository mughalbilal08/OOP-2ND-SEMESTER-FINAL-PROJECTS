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
    public partial class viewb : UserControl
    {
        public viewb()
        {
            InitializeComponent();
        }

        public void showDataGrid(List<detailBooks> Books)
        {
            guna2DataGridView4.DataSource = Books;
            guna2DataGridView4.Refresh();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void guna2DataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }

    public partial class CopyOfviewb : UserControl
    {

        public CopyOfviewb()
        {
            InitializeComponent();
        }

        public void showDataGrid(List<detailBooks> Books)
        {
            guna2DataGridView4.DataSource = Books;
            guna2DataGridView4.Refresh();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void guna2DataGridView4_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
