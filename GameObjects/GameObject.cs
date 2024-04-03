using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.GameObjects
{
    public abstract class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Size { get { return _size; } }

        protected Rectangle _size;

        public GameObject(Rectangle size)
        {
            _size = size;
        }
        public GameObject()
        { 
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
