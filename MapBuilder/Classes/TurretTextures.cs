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
    public class TurretTextures
    {
        public Texture2D Texturebasewood
        {
            get;
            set;
        }
        public Texture2D Texturebasestone
        {
            get;
            set;
        }
        public Texture2D Texturebasemetal
        {
            get;
            set;
        }
        public Texture2D Texturebasegold
        {
            get;
            set;
        }

        public Texture2D Texturebarrelspike
        {
            get;
            set;
        }
        public Texture2D Texturebarrelcannon
        {
            get;
            set;
        }
        public Texture2D Texturebarrelarrow
        {
            get;
            set;
        }
        public Texture2D Texturebarrelminigun
        {
            get;
            set;
        }

        public Texture2D Textureprojectilespike
        {
            get;
            set;
        }
        public Texture2D Textureprojectilecannon
        {
            get;
            set;
        }
        public Texture2D Textureprojectilearrow
        {
            get;
            set;
        }
        public Texture2D Textureprojectileminigun
        {
            get;
            set;
        }


        public TurretTextures(Texture2D wood, Texture2D stone, Texture2D metal, Texture2D gold, Texture2D barrelspike, Texture2D barrelcannon, Texture2D barrelarrow, Texture2D barrelminigun, Texture2D spike, Texture2D cannonball, Texture2D arrow, Texture2D bullet)
        {
            Texturebasewood = wood;
            Texturebasestone = stone;
            Texturebasemetal = metal;
            Texturebasegold = gold;

            Texturebarrelspike = barrelspike;
            Texturebarrelcannon = barrelcannon;
            Texturebarrelarrow = barrelarrow;
            Texturebarrelminigun = barrelminigun;

            Textureprojectilespike = spike;
            Textureprojectilecannon = cannonball ;
            Textureprojectilearrow = arrow ;
            Textureprojectileminigun = bullet;
        }
    }
}
