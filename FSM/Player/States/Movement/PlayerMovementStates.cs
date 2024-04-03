using AssignmentOneAI.Enum;
using AssignmentOneAI.GameObjects;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.FSM.Player.States.Movement
{
    internal abstract class PlayerMovementStates : FSMState
    {
        protected PlayerMovementStates(int type, GameObject gameObject) : base(type, gameObject)
        {
        }

        public override int CheckTransition()
        {
            if (InputManager.HoldKey(Keys.Up))
            {
                return (int)EMoveStatePlayer.FSM_STATE_MOVE_UP;
            }
            else if (InputManager.HoldKey(Keys.Right))
            {
                return (int)EMoveStatePlayer.FSM_STATE_MOVE_RIGHT;
            }
            else if (InputManager.HoldKey(Keys.Left))
            {
                return (int)EMoveStatePlayer.FSM_STATE_MOVE_LEFT;
            }
            else if (InputManager.HoldKey(Keys.Down))
            {
                return (int)EMoveStatePlayer.FSM_STATE_MOVE_DOWN;
            }

            return (int)EMoveStatePlayer.FSM_STATE_IDLE;
        }
       
    }
}
