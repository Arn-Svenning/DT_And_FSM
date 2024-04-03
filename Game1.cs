using AssignmentOneAI.GameObjects;
using AssignmentOneAI.GameObjects.Moving.Enemy;
using AssignmentOneAI.GameObjects.Moving.Player;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace AssignmentOneAI
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        

        private RoundManager roundManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = Globals.Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.Globals.screenHeight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadAssets(Content);

            roundManager= new RoundManager();

            

            Globals.Globals.player = new Player(new Rectangle(Globals.Globals.screenWidth / 2, Globals.Globals.screenHeight / 2, 64, 64));

            Globals.Globals.enemySpawner = new EnemySpawner();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            InputManager.UpdateInput();


            Globals.Globals.player.Update(gameTime);
            Globals.Globals.enemySpawner.Update(gameTime);
            
            roundManager.Update(gameTime, Globals.Globals.player);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            roundManager.Draw(_spriteBatch);

            Globals.Globals.player.Draw(_spriteBatch);
            Globals.Globals.enemySpawner.Draw(_spriteBatch);
           
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}