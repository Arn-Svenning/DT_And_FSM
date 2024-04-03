using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.GameObjects.Moving
{
    internal abstract class MovingGameObject : GameObject
    {
        public Vector2 Direction { get; set; }
        public bool BIsMovingDown { get; set; } = false;
        public bool BIsMovingUp { get; set; } = false;
        public bool BIsMovingRight { get; set; } = false;
        public bool BIsMovingLeft { get; set; } = false;   
        public bool BIsIdle { get; set; } = false;
        public float Speed { get; set; }
        
        #region ANIMATION

        public Rectangle SourceRectangle { get; set; }

        private float elapsedTime;
        private float frameTime;

        private int currentFrame;
        private int frameWidth;
        private int frameHeight;

        #endregion

        public MovingGameObject(Rectangle size) : base(size)
        {

        }
        public MovingGameObject()
        {

        }
        public override abstract void Update(GameTime gameTime);
        public override abstract void Draw(SpriteBatch spriteBatch);

        public void PlayAnimation(GameTime gameTime, float frameSpeed, int numberOfFrames)
        {
            frameTime = frameSpeed;

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            SourceRectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);

            //this.numberOfFrames = numberOfFrames;
            frameWidth = (Texture.Width / numberOfFrames);
            frameHeight = (Texture.Height);

            if (elapsedTime >= frameTime)
            {
                if (currentFrame >= numberOfFrames - 1)
                {
                    currentFrame = 0;

                }
                else
                {
                    currentFrame++;
                }
                elapsedTime = 0;
            }
        }
        
    }
}
