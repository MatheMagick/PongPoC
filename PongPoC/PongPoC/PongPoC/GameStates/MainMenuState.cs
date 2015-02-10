using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongPoC.GameStates
{
    internal sealed class MainMenuState : GameState
    {
        private readonly GameMenu _menu;

        public MainMenuState()
        {
            _menu = new GameMenu(1.00,
                new TextMenuItem("New game", true, StartNewGame),
                new TextMenuItem("Options", true, ShowOptions),
                new TextMenuItem("Exit", true, ExitGame));
        }

        public override void Update(GameTime gameTime)
        {
            _menu.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _menu.Draw(gameTime, batch);
        }

        private void ShowOptions()
        {
            this.FinishState(new OptionsState());
        }

        private void StartNewGame()
        {
            this.FinishState(new GameplayState());
        }

        private static void ExitGame()
        {
            PongGame.Instance.Exit();
        }
    }
}