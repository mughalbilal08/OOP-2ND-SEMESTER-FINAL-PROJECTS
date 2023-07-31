using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace battlefieldoop.GameGL
{
    class mainPlayerBullet : Bullet
    {
        GameDirection direction;
        private List<enemy> ghosts;
        public mainPlayerBullet()
        {

        }

        public mainPlayerBullet(List<enemy> ghosts, GameDirection direction, Image image, GameCell startCell) : base(GameObjectType.PLAYERBULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.ghosts = ghosts;
        }

        public override GameCell move()
        {
            if (getIsActive() == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextCell2 = currentCell.nextWallCell(direction);

                this.CurrentCell = nextCell;
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextObject = nextCell2.CurrentGameObject;



                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());

                }
                else if (currentCell == nextCell)
                {
                    if (nextObject.GameObjectType == GameObjectType.ENEMY)
                    {
                        Game.score++;
                        foreach (enemy e in ghosts)
                        {
                            GameCell next = e.CurrentCell.nextWallCell(GameDirection.Left);
                            GameObject obj = next.CurrentGameObject;
                            GameCell next2 = e.CurrentCell.nextWallCell(GameDirection.Right);
                            GameObject obj2 = next2.CurrentGameObject;


                            if (obj.GameObjectType == GameObjectType.PLAYERBULLET)
                            {
                                e.decreasLive();
                                
                            }
                            else if (obj2.GameObjectType == GameObjectType.PLAYERBULLET)
                            {
                                e.decreasLive();

                            }
                        }
                    }

                    currentCell.setGameObject(Game.getBlankGameObject());
                    this.setIsActive(false);

                }
                return nextCell;
            }

            return null;
        }
     
    }
}
