using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    class ZigZagEnemyHorizontal : BaseEnemy
    {
        public new Rectangle MovimentEnemy()
        {
            //enemyPosition.Y += (int)speedEnemy.Y * 4;
            enemyPosition.X += (int)speedEnemy.X * 4;
            return enemyPosition;
        }

        public new void ResetPositionEnemy()
        {
            //enemyPosition.X = 0;
            //enemyPosition.X = MovimentEnemy().X;
            speedEnemy.X = -1;
            enemyPosition.Y = enemyPosition.Y - 100; // Melhorar o randon para ser para cima ou baixo aleatoreamente
            enemyPosition.Y = MovimentEnemy().Y;

        }

        public float InvertPosition()
        {
            return speedEnemy.X = 1;
        }
    }
}
