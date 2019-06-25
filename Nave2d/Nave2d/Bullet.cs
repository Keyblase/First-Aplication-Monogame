using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nave2d
{
    public class Bullet
    {
        public Vector2 speedShoot;
        public Texture2D shootTexture;
        public Vector2 ShotPosition;
        public GameTime gameTime;
        //SpriteBatch spriteBatch;

        public List<Bullet> bullets = new List<Bullet>();


       
    }
}