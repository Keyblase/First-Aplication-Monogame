using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    class DiagonalEnemy : BaseEnemy
    {
        public new Rectangle MovimentEnemy()
        {
            enemyPosition.Y += (int)speedEnemy.Y * 4;
            enemyPosition.X += (int)speedEnemy.X * 4;
            return enemyPosition;
        }

        public new void ResetPositionEnemy()
        {
            enemyPosition.X = 0;
            enemyPosition.X = MovimentEnemy().X;
            enemyPosition.Y = 0;
            enemyPosition.Y = MovimentEnemy().Y;

        }

        public new void DrawEnemy()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(textureEnemy, enemyPosition, Color.White);
            spriteBatch.End();
        }
    }
}
