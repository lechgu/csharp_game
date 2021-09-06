using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blocks
{
    class GameOverScene : IScene
    {
        private SceneManager sceneManager;
        private GameSummary gameSummary;
        private readonly InputManager inputManager = new();

        public void Enter(SceneManager manager, object state)
        {
            sceneManager = manager;
            gameSummary = state as GameSummary;
            inputManager.Handle(Keys.Enter, () =>
            {
                sceneManager.SwitchScene("play", null);
            });
            inputManager.Handle(Keys.Escape, () =>
            {
                App.Instance.Exit();
            });
        }

        public void Leave()
        {
        }

        public void Render(SpriteBatch spriteBatch)
        {
            App.Instance.Font18.DrawText(
                spriteBatch,
                "GAME OVER",
                new Vector2(128, 100),
                Color.White
            );
            App.Instance.Font18.DrawText(
                spriteBatch,
                $"Final Level: {gameSummary.Level + 1}",
                new Vector2(128, 132),
                Color.White
            );
            App.Instance.Font18.DrawText(
                spriteBatch,
                $"Final score: {gameSummary.Score}",
                new Vector2(128, 148),
                Color.White
            );
            App.Instance.Font18.DrawText(
                spriteBatch,
                "[enter] to play again",
                new Vector2(128, 164),
                Color.White
            );
            App.Instance.Font18.DrawText(
                spriteBatch,
                "[escape] to exit",
                new Vector2(128, 180),
                Color.White
            );
        }

        public void Update(double dt)
        {
            inputManager.Update(dt);
        }
    }
}