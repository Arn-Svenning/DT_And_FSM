using AssignmentOneAI.GameObjects;
using AssignmentOneAI.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Decision.Enemy
{
    internal class HasPlayerWonXRounds : Decision
    {
        private int _xRounds;
        public HasPlayerWonXRounds(GameObject gameobject, int xRounds) : base(gameobject)
        {
            _xRounds = xRounds;
        }

        public override bool TestValue(GameObject gameObject)
        {
            
            if(RoundManager.roundsWon >= _xRounds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
