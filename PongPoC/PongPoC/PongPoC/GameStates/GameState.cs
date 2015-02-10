using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC
{
    internal abstract class GameState
    {
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch batch);

        protected void FinishState(GameState nextState)
        {
            var finished = this.Finished;

            if (finished != null)
            {
                finished(new GameFinishedEventArgs(nextState));
            }
        }

        public delegate void GameStateFinishedHandler(GameFinishedEventArgs e);
        public event GameStateFinishedHandler Finished;
    }

    internal sealed class GameFinishedEventArgs : EventArgs
    {
        public GameState NextState { get; private set; }

        public GameFinishedEventArgs(GameState nextState)
        {
            NextState = nextState;
        }
    }
}