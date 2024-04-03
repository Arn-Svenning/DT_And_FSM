using AssignmentOneAI.GameObjects.Moving.Enemy;
using AssignmentOneAI.GameObjects.Moving.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.Globals
{
    internal class Globals
    {
        public static int screenWidth = 920;
        public static int screenHeight = 600;

        public static Random random = new Random();

        public static Player player;
        public static EnemySpawner enemySpawner;

    }
}
