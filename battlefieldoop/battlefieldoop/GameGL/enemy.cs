﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battlefieldoop.GameGL
{
    abstract class enemy : GameObject
    {
        protected ProgressBar enemybar = new ProgressBar();
        Form form;
        protected int lives;
        protected bool isELive;
        protected GameBattlePlayer pacman;
        protected GameDirection direction;
        public enemy(Form form, int lives, GameObjectType gameObjectType, Image image,GameDirection direction) : base(GameObjectType.ENEMY, image)
        {
            this.lives = lives;
            this.form = form;
            this.direction = direction;
            enemybar = new ProgressBar();
            enemybar.Size = new Size(38,6);
            enemybar.ForeColor = Color.Brown;
            enemybar.BackColor = Color.Black;
            enemybar.Style = ProgressBarStyle.Continuous;
            isELive = true;
            form.Controls.Add(enemybar);
        }
        public abstract GameCell move();
        public GameDirection getDirection()
        {
            return direction;
        }
        public void setisELive(bool set)
        {
            this.isELive = set;
        }
        public bool getIsELive()
        {
            return isELive;
        }
        public abstract void generateBullet();
        public abstract bool getFlip();
        public abstract void setFlip(bool flip);
        public abstract void flipPlayer();
        public int getLives()
        {
            return lives;
        }
        public void increasLive()
        {
            lives = lives + 5;
        }
        public void decreasLive()
        {
            lives = lives - 5;
        }
        public ProgressBar getbar()
        {
            return enemybar;
        }
        public void setbarvalue()
        {
            enemybar.Value = lives;
        }
        public void setbarposition()
        {
            enemybar.Top = this.CurrentCell.X * 55;
            enemybar.Left = this.CurrentCell.Y * 55;
        }
    }
}
