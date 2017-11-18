using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Entities.Classes
{
    public class Projectile
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position;

        private float rotation;


        private bool calcspeed;
        private float xspeed;
        private float yspeed;

        public Projectile(Texture2D texture, Vector2 pos, Vector2 target)
        {
            Texture = texture;
            Position = pos;
            calcspeed = false;





        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, null, Color.White, rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), 1f, SpriteEffects.None, 0f);
        }

        public void Update(Vector2 target)
        {
            target.X += 15;
            target.Y += 20;

            float xDistance = Position.X - target.X;
            float yDistance = Position.Y - target.Y;
            calcspeed = true;
            xspeed = xDistance / 4;
            yspeed = yDistance / 4;


            if (target.X < Position.X)
            {
                Position.X -= xspeed;
            }
            if (target.X > Position.X)
            {
                Position.X -= xspeed;
            }
            if (target.Y < Position.Y)
            {
                Position.Y -= yspeed;
            }
            if (target.Y > Position.Y)
            {
                Position.Y -= yspeed;
            }
            

            rotation = (float)(Math.Atan2((double)yDistance, (double)xDistance) + (Math.PI * 1.5));
        }

        public void Clearshots()
        {

        }
    }
}
