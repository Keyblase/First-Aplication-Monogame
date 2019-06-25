using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    class ZigZagEnemyVertical : BaseEnemy
    {
        public new Rectangle MovimentEnemy()
        {
            enemyPosition.Y += (int)speedEnemy.Y * 4;
            //enemyPosition.X += (int)speedEnemy.X * 4;
            return enemyPosition;
        }

        public new void ResetPositionEnemy()
        {
            //enemyPosition.X = 0;
            //enemyPosition.X = MovimentEnemy().X;
            speedEnemy.Y = -1;
            enemyPosition.X = enemyPosition.X - 100;
            enemyPosition.X = MovimentEnemy().X;
        }

        public float InvertPosition()
        {
            return speedEnemy.Y = 1;
        }
    }
}
