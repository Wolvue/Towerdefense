using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mapbuilder.Classes
{
    public class Mainbase : Game
    {
        private int health;
        private Texture2D basetiletexture;
        private Rectangle basetile;
            


        public Mainbase(Texture2D basetiletexture)
        {
            this.basetiletexture = basetiletexture;
            basetile = new Rectangle(750, 350, 50, 50);
            health = 100;
        }

        public void DrawBase(SpriteBatch batch)
        {
            batch.Draw(basetiletexture, basetile, Color.White);
        }

    }
}
