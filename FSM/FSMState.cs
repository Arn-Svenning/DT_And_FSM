using AssignmentOneAI.Enum;
using AssignmentOneAI.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.FSM
{
    internal abstract class FSMState
    {
        protected GameObject _gameObject;
        public int _type;
        public FSMState(int type, GameObject gameObject)
        {
            this._type = type;
            this._gameObject = gameObject;           
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, Rectangle size);
        public abstract void Init();
        public abstract int CheckTransition();
    }
}
