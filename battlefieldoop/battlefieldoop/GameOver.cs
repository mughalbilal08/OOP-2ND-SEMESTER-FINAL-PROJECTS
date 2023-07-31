using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using battlefieldoop.GameGL;

namespace battlefieldoop
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
            label2.Text = Convert.ToString(Game.score);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form s = new Form1();
            s.Show();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
    }
}
