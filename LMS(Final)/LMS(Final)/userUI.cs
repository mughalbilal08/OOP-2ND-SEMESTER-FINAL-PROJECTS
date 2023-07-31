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
using LMS_Final_.BL;
using LMS_Final_.DL;

namespace LMS_Final_
{
    public partial class userUI : Form
    {
        public userUI()
        {
            InitializeComponent();
            pictureBox2.Visible = true;
            guna2PictureBox2.Visible = true;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            borrowB2.Visible = false;
            searchB3.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            List<detailBooks> Books = new List<detailBooks>();
            foreach (detailBooks ba in detailBooksDL.bookDetail)
            {
                if (ba.getisbookborrowed() == false)
                {
                    Books.Add(ba);
                }
            }
            viewb3.showDataGrid(Books);
            viewb3.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            guna2PictureBox2.Visible = true;
            viewb3.Visible = false;
            borrowB2.Visible = false;
            searchB3.Visible = false;
            bookReturn1.Visible = false;
            fine2.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
            pictureBox2.Visible = false;
            viewb3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            searchB3.Visible = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            borrowB2.Visible = true;
        }

        private void viewb2_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e) // option 9
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            fine2.Visible = true;
        }

        private void logout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form f = new Form1();
            f.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            users user = usersDL.getUser(index.getIndex());

            List<record> r = user.getlistR();
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            viewH1.datashow(r);
            viewH1.Visible = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            guna2PictureBox2.Visible = false;
            pictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            reviewA1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            bookReturn1.Visible = true;
            bookReturn1.setBorrowedBookName(usersDL.user[index.getIndex()].getborrowbookname(), usersDL.user[index.getIndex()].getborrowbookAuthur());
        }
        
        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            complainA1.Visible = false;
            changeDU1.Visible = false;
            reviewA1.Visible = true;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            guna2PictureBox2.Visible = false;
            viewb3.Visible = false;
            searchB3.Visible = false;
            borrowB2.Visible = false;
            fine2.Visible = false;
            bookReturn1.Visible = false;
            viewH1.Visible = false;
            reviewA1.Visible = false;
            changeDU1.Visible = false;
            complainA1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
