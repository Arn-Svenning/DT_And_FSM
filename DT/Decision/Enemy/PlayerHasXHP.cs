using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Decision.Enemy
{
    internal class PlayerHasXHP : Decision
    {
        private int _xHP;
        public PlayerHasXHP(GameObject gameobject, int xHP) : base(gameobject)
        {
            _xHP = xHP;
        }

        public override bool TestValue(GameObject gameObject)
        {
           if(Globals.Globals.player.Health == _xHP)
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
