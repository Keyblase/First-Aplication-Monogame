using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    public class HorizontalEnemy : BaseEnemy
    {

        public new int MovimentEnemy()
        {
            return enemyPosition.X += (int)speedEnemy.X * 4;
        }

        public new void ResetPositionEnemy()
        {
            enemyPosition.X = 0;
            enemyPosition.X = MovimentEnemy();

        }

        public new void DrawEnemy()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textureEnemy, enemyPosition, Color.White);
            spriteBatch.End();
        }



    }
}
