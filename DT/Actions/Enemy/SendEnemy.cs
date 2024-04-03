using AssignmentOneAI.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.DT.Actions.Enemy
{
    internal abstract class SendEnemy : Action
    {
        protected float _enemySpeed;
        protected int _width;
        protected int _height;
        protected SendEnemy(GameObject gameObject) : base(gameObject)
        {
            _width = 32;
            _height = 32;
            _enemySpeed = 75f;
        }
        protected override void PerformAction(GameObject gameObject)
        {
            if (gameObject is GameObjects.Moving.Enemy.EnemySpawner enemySpawner)
            {
                // Implement your logic to determine the spawn position here
                int randomSpawn = Globals.Globals.random.Next(1, 5);
                int spawnPosY = Globals.Globals.random.Next(0, Globals.Globals.screenHeight);
                int spawnPosX = Globals.Globals.random.Next(0, Globals.Globals.screenWidth);

                float direction = 0; // Initialize direction variable
                Vector2 spawnPosition = Vector2.Zero;

                Vector2 playerPosition = Globals.Globals.player.Position;

                
                // Determine direction based on the randomSpawn value
                switch (randomSpawn)
                {
                    case 1: // left side
                        spawnPosition = new Vector2(0, spawnPosY);
                        break;
                    case 2: // right side
                        spawnPosition = new Vector2(Globals.Globals.screenWidth, spawnPosY);
                        break;
                    case 3: // bottom side
                        spawnPosition = new Vector2(spawnPosX, Globals.Globals.screenHeight);
                        break;
                    case 4: // top side
                        spawnPosition = new Vector2(spawnPosX, 0);
                        break;
                }

                enemySpawner.Position = spawnPosition;
                direction = (float)Math.Atan2(playerPosition.Y - enemySpawner.Position.Y, playerPosition.X - enemySpawner.Position.X);
                // Add a new enemy with the determined position and direction
                enemySpawner.enemies.Add(new GameObjects.Moving.Enemy.Enemy(_width,_height, enemySpawner.Position,_enemySpeed, direction));
            }
        }
    }
}
