using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D logo;
        float targetX = 128;
        float targetY;
        Vector2 scale;

        Vector2 position = new Vector2(0, 0);
        Vector2 velocity = new Vector2(100, 100);

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

            // TODO: use this.Content to load your game content here
            logo = this.Content.Load<Texture2D>("test");
            scale = new Vector2(targetX / (float)logo.Width, targetX / (float)logo.Width);
            targetY = logo.Height * scale.Y;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (position.X <= 0 && velocity.X < 0)
                velocity.X *= -1;
            else if (position.Y <= 0 && velocity.Y < 0)
                velocity.Y *= -1;
            else if (position.X >= graphics.GraphicsDevice.Viewport.Width - targetX && velocity.X > 0)
                velocity.X *= -1;
            else if (position.Y >= graphics.GraphicsDevice.Viewport.Height - targetY && velocity.Y > 0)
                velocity.Y *= -1;

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
            spriteBatch.Begin();

            spriteBatch.Draw(logo, position: position, scale: scale);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
