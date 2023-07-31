using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class VerticalGhost : enemy
    {
        private bool flipBool = false;
        private string flipPosition = "Left";
        private int bulletDelay = 1;
        GameBattlePlayer player;
        public override GameCell move()
        {
            if (this.isELive == true)
            {
                if (player.CurrentCell.X != this.CurrentCell.X)
                {
                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(direction);
                    GameObject previousObject = nextCell.CurrentGameObject;
                    this.CurrentCell = nextCell;

                    if (currentCell == nextCell)
                    {
                        currentCell.setGameObject(currentCell.CurrentGameObject);
                        manageDirections();
                    }

                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(previousObject);
                        this.setFlip(true);
                    }
                }
                else if (player.CurrentCell.X == this.CurrentCell.X)
                {
                    enemyDirection();
                }
            }
            return null;
        }
        public void manageDirections()
        {
            if (direction == GameDirection.Up)
            {
                direction = GameDirection.Down;
                flipPosition = "Right";
            }
            else if (direction == GameDirection.Down)
            {
                direction = GameDirection.Up;
                flipPosition = "Left";
            }
        }

        private void enemyDirection()
        {
            if (player.CurrentCell.Y < this.CurrentCell.Y)
            {
                flipPosition = "Left";
            }
            else if (player.CurrentCell.Y > this.CurrentCell.Y)
            {
                flipPosition = "Right";
            }
        }
        public VerticalGhost(Form form, int lives, GameBattlePlayer player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image, direction)
        {
            this.CurrentCell = startCell;
            this.player = player;
        }
        public override void generateBullet()
        {
            if (player.CurrentCell.X == this.CurrentCell.X)
            {
                if (bulletDelay == 2)
                {
                    this.setFlip(true);
                }

                if (bulletDelay % 3 == 0)
                {
                    this.setFlip(false);
                    enemybullet b = new enemybullet();
                    Image bullet = GameGL.Game.getGameObjectImage('F');
                    GameCell startBullet = new GameCell();
                    if (this.getFlipPosition() == "Right")
                    {
                        startBullet = this.CurrentCell.nextCell(GameDirection.Right);
                        b = new enemybullet(GameDirection.Right, bullet, startBullet, player);
                    }
                    else if (this.getFlipPosition() == "Left")
                    {
                        startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                        b = new enemybullet(GameDirection.Left, bullet, startBullet, player);
                    }
                    b.setIsActive(true);
                    Game.bulletE.Add(b);
                }
                bulletDelay++;
            }
            else
            {
                bulletDelay = 1;
            }
        }
    
        public string getFlipPosition()
        {
            return flipPosition;
        }
        public void setFlipPosition(string position)
        {
            flipPosition = position;
        }
        public override bool getFlip()
        {
            return flipBool;
        }
        public override void setFlip(bool flip)
        {
            flipBool = flip;
        }
        public override void flipPlayer()
        {
            if (flipPosition == "Left")
            {
        //        this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1;
            }
            if (flipPosition == "Right")
            {
          //      this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1_oppo;
            }
        }
    }
}
