using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Decision.Enemy
{
    internal class IsPlayerMoving : Decision
    {
        public IsPlayerMoving(GameObject gameobject) : base(gameobject)
        {
        }

        public override bool TestValue(GameObject gameObject)
        {
            if(Globals.Globals.player.BIsIdle)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
