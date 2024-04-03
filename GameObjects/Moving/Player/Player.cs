using AssignmentOneAI.Enum;
using AssignmentOneAI.FSM;
using AssignmentOneAI.FSM.Player.States;
using AssignmentOneAI.FSM.Player.States.Movement;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace AssignmentOneAI.GameObjects.Moving.Player
{
    internal class Player : MovingGameObject
    {
        private FSMContext _playerMovementState;
        public bool BIsAlive { get; private set; } = true;
        public int Health { get; private set; }

        private float _invincibleTimer;      

        private bool _bIsHit;



        public Player(Rectangle size) : base(size)
        {
            Position = new Vector2(Globals.Globals.screenWidth / 2, Globals.Globals.screenHeight / 2);

            Health = 3;
            Speed = 250;
            Texture = AssetManager.playerTextures[0];

            _playerMovementState = new FSMContext(this);
         
            _playerMovementState.AddState(new PlayerStateMoveDown((int)EMoveStatePlayer.FSM_STATE_MOVE_DOWN, this));
            _playerMovementState.AddState(new PlayerStateMoveUp((int)EMoveStatePlayer.FSM_STATE_MOVE_UP, this));
            _playerMovementState.AddState(new PlayerStateMoveLeft((int)EMoveStatePlayer.FSM_STATE_MOVE_LEFT, this));
            _playerMovementState.AddState(new PlayerStateMoveRight((int)EMoveStatePlayer.FSM_STATE_MOVE_RIGHT, this));
            _playerMovementState.AddState(new PlayerStateIdle((int)EMoveStatePlayer.FSM_STATE_IDLE, this));

            _playerMovementState.SetDefaultState((int)EMoveStatePlayer.FSM_STATE_IDLE);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(Health > 0)
            {
                spriteBatch.DrawString(AssetManager.font, "Player HP: " + Health, new Vector2(Globals.Globals.screenWidth - 200, 50), Color.White);
                _playerMovementState.DrawContext(spriteBatch, _size);
            }
             

        }

        public override void Update(GameTime gameTime)
        {
            _size = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width / 3, Texture.Height);

            _playerMovementState.UpdateContext(gameTime);

            DecrementInvincibleTimer(gameTime);
            if(Health <= 0)
            {
                BIsAlive = false;
            }
        }
        public void TakeDamage(int damage)
        {
            if(_bIsHit == false)
            {
                Health -= damage;
                _bIsHit = true;
                _invincibleTimer = 3000;
            }
        }
        private void DecrementInvincibleTimer(GameTime gameTime)
        {
            if(_bIsHit == true)
            {
                _invincibleTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(_invincibleTimer <= 0)
                {
                    _bIsHit= false;
                }
            }
        }
    }
}
