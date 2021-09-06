using Microsoft.Xna.Framework.Graphics;

namespace Blocks
{
    public interface IScene
    {
        public void Render(SpriteBatch spriteBatch);
        public void Update(double dt);
        public void Enter(SceneManager manager, object state);
        public void Leave();
    }
}