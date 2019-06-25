using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    class Backgrounds
    {
        public Texture2D texture;
        public Vector2 areaScenario;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, areaScenario, Color.White);
        }
    }

    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            // areaScenario = newRectangle;
        }

        public void Update()
        {
            areaScenario.X -= 3;
        }
    }
}

