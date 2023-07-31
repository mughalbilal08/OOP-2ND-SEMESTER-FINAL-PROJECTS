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
    public partial class Form1 : Form
    {
        GameBattlePlayer player = new GameBattlePlayer();
        GameGrid grid;
        HorizontalGhost ghostH1;
        HorizontalGhost ghostH2;
        HorizontalGhost ghostH3;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            grid = new GameGrid("maze.txt",13,25); 

            Image playerImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(11, 2);
            player = new GameBattlePlayer(0, 100, playerImage, startCell);

            Image horiEnemy = Game.getGameObjectImage('h');
            GameCell h1 = grid.getCell(5,13);
            ghostH1 = new HorizontalGhost(this,100, player, GameDirection.Left, horiEnemy, h1);

            Image horiEnemy1 = Game.getGameObjectImage('h');
            GameCell h2 = grid.getCell(3, 21);
            ghostH2 = new HorizontalGhost(this, 100, player, GameDirection.Left, horiEnemy1, h2);

            Image horiEnemy2 = Game.getGameObjectImage('h');
            GameCell h3 = grid.getCell(1, 18);
            ghostH3 = new HorizontalGhost(this, 100, player, GameDirection.Left, horiEnemy2, h3);

            Game.ghosts.Add(ghostH1);
            Game.ghosts.Add(ghostH2);
            Game.ghosts.Add(ghostH3);

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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString( Game.score);
            playerbar.Value = player.getLives();
            
            playermovement();     // PLAYER
            enemymovemnt();       // ENEMY

            if (Game.ghosts.Count == 0)
            {
                GameTimer.Enabled = false;
                MessageBox.Show("LEVEL TWO");
                this.Hide();
                Form f2 = new level2();
                f2.Show();
            }
            if (player.getLives() == 0)
            {
                GameTimer.Enabled = false;
                MessageBox.Show("GAME OVER");
                this.Hide();
                Form g = new GameOver();
                g.Show();
            }
        }
        private void bulletTimer_Tick(object sender, EventArgs e)
        {
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

            foreach (Bullet b in Game.bullets)
            {
                b.move();
            }
            for(int x = 0;x<Game.bullets.Count;x++)
            {
                if(Game.bullets[x].getIsActive() == false)
                {
                    Game.bullets.RemoveAt(x);
                }
            }
        }
        public void playermovement()
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
        public void enemymovemnt()
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
                }
            }
            for (int x = 0; x < Game.ghosts.Count; x++)
            {
                if (Game.ghosts[x].getIsELive() == false)
                {
                    Game.ghosts.Remove(Game.ghosts[x]);
                }
            }
        }
    }
}
