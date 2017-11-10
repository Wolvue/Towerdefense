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
    public class Tile
    {
        public Texture2D tiletexture;
        public Vector2 tilebox;
        public Tile(int x, int y, Texture2D texture)
        {
            tilebox = new Vector2(x, y);
            tiletexture = texture;
        }
        public void DrawTile(SpriteBatch batch)
        {
            batch.Draw(tiletexture, tilebox, Color.White);
        }
    }
}
