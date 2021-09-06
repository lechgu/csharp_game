using System.Collections.Generic;
using System.IO;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Blocks.Constants;

namespace Blocks
{
    class App : Game
    {
        private static App instance;
        private readonly GraphicsDeviceManager graphics;
        private Texture2D pixel;
        private SpriteBatch spriteBatch;
        private readonly FontSystem fontSystem = new();
        private SpriteFontBase font18;
        private readonly SceneManager sceneManager;
        private RenderTarget2D target;
        private double? clock;

        public static App Instance
        {
            get => instance;
        }

        public Texture2D Pixel
        {
            get => pixel;
        }
        public SpriteFontBase Font18
        {
            get => font18;
        }
        public App()
        {
            sceneManager = new SceneManager(
                new Dictionary<string, IScene>{
                    {"play", new PlayScene()},
                    {"gameOver", new GameOverScene()}
                }, "play"
            );
            graphics = new GraphicsDeviceManager(this);
            instance = this;
        }

        protected override void Draw(GameTime gameTime)
        {

            graphics.GraphicsDevice.SetRenderTarget(target);
            GraphicsDevice.Clear(Color.DimGray);
            spriteBatch.Begin();
            sceneManager.Render(spriteBatch);
            spriteBatch.End();
            graphics.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            var dst = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            spriteBatch.Draw(target, dst, Color.White);
            spriteBatch.End();
        }

        protected override void Update(GameTime gameTime)
        {
            if (clock.HasValue)
            {
                var updated = gameTime.ElapsedGameTime.TotalSeconds;
                var dt = updated - clock.Value;
                sceneManager.Update(dt);
            }
            else
            {
                clock = gameTime.ElapsedGameTime.TotalSeconds;
            }
        }


        protected override void Initialize()
        {
            base.Initialize();
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.ApplyChanges();
            Window.Title = "Blocks";
            Window.AllowUserResizing = true;
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new[] { Color.White });
            spriteBatch = new SpriteBatch(GraphicsDevice);
            target = new RenderTarget2D(
            GraphicsDevice,
            VIRTUAL_WIDTH,
            VIRTUAL_HEIGHT,
            false,
            SurfaceFormat.Color,
            DepthFormat.None, GraphicsDevice.PresentationParameters.MultiSampleCount,
            RenderTargetUsage.DiscardContents
            );
        }

        protected override void LoadContent()
        {
            fontSystem.AddFont(File.ReadAllBytes("assets/FSEX300.ttf"));
            font18 = fontSystem.GetFont(18);
        }

        public static void Main()
        {
            using var app = new App();
            app.Run();
        }
    }
}
