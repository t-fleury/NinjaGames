using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGames.Core;
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
        bool[] blockedAxes;
        int timeJump;

        public Controler()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            blockedAxes = new bool[4] { false, false, false, false };
            timeJump = 5;
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

            foreach (GameObject ob in model.Objects)
            {
                if (ob.GetType() == typeof(Building))
                {
                    ob.Texture = building;
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
            blockedAxes = model.playerCollision();
            if ((state.IsKeyDown(Keys.Left) && !blockedAxes[1]) || (state.IsKeyDown(Keys.Right) && !blockedAxes[0]))
            {
                model.Player.move(state);
            }
            if (state.IsKeyDown(Keys.W) && !blockedAxes[2] /*&& model.Player.Fuel > 0 && timeJump > 0*/)
            {
               /* model.Player.Fuel--;
                if (model.Player.Fuel == 0)
                {
                    timeJump = 5;
                }*/
                model.Player.jump();
            }
            if (!blockedAxes[3])
            {
                /*timeJump++;
                if(timeJump >= 5)
                {
                    model.Player.Fuel = 5;
                }*/
                model.gravity();
            }
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down))
            {
                model.Player.move(state);
            }
            if (state.IsKeyDown(Keys.X))
            {
                model.Player.fire();
            }
            if (state.IsKeyDown(Keys.Q))
            {
                model.Player.changeWeapons();
            }
            if (state.IsKeyDown(Keys.C))
            {
                model.Player.power();
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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            spriteBatch.Begin();
            model.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}