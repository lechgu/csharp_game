using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Blocks
{
    public class SceneManager
    {
        private readonly Dictionary<string, IScene> scenes;
        private IScene currentScene;

        public SceneManager(Dictionary<string, IScene> scenes, string initial)
        {
            this.scenes = scenes;
            currentScene = this.scenes[initial];
            currentScene.Enter(this, null);
        }

        public void SwitchScene(string newScene, object state)
        {
            currentScene.Leave();
            currentScene = scenes[newScene];
            currentScene.Enter(this, state);
        }
        public void Render(SpriteBatch spriteBatch)
        {
            currentScene.Render(spriteBatch);
        }
        public void Update(double dt)
        {
            currentScene.Update(dt);
        }
    }

}