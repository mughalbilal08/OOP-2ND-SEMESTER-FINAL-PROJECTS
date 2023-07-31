using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class HorizontalGhost : enemy
    {
        GameBattlePlayer player;
        private bool flipBool = false;
        private string flipPosition = "Left";
        private int bulletDelay = 1;

        public HorizontalGhost(Form form,int lives,GameBattlePlayer player, GameDirection direction, Image image, GameCell startCell) : base(form, lives, GameObjectType.ENEMY, image,direction)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.player = player;
        }
        public override GameCell move()
        {
            if (this.isELive == true)
            {
                if (player.CurrentCell.X != this.CurrentCell.X)
                {
                    GameCell currentCell = this.CurrentCell;
                    GameCell nextCell = currentCell.nextCell(direction);
                    GameCell nextCell2 = currentCell.nextWallCell(direction);
                    GameObject previousObject = nextCell.CurrentGameObject;
                    this.CurrentCell = nextCell;
                    GameCell downCell = nextCell.nextWallCell(GameDirection.Down);

                    if (currentCell != nextCell)
                    {
                        currentCell.setGameObject(previousObject);
                        if (downCell.CurrentGameObject.GameObjectType == GameObjectType.V_WALL)
                        {
                            manageDirections();
                        }
                        this.setFlip(true);

                    }

                    if (nextCell2.CurrentGameObject.GameObjectType == GameObjectType.PLAYERBULLET)
                    {
                        this.decreasLive();
                    }

                }
                else if (player.CurrentCell.X == this.CurrentCell.X)
                {
                    enemyD();
                }
            }

            return null;

        }
        private void enemyD()
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
        public void manageDirections()
        {
            
                if (direction == GameDirection.Left)
                {
                    direction = GameDirection.Right;
                    flipPosition = "Right";
                }
                else if (direction == GameDirection.Right)
                {
                    direction = GameDirection.Left;
                   flipPosition = "Left";
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
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1;
            }
            if (flipPosition == "Right")
            {
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.villian1_oppo;
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
                            b = new enemybullet(GameDirection.Right, bullet, startBullet,player);
                        }
                        else if (this.getFlipPosition() == "Left")
                        {
                            startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                            b = new enemybullet(GameDirection.Left, bullet, startBullet,player);
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
      
    }
}
