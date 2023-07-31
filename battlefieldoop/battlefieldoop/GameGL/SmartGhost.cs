using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class SmartGhost : enemy
    {
        GameBattlePlayer player;
        private int bulletDelay = 1;
        int speed;
        private bool flipBool = false;
        private string flipPosition = "Right";
        public SmartGhost(Form form,int lives, GameBattlePlayer player,  GameDirection direction,Image image, GameCell startCell) : base(form,lives,GameObjectType.ENEMY, image,direction)
        {
            this.CurrentCell = startCell;
            this.player = player;
       
        }

        public override GameCell move()
        {
            if (speed % 3 == 0)
            {
                manageDirections();
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
            speed++;
            return this.CurrentCell;
        }

        public void manageDirections()
        {
            double[] distance = new double[4] { 10000, 10000, 10000, 10000 };
            if (this.CurrentCell.nextCell(GameDirection.Left).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[0] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Left));
   
            }
            if (this.CurrentCell.nextCell(GameDirection.Right).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[1] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Right));
               
            }
            if (this.CurrentCell.nextCell(GameDirection.Up).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[2] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Up));
          

            }
            if (this.CurrentCell.nextCell(GameDirection.Down).CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                distance[3] = calculateDistance(this.CurrentCell.nextCell(GameDirection.Down));
      
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                if (distance[0] > 4)
                {
                    this.direction = GameDirection.Left;
                    this.setFlipPosition("Left");
                }

            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {

                if (distance[1] > 4)
                {

                    this.direction = GameDirection.Right;
                    this.setFlipPosition("Right");
                }
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {

                    this.direction = GameDirection.Up;
                   
            }
            if (distance[3] <= distance[0] && distance[3] <= distance[1] && distance[3] <= distance[2])
            {
                    this.direction = GameDirection.Down;
                   
            }
        }

  
        public double calculateDistance(GameCell nextcell)
        {
            return Math.Sqrt(Math.Pow((player.CurrentCell.X - nextcell.X), 2) + Math.Pow((player.CurrentCell.Y - nextcell.Y), 2));
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
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.robo1_removebg_preview;
            }
            if (flipPosition == "Right")
            {
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.robo1_removebg_previewright;
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
                            startBullet = this.CurrentCell.nextCell(direction);
                            b = new enemybullet(direction, bullet, startBullet, player);
                        }
                        else if (this.getFlipPosition() == "Left")
                        {
                            startBullet = this.CurrentCell.nextCell(direction);
                            b = new enemybullet(direction, bullet, startBullet, player);
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
