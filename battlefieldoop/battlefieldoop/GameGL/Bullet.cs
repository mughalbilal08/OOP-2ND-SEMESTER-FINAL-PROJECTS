using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    abstract class Bullet : GameObject
    {

        protected bool isActive;
        protected GameDirection direction;

        public Bullet(GameObjectType gameObjectType, Image image) : base(gameObjectType, image)
        {

        }
        public Bullet()
        {

        }

        public abstract GameCell move();

        public bool getIsActive()
        {
            return isActive;
        }

        public void setIsActive(bool active)
        {
            this.isActive = active;
        }
        public bool IsActive{ get => isActive; set => isActive = value; }
        
    }
}
