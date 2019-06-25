using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nave2d
{
    public interface BaseObject
    {
        Texture2D Texture { get; set; }
        Rectangle Position { get; set; }
        Vector2 Speed { get; set; }

        void DrawImage();
        void Moviment();
    }
}
