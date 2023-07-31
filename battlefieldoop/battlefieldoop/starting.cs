using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battlefieldoop
{
    public partial class starting : Form
    {
        public starting()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form1();
            f1.Show();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form i = new intruction();
            i.Show();
        }

        private void starting_Load(object sender, EventArgs e)
        {

        }
    }
}
