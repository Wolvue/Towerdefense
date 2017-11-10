using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MapBuilder.Classes
{
    public class Turrettile : Tile
    {
        private Texture2D highlight;

        public bool Hasturret
        {
            get;
            set;
        }
        public bool Highlighted
        {
            get;
            set;
        }

       
        
            

        public Turrettile(int x, int y, Texture2D texture, Texture2D highlight)
            : base(x ,y , texture)
        {
            this.highlight = highlight;
        }

        public void Drawhighlight (SpriteBatch batch)
        {
            batch.Draw(highlight, tilebox, Color.White);
        }


    }
}
