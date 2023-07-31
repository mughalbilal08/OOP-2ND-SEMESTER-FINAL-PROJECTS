using Guna.UI2.WinForms;
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
    public partial class adminUI : Form
    {
        public adminUI()
        {
            InitializeComponent();
            guna2PictureBox1.Visible = true;
            guna2PictureBox2.Visible = true;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            removeU1.Visible = false;
            reviewV1.Visible = false;
            changeD2.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            changeD2.Visible=false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            guna2PictureBox1.Visible = true;
            guna2PictureBox2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void moveImageBox(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            img1.Location = new Point(b.Location.X + 147, b.Location.Y - 19);
            img1.SendToBack();

        }
        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f = new Form1();
            f.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        { 
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            removeB1.Visible = false;
            searchB1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            bookA1.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            removeB1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            List<detailBooks> Books = new List<detailBooks>();
            foreach (detailBooks ba in detailBooksDL.bookDetail)
            {
                if (ba.getisbookborrowed() == false)
                {
                    Books.Add(ba);
                }
            }
            viewb1.showDataGrid(Books);
            viewb1.Visible = true;


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            searchB1.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            removeB1.Visible = true;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            reviewV1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            List<users> u = new List<users>();
            foreach (users us in usersDL.user)
            {
                if (us.getroles() == "User")
                {
                    u.Add(us);
                }
            }
            viewU1.showgrid(u);
            viewU1.Visible = true;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            removeU1.Visible = false;
            reviewV1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            changeD2.Visible = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            viewU1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            reviewV1.Visible = false;
            unavailable1.Visible = false;
            removeU1.Visible = true;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            removeU1.Visible = false;
            changeD1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = false;
            reviewV1.Visible = true;
        }

        private void guna2Button10_Click(object sender, EventArgs e) // complaints
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            removeU1.Visible = false;
            changeD2.Visible = false;
            reviewV1.Visible = false;
            unavailable1.Visible = false;
            complainV1.Visible = true;
        }
        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            guna2PictureBox1.Visible = false;
            guna2PictureBox2.Visible = false;
            bookA1.Visible = false;
            viewb1.Visible = false;
            searchB1.Visible = false;
            removeB1.Visible = false;
            viewU1.Visible = false;
            removeU1.Visible = false;
            changeD2.Visible = false;
            reviewV1.Visible = false;
            complainV1.Visible = false;
            unavailable1.Visible = true;
        }

        private void bookA1_Load(object sender, EventArgs e)
        {

        }
    }
}
