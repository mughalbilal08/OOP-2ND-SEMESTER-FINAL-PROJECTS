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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            guna2TextBox1.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new signup();
            f1.Show();
        }
  
        private void Cleardatafromform()
        {
            guna2TextBox4.Text = "";
            guna2TextBox1.Text = "";
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (valiadationforsignin() == true)
            {
                string role;
                int ondex = 0;
                string username = guna2TextBox4.Text;
                string userpassword = guna2TextBox1.Text;
                student data = new student(username, userpassword);
                if (usersDL.user.Count != 0)
                {
                    role = usersDL.signin(data, ref ondex);

                    if (role != "Null")
                    {
                        if (role == "admin")
                        {
                            this.Hide();
                            Form f3 = new adminUI();
                            f3.Show();
                        }
                        else if (role == "student")
                        {
                            this.Hide();
                            Form f4 = new userUI();
                            f4.Show();

                        }
                    }
                    else if (role == "Null")
                    {

                        MessageBox.Show("Account has not found! Try again");


                    }
                }
                else
                {
                    MessageBox.Show("Invalid User !! SignUp first....");

                }
                Cleardatafromform();
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                guna2TextBox1.UseSystemPasswordChar = false;
            }
            if (guna2ToggleSwitch1.Checked == false)
            {
                guna2TextBox1.UseSystemPasswordChar = true;
            }
        }
        private bool valiadationforsignin()
        {
            if (string.IsNullOrEmpty(guna2TextBox4.Text.Trim()))
            {
                errorProvider1.SetError(guna2TextBox4, "User name is required");
                return false;
            }
            else
            {
                errorProvider1.SetError(guna2TextBox4, string.Empty);
            }
            if (string.IsNullOrEmpty(guna2TextBox1.Text.Trim()))
            {
                errorProvider1.SetError(guna2TextBox1, "Password is required");
                return false;
            }
            else
            {
                errorProvider1.SetError(guna2TextBox1, string.Empty);
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
