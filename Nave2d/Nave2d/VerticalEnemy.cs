using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    public class VerticalEnemy : BaseEnemy
    {
        public new void DrawEnemy(VerticalEnemy enemy)
        {
            
            spriteBatch.Draw(enemy.textureEnemy, enemyPosition, Color.White);
            
        }
    }
}
