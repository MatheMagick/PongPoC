using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC.GameStates
{
    internal sealed class GameOverMenuState : GameState
    {
        private readonly GameMenu _menu;

        public GameOverMenuState(bool isWon)
        {
            _menu = new GameMenu(1.00,
                new TextMenuItem(isWon ? "Won" : "Lost", false, null),
                new TextMenuItem("Try Again", true, RestartGame),
                new TextMenuItem("Main Menu", true, ShowMainMenu));
        }

        private void RestartGame()
        {
            this.FinishState(new GameplayState());
        }

        private void ShowMainMenu()
        {
            this.FinishState(new MainMenuState());
        }

        public override void Update(GameTime gameTime)
        {
            _menu.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _menu.Draw(gameTime, batch);
        }
    }
}