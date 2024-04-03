using AssignmentOneAI.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.Manager
{
    internal class RoundManager
    {
        public static float currentTime;
        public static float roundLength = 10000;

        public static int roundsWon;

        public static bool bIsRoundWon = false;
        public static bool bIsRoundStarted = false;
       
        private float delayRoundStart = 2000;

        public RoundManager()
        {
            
        }
        public void Update(GameTime gameTime, GameObject gameObject)
        {           
            if(gameObject is GameObjects.Moving.Player.Player player)
            {
                if (player.BIsAlive)
                {
                    if (!bIsRoundStarted)
                    {
                        delayRoundStart -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                        if (delayRoundStart <= 0)
                        {
                            bIsRoundStarted = true;
                            currentTime = roundLength;
                        }
                    }
                    else
                    {
                        currentTime -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                        if (currentTime <= 0)
                        {
                            roundsWon++;
                            delayRoundStart = 2000; // reset to 3000 milliseconds (3 seconds)
                            bIsRoundStarted = false;
                        }
                    }
                }


            }
        }
            
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(AssetManager.font, "RoundsWon: " + roundsWon, new Vector2(Globals.Globals.screenWidth / 8, 50), Color.White);

            if(bIsRoundStarted == true)
            {
                int currentTimeSeconds = (int)currentTime / 1000;
                spriteBatch.DrawString(AssetManager.font, "Time left: " + currentTimeSeconds.ToString("0"), new Vector2(Globals.Globals.screenWidth / 2 - 100, 50), Color.Red);
            }
            else
            {
                int delayRoundStartSeconds = (int)delayRoundStart / 1000;
                spriteBatch.DrawString(AssetManager.font, "Next round in: " + delayRoundStartSeconds.ToString("0"), new Vector2(Globals.Globals.screenWidth / 2 - 100, 50), Color.Red);
            }
            
        }
    }
}
