using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    class Game
    {
        public static int score=0;
        public static int enemycount = 1;
        public static GameGrid grid;
        public static GameBattlePlayer pacman;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<enemy> ghosts = new List<enemy>();
        public static List<enemybullet> bulletE = new List<enemybullet>();
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, null);
            return blankGameObject;
        }

        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;

            if (displayCharacter == '#' || displayCharacter == '%')
            {
                img = battlefieldoop.Properties.Resources.bb2;
            }
            if (displayCharacter == '|' )
            {
                img = battlefieldoop.Properties.Resources.redwall;
            }
            if (displayCharacter == '$')
            {
                img = battlefieldoop.Properties.Resources.redwall;
            }

            if (displayCharacter == 'p' || displayCharacter == 'P')
            {
                img = battlefieldoop.Properties.Resources.player;
            }
            if (displayCharacter == 'F') // enemy fire
            {
                img = battlefieldoop.Properties.Resources.fire_pic;
            }
            if (displayCharacter == 'Q') // player fire
            {
                img = battlefieldoop.Properties.Resources.images;
            }
            if (displayCharacter == 'h')
            {
                img = battlefieldoop.Properties.Resources.villian1;
            }
            if (displayCharacter == 'x')
            {
                img = battlefieldoop.Properties.Resources.robo1_removebg_previewright;
            }
            if (displayCharacter == 'y')
            {
                img = battlefieldoop.Properties.Resources.enemy2;
            }

            return img;
        }

    }
}
