using AssignmentOneAI.DT;
using AssignmentOneAI.DT.Actions.Enemy;
using AssignmentOneAI.DT.Decision;
using AssignmentOneAI.DT.Decision.Enemy;
using AssignmentOneAI.Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.GameObjects.Moving.Enemy
{
    internal class EnemySpawner : MovingGameObject
    {
        public List<Enemy> enemies= new List<Enemy>();
        public float DecisionInterval { get; set; } = 1500; // 3 seconds 

        private float elapsedTime = 0f;

        #region DT

        private DecisionTreeBuilder _DTBuilder;

        #region DECISION

        private Decision _rootNode;
        private Decision _bIsPlayerHP3;
        private Decision _bIsPlayerHP2;
        private Decision _bIsPlayerHP1;
        private Decision _bHasPlayerWon5Rounds;
        private Decision _bHasPlayerWon3Rounds;
        private Decision _bHasPlayerWon8Rounds;
        private Decision _bHasPlayerWon10Rounds;
        private Decision _bHasPlayerWon7Rounds;

        #endregion

        #region ACTION

        private SendFastEnemy _sendFastEnemy;
        private SendSlowEnemy _sendSlowEnemy;
        private SendBigEnemy _sendBigEnemy;
        
        #endregion
        #endregion
        public EnemySpawner(Rectangle size) : base(size)
        {
        }
        public EnemySpawner()
        {

            InstantiateActionsAndDecisions();
            BuildDT();
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            foreach(var enemy in enemies)
            {
               enemy.Draw(spriteBatch);
            }
            
        }

        public override void Update(GameTime gameTime)
        {

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Check if it's time to make a decision
            if (elapsedTime >= DecisionInterval && RoundManager.bIsRoundStarted)
            {
                // Reset the timer
                elapsedTime = 0f;

                // Make the decision
                _rootNode.MakeDecision();
            }

            foreach (var enemy in enemies.ToList())  
            {
                enemy.Update(gameTime);

                // Check if the enemy is outside the screen boundaries
                if (!IsInsideScreen(enemy.Position))
                {
                    // Remove the enemy from the list
                    enemies.Remove(enemy);
                }
            }
        }
        private bool IsInsideScreen(Vector2 position)
        {
            // Check if the position is inside the screen boundaries
            return position.X >= 0 && position.X <= Globals.Globals.screenWidth &&
                   position.Y >= 0 && position.Y <= Globals.Globals.screenHeight;
        }
        #region DT
        private void InstantiateActionsAndDecisions()
        {
            // Decisions
            _DTBuilder = new DecisionTreeBuilder();
            _rootNode = new IsPlayerMoving(this);

            _bIsPlayerHP3 = new PlayerHasXHP(this, 3);
            _bIsPlayerHP2 = new PlayerHasXHP(this, 2);
            _bIsPlayerHP1 = new PlayerHasXHP(this, 1);

            _bHasPlayerWon5Rounds = new HasPlayerWonXRounds(this, 5);
            _bHasPlayerWon3Rounds = new HasPlayerWonXRounds(this, 3);
            _bHasPlayerWon8Rounds = new HasPlayerWonXRounds(this, 8);
            _bHasPlayerWon10Rounds = new HasPlayerWonXRounds(this, 10);
            _bHasPlayerWon7Rounds = new HasPlayerWonXRounds(this, 7);

            // Actions
            _sendFastEnemy = new SendFastEnemy(this);
            _sendSlowEnemy = new SendSlowEnemy(this);
            _sendBigEnemy = new SendBigEnemy(this);
        }
        private void BuildDT()
        {
            // Build DT
            _DTBuilder.SetRootNode(_rootNode);

            _DTBuilder.AddNode(_rootNode, _bIsPlayerHP3, _sendFastEnemy); // Height 1
            _DTBuilder.AddNode(_bIsPlayerHP3, _bHasPlayerWon5Rounds, _bIsPlayerHP2); // Height 2
            _DTBuilder.AddNode(_bHasPlayerWon5Rounds, _sendBigEnemy, _bHasPlayerWon3Rounds); // Height 3
            _DTBuilder.AddNode(_bIsPlayerHP2, _bHasPlayerWon8Rounds, _bIsPlayerHP1); // Height 3
            _DTBuilder.AddNode(_bHasPlayerWon3Rounds, _sendFastEnemy, _sendSlowEnemy); // Height 4
            _DTBuilder.AddNode(_bHasPlayerWon8Rounds, _sendBigEnemy, _sendSlowEnemy); // Height 4
            _DTBuilder.AddNode(_bIsPlayerHP1, _bHasPlayerWon10Rounds, _sendSlowEnemy); // Height 4
            _DTBuilder.AddNode(_bHasPlayerWon10Rounds, _sendBigEnemy, _bHasPlayerWon7Rounds); // Height 5
            _DTBuilder.AddNode(_bHasPlayerWon7Rounds, _sendFastEnemy, _sendSlowEnemy); // Height 6
        }
        #endregion
    }
}
