using AssignmentOneAI.Enum;
using AssignmentOneAI.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.FSM
{
    internal class FSMContext
    {
        public GameObject GetSetGameObject { get; set; }

        private List<FSMState> _states;
        private FSMState _currentState;
        private FSMState _defaultState;
        private FSMState _goalState;

        private int _goalStateID;

        public FSMContext(GameObject gameObject)
        {
            
            _states = new List<FSMState>();
            GetSetGameObject= gameObject;
        }
        public void UpdateContext(GameTime gameTime)
        {
            if(_states.Count == 0)
            {
                return;
            }

            if(_currentState == null)
            {
                _currentState = _defaultState; // Set the _currentState to _defaultState if _currentState is null

                if (_currentState == null)
                {
                    return; // If still null return
                }
            }

            FSMState oldState = _currentState;
            _goalStateID = _currentState.CheckTransition();

            // If the _goalState is not the same as the _oldState, change the _currentState to _goalState
            if(_goalStateID != oldState._type)
            {
                foreach(FSMState state in _states)
                {
                    if(_goalStateID == state._type)
                    {
                        _goalState = state;
                    }
                }
                if(TransitionState(_goalState))
                {
                    _currentState.Exit();
                    _currentState = _goalState;
                    _currentState.Enter();
                }
            }

            _currentState.Update(gameTime);
        }
        public void DrawContext(SpriteBatch spriteBatch, Rectangle size)
        {
            _currentState.Draw(spriteBatch, size);
        }
        public void AddState(FSMState state)
        {
            _states.Add(state);
        }
        public void SetDefaultState(int type)
        {
            foreach(FSMState state in _states)
            {
                if(type == state._type)
                {
                    _defaultState = state;
                }
            }
            
        }
        public bool TransitionState(FSMState goalState)
        {
            if(_states.Contains(goalState))
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        public void SetGoalStateId(FSMState goalState)
        {
            _goalState = goalState;
        }
        public void Reset()
        {

        }
    }
}
