using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace linridder
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet;

        Rectangle buttonSource;
        Rectangle button;

        Rectangle button2Source;
        Rectangle button2;

        Rectangle button3Source;
        Rectangle button3;

        Rectangle button4Source;
        Rectangle button4;
        //Ridder ridder;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.ApplyChanges();
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
            spriteSheet = Content.Load<Texture2D>("Graphics");

            buttonSource = new Rectangle(0, 0, 67, 85);
            button2Source = new Rectangle(69, 0, 67, 85);
            button3Source = new Rectangle(0, 87, 67, 85);
            button4Source = new Rectangle(69, 87, 67, 85);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.FromNonPremultiplied(55,74,36,2));

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }

    public class Entity
    {
        public Vector2 position;
        public Vector2 spriteCoords;
        public Vector2 size;
        public Texture2D spriteSheet;
        public int velocity;
        public int acceleration;
        public double rotation;
        public double spin;
        public Entity(Vector2 Position, Vector2 SpriteCoords, Vector2 Size, Texture2D SpriteSheet, int Velocity, int Acceleration, double Rotation, double Spin)
        {
            position = Position;
            spriteCoords = SpriteCoords;
            size = Size;
            spriteSheet = SpriteSheet;
            velocity = Velocity;
            acceleration = Acceleration;
            rotation = Rotation;
            spin = Spin;
        }

        public void update()
        {
            velocity += acceleration;
            rotation += spin;
            position.X += (float)((double)velocity * Math.Cos(rotation));
            position.Y += (float)((double)velocity * Math.Sin(rotation));
        }


    }

    public class Line : Entity
    {
        public Line(double Length, double Rotation, Vector2 Position, Texture2D SpriteSheet)
        {
            spriteSheet = SpriteSheet;
            position = Position;

        }
    }

}
