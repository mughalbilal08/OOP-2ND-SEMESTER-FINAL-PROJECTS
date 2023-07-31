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
    public partial class viewH : UserControl
    {
        public viewH()
        {
            InitializeComponent();
            guna2DataGridView4.Refresh();
        }
        public void datashow(List<record> r)
        {
            guna2DataGridView4.DataSource = r;
            guna2DataGridView4.Refresh();
        }
        private void guna2DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
