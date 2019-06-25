using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nave2d
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Player Variables
        Texture2D texture;
        public Point speedShip;
        public Rectangle navePosition;
        public Rectangle frame;
        bool isColliding;

        //Scenario Variables
        public Vector2 speedScenario;
        Texture2D cenaryTexture;
        Vector2 cenarioPosition;

        //Shoot Variables
        Bullet bulletTeste;
        List<Bullet> bulletsOnScreen = new List<Bullet>();

        //Enemy Instances
        VerticalEnemy enemy1 = new VerticalEnemy();
        HorizontalEnemy enemy2 = new HorizontalEnemy();
        DiagonalEnemy enemy3 = new DiagonalEnemy();
        ZigZagEnemyHorizontal enemy4 = new ZigZagEnemyHorizontal();
        ZigZagEnemyVertical enemy5 = new ZigZagEnemyVertical();

        //Controlling Variables
        float timeSpan = 0;
        float fireRate = 0.1f;
        float nextShoot = 0;
        float deltaTime = 0;


        bool isShooting = false;
        private bool touchBorderDown, touchBorderUp;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            cenaryTexture = Content.Load<Texture2D>("Image\\cenario3");
            cenarioPosition = new Vector2(-100, -100);
            speedScenario = new Vector2(0.2f, 0.2f);

            texture = Content.Load<Texture2D>("Image\\nave-2d");
            navePosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 700, 100, 100);
            speedShip = new Point(4, 4);

            //Enemy 1 Vertical
            enemy1.textureEnemy = Content.Load<Texture2D>("Image\\mostro1");
            enemy1.enemyPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 200, 100, 100);
            enemy1.speedEnemy = new Vector2(1, 1);

            //Enermy 2 Horizontl
            enemy2.textureEnemy = Content.Load<Texture2D>("Image\\mostro2");
            enemy2.enemyPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 250, 100, 100);
            enemy2.speedEnemy = new Vector2(1, 1);

            //Enemy 3 Diagonal
            enemy3.textureEnemy = Content.Load<Texture2D>("Image\\enemy-ghost");
            enemy3.enemyPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 250, 100, 100);
            enemy3.speedEnemy = new Vector2(1, 1);

            //Enemy 4 ZigZag Horizontal
            enemy4.textureEnemy = Content.Load<Texture2D>("Image\\s");
            enemy4.enemyPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 250, 100, 100);
            enemy4.speedEnemy = new Vector2(1, 1);

            //Enemy 5 ZigZag Vertical
            enemy5.textureEnemy = Content.Load<Texture2D>("Image\\monstro5");
            enemy5.enemyPosition = new Rectangle((graphics.PreferredBackBufferWidth / 2), 250, 100, 100);
            enemy5.speedEnemy = new Vector2(1, 1);
            
        }

        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeSpan += deltaTime;

            if (navePosition.X + navePosition.Width
               >= graphics.PreferredBackBufferWidth)
            {
                //xOuy = 0;
                touchBorderDown = false; //arrumar o bool
                navePosition.X = 900;
                //navePosition.ChangeOnTouchBorder(xOuy);
            }
            if (navePosition.X <= 0)
            {
                navePosition.X = 0;
            }

            #region EnemyVertical
            if ((enemy1.enemyPosition.Y + enemy1.enemyPosition.Height) >= graphics.PreferredBackBufferHeight)// maior q 800
            {
                enemy1.ResetPositionEnemy();
                touchBorderDown = true;
                touchBorderUp = false;
            }

            else if ((enemy1.enemyPosition.Y > 0))
            {
                touchBorderUp = true;
                enemy1.MovimentEnemy();
            }
            #endregion
            #region EnemyHorizontal
            if ((enemy2.enemyPosition.X + enemy2.enemyPosition.Width) >= graphics.PreferredBackBufferWidth)// maior q 1000
            {
                enemy2.ResetPositionEnemy();
                //touchBorderDown = true;
                //touchBorderUp = false;
            }

            else if ((enemy2.enemyPosition.X > 0))
            {
                //touchBorderUp = true;
                enemy2.MovimentEnemy();
            }
            #endregion
            #region DiagonalEnemy
            if ((enemy3.enemyPosition.X + enemy3.enemyPosition.Width) >= graphics.PreferredBackBufferWidth)// maior q 1000
            {
                enemy3.ResetPositionEnemy();
                //touchBorderDown = true;
                //touchBorderUp = false;
            }

            else if ((enemy3.enemyPosition.X > 0))
            {
                //touchBorderUp = true;
                enemy3.MovimentEnemy();
            }
            #endregion
            #region ZIgZagEnemy
            if ((enemy4.enemyPosition.X + enemy4.enemyPosition.Width) >= graphics.PreferredBackBufferWidth)// maior q 1000
            {
                enemy4.ResetPositionEnemy();
                //touchBorderDown = true;
                //touchBorderUp = false;
            }

            else if ((enemy4.enemyPosition.X > 0))
            {
                //touchBorderUp = true;
                enemy4.MovimentEnemy();
            }
            else if ((enemy4.enemyPosition.X <= 0))
            {
                //touchBorderUp = true;
                enemy4.InvertPosition();
                enemy4.MovimentEnemy();
            }

            #endregion
            #region ZigZag Vertical
            if ((enemy5.enemyPosition.Y + enemy5.enemyPosition.Height) >= graphics.PreferredBackBufferHeight)// maior q 1000
            {
                enemy5.ResetPositionEnemy();
                //touchBorderDown = true;
                //touchBorderUp = false;
            }

            else if ((enemy5.enemyPosition.Y > 0))
            {
                //touchBorderUp = true;
                enemy5.MovimentEnemy();
            }
            else if ((enemy5.enemyPosition.Y <= 0))
            {
                //touchBorderUp = true;
                enemy5.InvertPosition();
                enemy5.MovimentEnemy();
            }
            #endregion
            
            MovimentShip(gameTime);

            foreach (Bullet b in bulletsOnScreen)
            {
                b.ShotPosition.Y -= 10;

                //if (b.shootTexture.Height > graphics.PreferredBackBufferHeight) //add more logic for being off screen
                //    bulletsOnScreen.Remove(b);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            spriteBatch.Draw(cenaryTexture, cenarioPosition, Color.White);
            spriteBatch.Draw(texture, navePosition, Color.BlueViolet);
            spriteBatch.Draw(enemy1.textureEnemy, enemy1.enemyPosition, Color.White);
            spriteBatch.Draw(enemy2.textureEnemy, enemy2.enemyPosition, Color.Wheat);
            spriteBatch.Draw(enemy3.textureEnemy, enemy3.enemyPosition, Color.White);
            spriteBatch.Draw(enemy4.textureEnemy, enemy4.enemyPosition, Color.White);
            spriteBatch.Draw(enemy5.textureEnemy, enemy5.enemyPosition, Color.White);

            if (isShooting == true)
            {
              drawShoot();
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void MovimentShip(GameTime gameTime)
        {
            bool leftArrow = false, rightArrow = false, upArrow = false, downArrow = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                leftArrow = true;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                rightArrow = true;
            if (leftArrow ^ rightArrow)
            {
                navePosition.X += speedShip.X * (leftArrow ? -1 : 1);
                cenarioPosition.X += speedScenario.X * (leftArrow ? -1 : 1);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                upArrow = true;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                downArrow = true;
            if (upArrow ^ downArrow)
            {
                cenarioPosition.Y += speedScenario.Y * (upArrow ? -1 : 1);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isShooting = true;
                if (timeSpan >= nextShoot)
                {
                    nextShoot = fireRate + timeSpan;
                    ShipShoot();
                }
            }
            /*else
                isShooting = false;*/
        }

        public void ShipShoot()
        {
            //Cria sempre uma nova bala com caracteristica em comum da bulletTeste
            Bullet bulletTeste = new Bullet();
            bulletTeste.shootTexture = Content.Load<Texture2D>("Image\\EnemyBullet");
            bulletTeste.ShotPosition = new Vector2(navePosition.X, 720);
            bulletTeste.speedShoot = new Vector2(1, 1);

            bulletsOnScreen.Add(bulletTeste);
        }

        public void drawShoot()
        {
            foreach (var Bullet in bulletsOnScreen)
            {
                spriteBatch.Draw(Bullet.shootTexture, Bullet.ShotPosition, Color.White);
            }
        }

        public bool Colide(Player outraSprite)
        {

            Rectangle spriteBox = new Rectangle((int)bulletsOnScreen[0].ShotPosition.X, (int)bulletsOnScreen[0].ShotPosition.Y, bulletsOnScreen[0].shootTexture.Width, bulletsOnScreen[0].shootTexture.Height);

            Rectangle outraSpriteBox = new Rectangle((int)navePosition.X, (int)navePosition.Y, texture.Width, texture.Height);

            return spriteBox.Intersects(outraSpriteBox);
        }
    }
}
