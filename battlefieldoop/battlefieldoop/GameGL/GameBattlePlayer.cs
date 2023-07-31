using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class GameBattlePlayer : GameObject
    {
        private bool isplayeralive;
        private int lives;
        private int scores;
        private bool flipBool = false;
        private string flipPosition = "Right";
        private int jumpHeight = 3;
        public GameBattlePlayer(int scores, int lives, Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.lives = lives;
            this.scores = scores;
            this.CurrentCell = startCell;
        }
        public GameBattlePlayer()
        {

        }
        public int Lives { get => lives; set => lives = value; }
        public bool Isplayeralive { get => isplayeralive; set => isplayeralive = value; }
        public int getLives()
        {
            return lives;
        }
        public void increasLive()
        {
            lives = lives+5;
        }
        public void decreasLive()
        {
            lives = lives - 5;
        }
        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
        //    addScores(nextCell);
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }

        public int getScores()
        {
            return scores;
        }
        public string getFlipPosition()
        {
            return flipPosition;
        }
        public void setFlipPosition(string position)
        {
            flipPosition = position;
        }
        public bool getFlip()
        {
            return flipBool;
        }
        public void setFlip(bool flip)
        {
            flipBool = flip;
        }
        public void flipPlayer()
        {
            if (flipPosition == "Left")
            {
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.player_rotate;
            }
            if (flipPosition == "Right")
            {
                this.CurrentCell.PictureBox.Image = battlefieldoop.Properties.Resources.player;
            }
        }
        public int getJumpHeight()
        {
            return jumpHeight;
        }
        public void decreaseJumpHeight()
        {
            jumpHeight--;
        }
        public void setJumpHeight(int height)
        {
            jumpHeight = height;
        }
        public void generateBullet()
        {
            mainPlayerBullet b = new mainPlayerBullet();
            Image bullet = GameGL.Game.getGameObjectImage('Q');
            GameCell startBullet = new GameCell();
            if (this.getFlipPosition() == "Right")
            {
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Right);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Right);
                    b = new mainPlayerBullet(Game.ghosts, GameDirection.Right, bullet, startBullet);
                    b.setIsActive(true);
                    Game.bullets.Add(b);
                }

            }
            else if (this.getFlipPosition() == "Left")
            {
                GameCell next = this.CurrentCell.nextWallCell(GameDirection.Left);
                if (next.CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    startBullet = this.CurrentCell.nextCell(GameDirection.Left);
                    b = new mainPlayerBullet(Game.ghosts, GameDirection.Left, bullet, startBullet);
                    b.setIsActive(true);
                    Game.bullets.Add(b);
                } 
            }
        }
    }
}
