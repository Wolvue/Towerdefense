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
    
    class Pathtile : Tile
    {


        public Pathtile(int x, int y, Texture2D texture)
           : base( x,  y,  texture)
        {

        }
    }
}
