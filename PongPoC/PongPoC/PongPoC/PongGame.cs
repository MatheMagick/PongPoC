using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongPoC.GameStates;

namespace PongPoC
{
    public class PongGame : Game
    {
        internal static readonly PongGame Instance = new PongGame();

        private SpriteBatch _spriteBatch;
        private GameState _gameState;

        private PongGame()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public GraphicsDeviceManager Graphics { get; private set; }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var viewPort = this.Graphics.GraphicsDevice.Viewport;
            GlobalSettings.Height = viewPort.Height;
            GlobalSettings.Width = viewPort.Width;

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameState = new MainMenuState();
            _gameState.Finished += GameState_Finished;
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _gameState.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            _gameState.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void GameState_Finished(GameFinishedEventArgs e)
        {
            _gameState.Finished -= GameState_Finished;
            _gameState = e.NextState;
            _gameState.Finished += GameState_Finished;
        }
    }
}