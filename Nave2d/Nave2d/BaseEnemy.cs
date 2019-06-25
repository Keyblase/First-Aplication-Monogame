using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Nave2d
{
    public class BaseEnemy : BaseObject
    {
        //Enemy Variables
        public Texture2D textureEnemy;
        public Point speeEnemy;
        public Rectangle enemyPosition;
        public SpriteBatch spriteBatch;
        public Vector2 speedEnemy = new Vector2(1,1);

        public Texture2D Texture { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Rectangle Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Vector2 Speed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void PredefinitionsEnemy()
        {
            
        }
        public int MovimentEnemy()
        {
            return enemyPosition.Y += (int)speedEnemy.Y * 4;
        }

        public void ResetPositionEnemy()
        {
            enemyPosition.Y = 0;
            enemyPosition.Y = MovimentEnemy();

        }

        public void EnemyShoot()
        {

        }
        
        public void DrawImage()
        {
            throw new System.NotImplementedException();
        }

        public void Moviment()
        {
            throw new System.NotImplementedException();
        }     
    }
}


//public class Retangulo
//{
//    private double base1, altura;
//
//    public Retangulo(double base1, double altura)
//    {
//        this.base1 = base1;
//        this.altura = altura;
//    }
//    public double getArea()
//    {
//        return base1 * altura;
//    }
//}
//
//public class Quadrado : Retangulo
//{
//    public Quadrado(double lado): base(lado, lado)
//    {
//        getArea();
//    }
//}