using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions.Enemy
{
    internal class SendFastEnemy : SendEnemy
    {
        public SendFastEnemy(GameObject gameObject) : base(gameObject)
        {
            _enemySpeed = 200;
        }
        protected override void PerformAction(GameObject gameObject)
        {
            base.PerformAction(gameObject);
        }
    }
}
