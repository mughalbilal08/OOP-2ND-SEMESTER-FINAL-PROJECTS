using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class RandomGhost : enemy
    {
        private bool flipBool = false;
        private string flipPosition = "Left";
        private int bulletDelay = 1;
        GameBattlePlayer player;
        private int random;
        private int randomDelay;
        private int speed;
        public RandomGhost(Form form, int lives, GameBattlePlayer player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image, direction)
        {
            this.CurrentCell = startCell;
            this.player = player;
        }
        public override GameCell move()
        {
            if (this.isELive == true)
            {
                if (speed % 1 == 0)
                {
                    if (player.CurrentCell.X == this.CurrentCell.X)
                    {
                        enemyDirection();
                    }
                    else
                    {
                        movements();
                        GameCell currentCell = this.CurrentCell;
                        GameCell nextCell = currentCell.nextCell(direction);
                        GameObject previousObject = nextCell.CurrentGameObject;
                        this.CurrentCell = nextCell;

                        if (previousObject.GameObjectType == GameObjectType.PLAYER)
                        {
                            player.decreasLive();
                        }
                        if (currentCell != nextCell)
                        {
                            currentCell.setGameObject(previousObject);
                        }
                        this.setFlip(true);
                        speed = 1;
                        return null;
                    }
                }
                speed++;
            }
            return this.CurrentCell;
        }
        private void enemyDirection()
        {
            if (player.CurrentCell.Y < this.CurrentCell.Y)
            {
                flipPosition = "Left";
                direction = GameDirection.Left;
            }
            else if (player.CurrentCell.Y > this.CurrentCell.Y)
            {
                flipPosition = "Right";
                direction = GameDirection.Right;
            }
        }
        public override void generateBullet()
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextWallCell(direction);

            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
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
            //    this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1;
            }
            if (flipPosition == "Right")
            {
              //  this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1_oppo;
            }
        }
        public void movements()
        {
            if (randomDelay % 5 == 0)
            {
                Random r = new Random();
                random = r.Next(4);
            }

            if (random == 0)
            {
                direction = GameDirection.Right;
                flipPosition = "Right";
            }
            else if (random == 1)
            {
                direction = GameDirection.Left;
                flipPosition = "Righ";
            }
            else if (random == 2)
            {
                direction = GameDirection.Up;
            }
            else if (random == 3)
            {
                direction = GameDirection.Down;
            }
            randomDelay++;
        }

    }
}
