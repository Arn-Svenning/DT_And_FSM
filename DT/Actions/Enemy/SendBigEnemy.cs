using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions.Enemy
{
    internal class SendBigEnemy : SendEnemy
    {
        public SendBigEnemy(GameObject gameObject) : base(gameObject)
        {
            _width = 64;
            _height = 64;

            _enemySpeed = 75f;
        }
        protected override void PerformAction(GameObject gameObject)
        {
            
            base.PerformAction(gameObject);
        }
    }
}
