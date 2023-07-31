using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class enemybullet : Bullet
    {
        GameDirection direction;
        GameBattlePlayer player;
        public enemybullet(GameDirection direction, Image image, GameCell startCell, GameBattlePlayer player) : base(GameObjectType.BULLET, image)
        {
            this.direction = direction;
            this.CurrentCell = startCell;
            this.player = player;
        }

        public enemybullet()
        {

        }

        public override GameCell move()
        {
            if (getIsActive() == true)
            {
                GameCell currentCell = this.CurrentCell;
                GameCell nextCell = currentCell.nextCell(direction);
                GameCell nextcell2 = currentCell.nextWallCell(direction);
                GameObject previousObject = nextCell.CurrentGameObject;
                GameObject nextobj = nextcell2.CurrentGameObject;
                this.CurrentCell = nextCell;
                
                if (currentCell != nextCell)
                {
                    currentCell.setGameObject(Game.getBlankGameObject());
                }
                else if (currentCell == nextCell)
                {
                   
                    if (nextobj.GameObjectType == GameObjectType.PLAYER)
                    {
                        player.decreasLive();
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
