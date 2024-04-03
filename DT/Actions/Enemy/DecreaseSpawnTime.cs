using AssignmentOneAI.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions.Enemy
{
    internal class DecreaseSpawnTime : SendEnemy
    {
        public DecreaseSpawnTime(GameObject gameObject) : base(gameObject)
        {
            if(gameObject is GameObjects.Moving.Enemy.EnemySpawner enemySpawner)
            {
                enemySpawner.DecisionInterval = enemySpawner.DecisionInterval / 1.5f;
            }
        }
        protected override void PerformAction(GameObject gameObject)
        {
            base.PerformAction(gameObject);
        }
    }
}
