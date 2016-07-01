using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGames.Core;
using MyGames.Core.Class;
using System;

namespace MyGames
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Controler : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Core.Model model;
        Texture2D building;
        Texture2D platform;
        public static Texture2D shoot;
        bool[] blockedAxes;
        bool[] blockedAxesFall;
        bool fall;

        public Controler()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
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
            blockedAxes = new bool[5] { false, false, false, false, false };
            blockedAxesFall = new bool[2] { false, false };
            model = new Core.Model();
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
            model.Player.Texture = this.Content.Load<Texture2D>("tmpTest");
            building = this.Content.Load<Texture2D>("tmpBuilding");
            platform = this.Content.Load<Texture2D>("tmpPlatform");
            shoot = this.Content.Load<Texture2D>("tmpShoot");

            foreach (GameObject ob in model.Objects)
            {
                if (ob.GetType() == typeof(Building))
                {
                    ob.Texture = building;
                }
                else if (ob.GetType() == typeof(Platform))
                {
                    ob.Texture = platform;
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
            {
                //TODO menu
            }

            #region using a key
            blockedAxes = model.playerCollision();
            blockedAxesFall[0] = false;
            blockedAxesFall[1] = false;
            fall = false;

            #region jump/fall
            if (model.Player.PosY > model.PlayerJump && model.playerCollisionJumpCase() == false)
            {
                model.jump();
            }
            else if (state.IsKeyDown(Keys.W) && blockedAxes[2] == false && (blockedAxes[3] == true || blockedAxes[4] == true))
            {
                model.firstJump();
                model.jump();
            }
            else if (blockedAxes[3] == false && blockedAxes[4] == false)
            {
                model.gravity();
                model.PlayerJump = model.Player.PosY;
                blockedAxesFall = model.playerCollisionFallCase();
                fall = true;
            }
            #endregion

            #region move right/left
            if (fall)
            {
                if ((state.IsKeyDown(Keys.Left) && blockedAxesFall[1] == false) || (state.IsKeyDown(Keys.Right) && blockedAxesFall[0] == false))
                {
                    model.move(state);
                }
            }
            else
            {
                if ((state.IsKeyDown(Keys.Left) && blockedAxes[1] == false) || (state.IsKeyDown(Keys.Right) && blockedAxes[0] == false))
                {
                    model.move(state);
                }
            }
            #endregion

            #region look up/down/interact
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down))
            {
                model.move(state);
            }
            #endregion

            #region other gameplay key
            if (state.IsKeyDown(Keys.X))
            {
                model.fire();
            }

            if (state.IsKeyDown(Keys.Q))
            {
                model.changeWeapons();
            }

            if (state.IsKeyDown(Keys.C))
            {
                model.power();
            }
            #endregion

            #endregion

            foreach(Shoot s in model.Player.Shoots)
            {
                s.move();
            }

            int i = 0;
            foreach (GameObject ob in model.Objects)
            {
                if (ob.GetType() == typeof(Enemy))
                {
                    moveShoot(i);
                }
                i++;
            }

            base.Update(gameTime);
        }

        private void moveShoot(int i)
        {
            Perso tmp = (Perso)model.Objects[i];
            foreach(Shoot s in tmp.Shoots)
            {
                s.move();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.Begin();
            model.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}