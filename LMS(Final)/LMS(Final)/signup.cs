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
    public partial class signup : Form
    {
        
        public signup()
        {
            InitializeComponent();
            if (usersDL.user.Count != 0)
            {
                panel3.Visible = false;
                guna2Transition1.HideSync(panel3);

            }
            else
            {
                panel2.Visible = false;
                guna2Transition1.HideSync(panel2);
            }
            guna2TextBox1.UseSystemPasswordChar = true;
        }
      

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();
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
                string username = guna2TextBox4.Text;
                string upassword;
                string valid;
                bool che = usersDL.name_check(username);
                if (che)
                {
                    upassword = guna2TextBox1.Text;
                    bool check = usersDL.password_check(upassword);
                    if (check)
                    {
                        users data = new users(username, upassword);
                        valid = usersDL.signup(data);
                        if (valid == "true")
                        {
                            MessageBox.Show("Already Exit");
                        }
                        else
                        {
                            usersDL.addIntoList(usersDL.setacrole(data));
                            usersDL.saveData();
                            usersDL.saveDataA();
                            usersDL.saveDataforview();
                            MessageBox.Show("User Added Successfully");
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID PASSWORD");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid name format");
                }
                Cleardatafromform();
            }
            
        }
        private void guna2ToggleSwitch1_CheckedChanged_1(object sender, EventArgs e)
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

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}
