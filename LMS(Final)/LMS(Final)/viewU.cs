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
    public partial class viewU : UserControl
    {
        
        public viewU()
        {
            InitializeComponent();
        
        }
        public void showgrid(List<users> u)
        {
            guna2DataGridView4.DataSource = u;
            guna2DataGridView4.Refresh();
        }
        private void viewU_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView4_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
