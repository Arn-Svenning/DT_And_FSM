using AssignmentOneAI.GameObjects.Moving.Player;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.GameObjects.Moving.Enemy
{
    internal class Enemy : MovingGameObject
    {

        private float _direction;
        private int _width, _height;
        public Enemy(Rectangle size, float speed, float direction) : base(size)
        {
            Speed = speed;
            _direction = direction;
            Texture = AssetManager.enemyTexture;
        }
        public Enemy(int width, int height,Vector2 Position, float speed, float direction)
        {
            _width = width;
            _height = height;

            this.Position = Position;
            Speed = speed;
            _direction = direction;
            Texture = AssetManager.enemyTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _size, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            _size = new Rectangle((int)Position.X, (int)Position.Y, _width, _height);
            DealDamageToPlayer();
            MoveToPlayer(gameTime);
        }
        private void MoveToPlayer(GameTime gameTime)
        {
            Position += new Vector2((float)Math.Cos(_direction) * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds,
                (float)Math.Sin(_direction) * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

        }
        public void DealDamageToPlayer()
        {
            if(_size.Intersects(Globals.Globals.player.Size))
            {
                Globals.Globals.player.TakeDamage(1);
            }
        }
    }
}
