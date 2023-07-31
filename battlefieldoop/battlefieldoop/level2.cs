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
using EZInput;

namespace battlefieldoop
{
    public partial class level2 : Form
    {
        GameGrid grid;
        GameBattlePlayer player = new GameBattlePlayer();
        SmartGhost g1;
        SmartGhost g2;
        SmartGhost g3;
        Henemy2 gh1;
        public level2()
        {
            InitializeComponent();
        }

        private void level2_Load(object sender, EventArgs e)
        {
            grid = new GameGrid("maze2.txt", 13, 25);

            Image playerImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(11, 2);
            player = new GameBattlePlayer(0, 100, playerImage, startCell);

      
            Image smartEnemy = Game.getGameObjectImage('x');
            GameCell s1 = grid.getCell(1, 2);
            g1 = new SmartGhost(this, 100, player, GameDirection.Left, smartEnemy, s1);


            Game.ghosts.Add(g1);
      
            playerbar.Value = player.getLives();
            printMaze(grid);
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }
        private void Game_timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(Game.score);
            playerbar.Value = player.getLives();

            playermovemnt();        // player
            enemymovemnet();        // enemy

            if (Game.ghosts.Count == 0 && Game.enemycount == 1)
            {
                Game_timer1.Enabled = false;
                MessageBox.Show("GAME END");
                this.Hide();
                Form g = new GameOver();
                g.Show();
            }
         
            if (player.getLives() == 0)
            {
                Game_timer1.Enabled = false;
                MessageBox.Show("GAME OVER");
                this.Hide();
                Form g = new GameOver();
                g.Show();
            }
        }
        private void bullet_timer1_Tick(object sender, EventArgs e)
        {
            foreach (Bullet b in Game.bullets)
            {
                b.move();
            }
            for (int x = 0; x < Game.bullets.Count; x++)
            {
                if (Game.bullets[x].getIsActive() == false)
                {
                    Game.bullets.RemoveAt(x);
                }
            }
            foreach (Bullet b in Game.bulletE)
            {
                b.move();
            }
            for (int x = 0; x < Game.bulletE.Count; x++)
            {
                if (Game.bulletE[x].getIsActive() == false)
                {
                    Game.bulletE.RemoveAt(x);
                }
            }

         
        }
        public void playermovemnt()
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                player.move(GameDirection.Left);
                if (player.getFlipPosition() == "Right")
                {
                    player.setFlipPosition("Left");

                }
                player.setFlip(true);
            }
            else if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                player.move(GameDirection.Right);
                if (player.getFlipPosition() == "Left")
                {
                    player.setFlipPosition("Right");

                }
                player.setFlip(true);
            }

            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (player.CurrentCell.nextWallCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.WALL || player.CurrentCell.nextWallCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.V_WALL)
                {
                    player.setJumpHeight(2);
                }

            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                player.generateBullet();
            }
            if (player.getJumpHeight() > 0)
            {
                player.move(GameDirection.Up);
                player.setFlip(true);
                player.decreaseJumpHeight();
            }
            else if (player.CurrentCell.nextWallCell(GameDirection.Down).CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {
                player.move(GameDirection.Down);
                player.setFlip(true);
            }
            if (player.getFlip() == true)
            {
                player.flipPlayer();
                player.setFlip(false);
            }
        }
        public void enemymovemnet()
        {
            foreach (enemy h in Game.ghosts)
            {
                if (h.getFlip() == true)
                {
                    h.setFlip(false);
                }
                h.move();
                h.flipPlayer();
                h.generateBullet();
                h.setbarposition();
                h.setbarvalue();
                if (h.getLives() == 0)
                {
                    h.setisELive(false);
                    GameObject gameObj = Game.getBlankGameObject();
                    this.Controls.Remove(h.getbar());
                    h.CurrentCell.CurrentGameObject = gameObj;
                    Game.enemycount++;
                }
            }
            for (int x = 0; x < Game.ghosts.Count; x++)
            {
                if (Game.ghosts[x].getIsELive() == false)
                {
                    Game.ghosts.Remove(Game.ghosts[x]);
                }
            }
            if (Game.enemycount == 2)
            {
                Image horiEnemy = Game.getGameObjectImage('y');
                GameCell h1 = grid.getCell(5, 14);
                gh1 = new Henemy2(this, 100, player, GameDirection.Left, horiEnemy, h1);
                Game.ghosts.Add(gh1);
                Game.enemycount ++;
                printMaze(grid);
            }
            if (Game.enemycount == 4)
            {
                Image smartEnemy = Game.getGameObjectImage('x');
                GameCell s2 = grid.getCell(6, 23);
                g2 = new SmartGhost(this, 100, player, GameDirection.Left, smartEnemy, s2);
        
                GameCell s3 = grid.getCell(1, 3);
                g3 = new SmartGhost(this, 100, player, GameDirection.Left, smartEnemy, s3);

                Game.ghosts.Add(g3);
                Game.ghosts.Add(g2);
                Game.enemycount = Game.enemycount - 5;
                printMaze(grid);
            }
        }
    }
}
