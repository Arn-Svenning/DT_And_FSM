using AssignmentOneAI.GameObjects;
using AssignmentOneAI.GameObjects.Moving.Player;
using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions.Enemy
{
    internal class SendSlowEnemy : SendEnemy
    {
        public SendSlowEnemy(GameObject gameObject) : base(gameObject)
        {
            _enemySpeed = 60;
        }

        protected override void PerformAction(GameObject gameObject)
        {
            base.PerformAction(gameObject);
        }     

    }

}
