using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOneAI.Manager
{
    internal class AssetManager
    {
        public static Texture2D[] playerTextures = new Texture2D[4];

        public static Texture2D enemyTexture;

        public static SpriteFont font;

        public static void LoadAssets(ContentManager contentManager)
        {
            playerTextures[0] = contentManager.Load<Texture2D>("Player/Front-Sheet");
            playerTextures[1] = contentManager.Load<Texture2D>("Player/Up-Sheet");
            playerTextures[2] = contentManager.Load<Texture2D>("Player/Right-Sheet");
            playerTextures[3] = contentManager.Load<Texture2D>("Player/Left-Sheet");

            enemyTexture = contentManager.Load<Texture2D>("Enemy/pecboy_1");

            font = contentManager.Load<SpriteFont>("Font/defaultFont");
            
        }
    }
}
