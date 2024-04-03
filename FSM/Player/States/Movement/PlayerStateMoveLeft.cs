﻿using AssignmentOneAI.Enum;
using AssignmentOneAI.GameObjects;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace AssignmentOneAI.FSM.Player.States.Movement
{
    internal class PlayerStateMoveLeft : PlayerMovementStates
    {
        public PlayerStateMoveLeft(int type, GameObject gameObject) : base(type, gameObject)
        {
        }

        public override int CheckTransition()
        {
            return base.CheckTransition();
        }

        public override void Draw(SpriteBatch spriteBatch, Rectangle size)
        {
            if (_gameObject is GameObjects.Moving.Player.Player player)
            {
                spriteBatch.Draw(player.Texture, size, player.SourceRectangle,
                    Color.White, 0f, Vector2.Zero, SpriteEffects.None, 1);
            }
        }

        public override void Enter()
        {
            if (_gameObject is GameObjects.Moving.Player.Player player)
            {
                player.BIsMovingLeft = true;

                player.Direction = new Vector2(-1, player.Direction.Y);

                player.Texture = AssetManager.playerTextures[3];
            }
        }

        public override void Exit()
        {
            if (_gameObject is GameObjects.Moving.Player.Player player)
            {
                player.BIsMovingLeft = false;

                player.Direction = new Vector2(0, player.Direction.Y);
            }
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            if (_gameObject is GameObjects.Moving.Player.Player player)
            {
                player.Direction.Normalize();

                player.Position += player.Speed * player.Direction * (float)gameTime.ElapsedGameTime.TotalSeconds;

                player.PlayAnimation(gameTime, 100f, 3);
            }
        }
    }
}
