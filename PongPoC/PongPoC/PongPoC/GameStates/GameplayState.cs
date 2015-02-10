using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongPoC.GameObjects;

namespace PongPoC.GameStates
{
    internal sealed class GameplayState : GameState
    {
        private readonly Pad _player;
        private readonly Pad _enemy;
        private readonly Ball _ball;

        public GameplayState()
        {
            _player = new PlayerPad(0, ( (float)GlobalSettings.Height - Pad.Height ) / 2);
            _ball = new Ball(new Vector2(( (float)GlobalSettings.Width - Ball.Width ) / 2, ( (float)GlobalSettings.Height - Ball.Height ) / 2));
            _enemy = new EnemyPad(GlobalSettings.Width - Pad.Width, ( (float)GlobalSettings.Height - Pad.Height ) / 2, _ball);
        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            _enemy.Update(gameTime);
            _ball.Update(gameTime, _player, _enemy);
            CheckState();
        }

        private void CheckState()
        {
            var xPosition = _ball.Position.X;

            if (xPosition <= 0)
            {
                this.FinishState(new GameOverMenuState(false));
            }
            else if (xPosition > GlobalSettings.Width)
            {
                this.FinishState(new GameOverMenuState(true));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _player.Draw(batch);
            _enemy.Draw(batch);
            _ball.Draw(batch);
        }
    }
}